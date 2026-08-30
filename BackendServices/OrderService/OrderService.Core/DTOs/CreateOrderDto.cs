namespace OrderService.Core.DTOs;

public class CreateOrderDto
{
    public string? ProductName { get; set; }
    public int? Quantity { get; set; }
    public decimal Price { get; set; }
}
