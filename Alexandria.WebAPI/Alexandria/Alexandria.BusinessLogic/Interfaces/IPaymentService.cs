using Alexandria.Common.DTOs;
using Alexandria.Common.DTOs.PaymentDTOs;
using Braintree;

namespace Alexandria.BusinessLogic.Interfaces;

public interface IPaymentService
{
    Result<Transaction> Pay(RequestPaymentDtos requestPaymentDtos);

    void CreatePayment(RequestPaymentDtos requestPaymentDtos, Identifier identifier);
}