namespace E_Commerce.Dto.ProductImageDto;

public class ProductImageDto
{
    public long Id { get; set; }
    public string ImageUrl { get; set; }
    public bool IsPrimary { get; set; }
    public long ProductId { get; set; }
}