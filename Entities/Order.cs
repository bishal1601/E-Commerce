namespace E_Commerce.Entities
{
    public class Order
    {
        public long Id { get; set; }
        
        public long UserId { get; set; }
        public virtual User User { get; set; }
        
        public string Status { get; set; } // Pending, Completed, Cancelled
        public decimal TotalAmount { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual Payment Payment { get; set; }
        public virtual Shipping Shipping { get; set; }
        
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}