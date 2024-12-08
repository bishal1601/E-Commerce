namespace E_Commerce.Models.Order;

public class OrderVm
{
        
    public long UserId { get; set; }
        
    public string Status { get; set; } // Pending, Completed, Cancelled
    public decimal TotalAmount { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}