using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alexandria.Models.Models;

public class User
{
    [Key]
    public int UserId { get; set; }
    
    public string? Email { get; set; }
    
    public byte[]? PasswordHash { get; set; }
    
    public byte[]? PasswordSalt { get; set; }
    
    public string? MobileName { get; set; }
    
    public string? DesktopName { get; set; }
    
    public int UserRoleType { get; set; }
    
    public List<Modification>? Modifications { get; set; }
}