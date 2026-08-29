namespace OrderService.Core.Entities;

public class Orders
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string? ProductName { get; set; }
    public int? Quantity { get; set; }
    public decimal? TotalPrice { get; set; }
    public DateTime? OrderDate { get; set; }
}
