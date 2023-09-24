using System.ComponentModel.DataAnnotations;

namespace Alexandria.Models.Models;

public class Review
{
    [Key]
    public int ReviewId { get; set; }
    
    public int UserId { get; set; }
    
    public string? CombinePlacement { get; set; }
}