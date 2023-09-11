using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alexandria.Models.Models;

public class Token
{
    [Key]
    public int TokenId { get; set; }
    
    [ForeignKey("UserId")]
    public int UserId { get; set; }
    
    public User? User { get; set; }
    
    public string? UserToken { get; set; }
    
    public DateTime TimeStart { get; set; }
    
    public DateTime TimeEnd { get; set; }
}