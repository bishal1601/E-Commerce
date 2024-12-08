namespace E_Commerce.Entities
{
    public class Vendor
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public bool Status { get; set; } // Active/Inactive

        // Navigation Properties
        public ICollection<Product> Products { get; set; }
    }
}