namespace E_Commerce.Entities
{
    public class Cart
    {
        public long Id { get; set; }
        
        public long UserId { get; set; }
        public virtual User User { get; set; }
        
        public long ProductId { get; set; }
        public virtual Product Product { get; set; }
        
        public int Quantity { get; set; }

    }
}