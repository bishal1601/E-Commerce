


using E_Commerce.Models.ProductImageVm;

namespace E_Commerce.Models.Product;

public class ProductDetailVm
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
        
    public String CategoryName { get; set; }
        
    public String VendorName { get; set; }
        
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public bool Status { get; set; }
    public List<ProductImageReportVm> ProductImageUrl { get; set; } = new List<ProductImageReportVm>();
}