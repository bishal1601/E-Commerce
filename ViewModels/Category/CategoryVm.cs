using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Models.Category;

public class CategoryVm
{
    [Required]
    public string Name { get; set; }
    
    public string Description { get; set; }

}