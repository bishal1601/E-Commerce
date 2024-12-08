namespace E_Commerce.Models.Payment;

public class PaymentVm
{
    public long OrderId { get; set; }
        
    public string PaymentMethod { get; set; } // Cash, Card, Online
    public string PaymentStatus { get; set; } // Paid, Pending, Failed
    public DateTime PaymentDate { get; set; }
}