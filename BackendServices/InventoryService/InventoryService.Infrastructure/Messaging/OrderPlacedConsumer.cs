using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;
using InventoryService.Core.Entities;
using InventoryService.Core.Events;
using InventoryService.Infrastructure.Data;

namespace InventoryService.Infrastructure.Messaging
{
    public class OrderPlacedConsumer : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;

        public OrderPlacedConsumer(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            ConnectionFactory factory = new ConnectionFactory { HostName = "localhost" };
            var connection = await factory.CreateConnectionAsync(stoppingToken);
            var channel = await connection.CreateChannelAsync(cancellationToken: stoppingToken);

            await channel.QueueDeclareAsync(queue: "order-placed-queue", durable: true, exclusive: false, autoDelete: false, cancellationToken: stoppingToken);

            var consumer = new AsyncEventingBasicConsumer(channel);
            consumer.ReceivedAsync += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var json = Encoding.UTF8.GetString(body);
                var orderEvent = JsonSerializer.Deserialize<OrderPlacedEvent>(json);

                using var scope = _serviceProvider.CreateScope();
                var dbContext = scope.ServiceProvider.GetRequiredService<InventoryDbContext>();

                var stock = dbContext.Stocks.FirstOrDefault(s => s.ProductName == orderEvent.ProductName);

                if (stock != null)
                {
                    stock.Quantity -= orderEvent.Quantity;
                }
                else
                {
                    dbContext.Stocks.Add(new Stock
                    {
                        ProductName = orderEvent.ProductName,
                        Quantity = -orderEvent.Quantity
                    });
                }

                await dbContext.SaveChangesAsync();
            };

            await channel.BasicConsumeAsync(queue: "order-placed-queue", autoAck: true, consumer: consumer, cancellationToken: stoppingToken);
        }
    }
}