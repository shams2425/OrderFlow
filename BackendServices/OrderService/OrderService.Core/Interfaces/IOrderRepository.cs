using OrderService.Core.Entities;

namespace OrderService.Core.Interfaces;

public interface IOrderRepository
{
    Task<Orders> CreateOrderAsync(Orders orders);
    Task<Orders> GetOrderByIdAsync(Guid id);
    Task<IEnumerable<Orders>> GetAllOrderAsync();
}
