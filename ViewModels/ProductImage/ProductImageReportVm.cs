using E_Commerce.Models.Product;

namespace E_Commerce.Models.ProductImageVm;

public class ProductImageReportVm
{
    public long Id { get; set; }
    public string ImageUrl { get; set; }
    public bool IsPrimary { get; set; }
    public long ProductId { get; set; }
    
}