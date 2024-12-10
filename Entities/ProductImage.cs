namespace E_Commerce.Entities;

public class ProductImage
{
    
        public long Id { get; set; }
        public string ImageUrl { get; set; }
        public bool IsPrimary { get; set; }
        public long ProductId { get; set; }
        public virtual Product Product { get; set; }
    
}