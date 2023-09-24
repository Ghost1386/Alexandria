namespace Alexandria.Common.DTOs.PaymentDTOs;

public class RequestPaymentDtos
{
    public string? UserToken { get; set; }
    
    public string? Nonce { get; set; }
}