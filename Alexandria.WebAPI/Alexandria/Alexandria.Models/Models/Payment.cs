namespace Alexandria.Models.Models;

public class Payment
{
    public int PaymentId { get; set; }
    
    public int UserId { get; set; }
    
    public string? UserPaymentToken { get; set; }
    
    public DateTime DateTime { get; set; }
}