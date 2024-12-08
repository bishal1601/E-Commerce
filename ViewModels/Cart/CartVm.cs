using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Models.Cart;

public class CartVm
{
    [Required]        
    public long UserId { get; set; }
    [Required]
    public long ProductId { get; set; }
    [Required]    
    public int Quantity { get; set; }
}