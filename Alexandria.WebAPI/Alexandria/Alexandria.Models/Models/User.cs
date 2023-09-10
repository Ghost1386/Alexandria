namespace Alexandria.Models.Models;

public class User
{
    public int UserId { get; set; }
    
    public string? Email { get; set; }
    
    public byte[]? PasswordHash { get; set; }
    
    public byte[]? PasswordSalt { get; set; }
    
    public string? IpAddress { get; set; }
    
    public string? MobileName { get; set; }
    
    public string? DesktopName { get; set; }
}