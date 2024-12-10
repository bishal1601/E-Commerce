using E_Commerce.Models.Product;

namespace E_Commerce.Models.ProductImageVm;

public class ProductImageVm
{
    public string ImageUrl { get; set; }
    public bool IsPrimary { get; set; }
    public long ProductId { get; set; }
    
    public virtual ProductVm Product { get; set; }
}