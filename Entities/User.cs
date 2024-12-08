namespace E_Commerce.Entities
{
    public class User
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; } // Admin, Customer, etc.
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateTime DateJoined { get; set; }

        public ICollection<Order> Orders { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<Cart> CartItems { get; set; }
    }
}