namespace OrderService.Core.DTOs;

public class OrderResponseDto
{

        public Guid Id { get; set; }
        public string? ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
}
