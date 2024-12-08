namespace E_Commerce.Models.Review;

public class ReviewVm
{
        
    public long UserId { get; set; }
        
    public long ProductId { get; set; }
        
    public int Rating { get; set; } // 1-5
    public string Comment { get; set; }
    public DateTime CreatedAt { get; set; }
}