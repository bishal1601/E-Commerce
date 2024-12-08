namespace E_Commerce.Models.Shipping;

public class ShippingVm
{
    public long OrderId { get; set; }
        
    public string Address { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string PhoneNumber { get; set; }
    public string Status { get; set; } // Shipped, Delivered, In Transit
}