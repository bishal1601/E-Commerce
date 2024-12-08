namespace E_Commerce.Entities
{
    public class Shipping
    {
        public long Id { get; set; }
        
        public long OrderId { get; set; }
        public virtual Order Order { get; set; }
        
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PhoneNumber { get; set; }
        public string Status { get; set; } // Shipped, Delivered, In Transit

        // Navigation Properties
    }
}