namespace InventoryService.Core.Entities;

public class Stock
{
    public Guid id { get; set; } = Guid.NewGuid();
    public string? ProductName { get; set; }
    public int? Quantity { get; set; }
}
