using Microsoft.Extensions.DependencyInjection;
using OrderService.Core.Interfaces;
using OrderService.Core.Mappers;

namespace OrderService.Core;

public static class DependencyInjection
{
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(CreateOrderToOrderMappingprofile).Assembly);
    
        return services;
    }

}
