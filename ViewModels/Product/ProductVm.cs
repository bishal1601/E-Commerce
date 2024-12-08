using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace E_Commerce.Models.Product;

public class ProductVm
{
    [Required]
    public string Name { get; set; }
    public string Description { get; set; }
    [Range(0, double.MaxValue, ErrorMessage = "Price cannot be negative.")]
    public decimal Price { get; set; }
    [Range(0, double.MaxValue, ErrorMessage = "Stock cannot be negative.")]
    public int Stock { get; set; }
        
    public long CategoryId { get; set; }
        
    public long VendorId { get; set; }
    public bool Status { get; set; } 
    public List<SelectListItem> Categories  = new List<SelectListItem>();
    public SelectList GetCategoryOptions ()=> new SelectList(Categories, nameof(SelectListItem.Value), nameof(SelectListItem.Text), CategoryId);
    public List<SelectListItem> Vendors  = new List<SelectListItem>();
    public SelectList GetVendorOptions ()=> new SelectList(Vendors, nameof(SelectListItem.Value), nameof(SelectListItem.Text), VendorId);
}
    
