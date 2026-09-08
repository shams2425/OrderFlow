using InventoryService.Infrastructure.Data;
using InventoryService.Infrastructure.Messaging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InventoryService.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString("InventoryDbConnection")!;
        services.AddDbContext<InventoryDbContext>(opt =>
        {
            opt.UseSqlServer(connectionString);
        });
        return services;

        services.AddHostedService<OrderPlacedConsumer>();
        return services;
    }
}
