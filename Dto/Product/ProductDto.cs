using Microsoft.AspNetCore.Mvc.Rendering;

namespace E_Commerce.Dto.Product;

public class ProductDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
        
    public long CategoryId { get; set; }
        
    public long VendorId { get; set; }
        
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public bool Status { get; set; } 
    
    
    public List<SelectListItem> Categories  = new List<SelectListItem>();
    public SelectList GetCategoryOptions ()=> new SelectList(Categories, nameof(SelectListItem.Value), nameof(SelectListItem.Text), CategoryId);
    
    public List<SelectListItem> Vendors  = new List<SelectListItem>();
    public SelectList GetVendorOptions ()=> new SelectList(Vendors, nameof(SelectListItem.Value), nameof(SelectListItem.Text), VendorId);

}