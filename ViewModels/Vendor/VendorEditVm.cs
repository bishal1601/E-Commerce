namespace E_Commerce.Models.Vendor;

public class VendorEditVm
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public bool Status { get; set; }
}