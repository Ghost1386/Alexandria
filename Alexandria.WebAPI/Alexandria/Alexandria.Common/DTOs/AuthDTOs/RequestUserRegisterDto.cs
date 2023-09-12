namespace Alexandria.Common.DTOs.AuthDTOs;

public class RequestUserRegisterDto
{
    public string? Email { get; set; }
    
    public string? Password { get; set; }
    
    public string? MobileName { get; set; }
    
    public string? DesktopName { get; set; }
}