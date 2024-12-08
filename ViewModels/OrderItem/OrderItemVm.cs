namespace E_Commerce.Models.OrderItem;

public class OrderItemVm
{
    public long OrderId { get; set; }
        
    public long ProductId { get; set; }
        
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}