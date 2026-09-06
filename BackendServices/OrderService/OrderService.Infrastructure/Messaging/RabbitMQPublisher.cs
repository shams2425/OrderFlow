using RabbitMQ.Client;
using System.Text;
using System.Text.Json;
using OrderService.Core.Interfaces;

namespace OrderService.Infrastructure.Messaging
{
    public class RabbitMQPublisher : IEventPublisher
    {
        public async Task Publish<T>(T eventMessage, string queueName)
        {
            var factory = new ConnectionFactory { HostName = "localhost" };
            using var connection = await factory.CreateConnectionAsync();
            using var channel = await connection.CreateChannelAsync();

            await channel.QueueDeclareAsync(queue: queueName, durable: true, exclusive: false, autoDelete: false);

            var json = JsonSerializer.Serialize(eventMessage);
            var body = Encoding.UTF8.GetBytes(json);

            await channel.BasicPublishAsync(exchange: "", routingKey: queueName, body: body);
        }
    }
}