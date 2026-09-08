namespace InventoryService.Core.Events;

public class OrderPlacedEvent
{
    public Guid OrderId { get; set; }
    public string? ProductName { get; set; }
    public int Quantity { get; set; }
    public DateTime OrderDate { get; set; }
}
