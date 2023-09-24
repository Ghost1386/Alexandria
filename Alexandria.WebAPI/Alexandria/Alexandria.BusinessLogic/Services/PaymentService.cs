using Alexandria.BusinessLogic.Interfaces;
using Alexandria.Common.DTOs;
using Alexandria.Common.DTOs.PaymentDTOs;
using Alexandria.DAL.Interfaces;
using Alexandria.Models.Models;
using Braintree;

namespace Alexandria.BusinessLogic.Services;

public class PaymentService : IPaymentService
{
    private readonly IBraintreeService _braintreeService;
    private readonly IPaymentRepository _paymentRepository;

    public PaymentService(IBraintreeService braintreeService, IPaymentRepository paymentRepository)
    {
        _braintreeService = braintreeService;
        _paymentRepository = paymentRepository;
    }

    public Result<Transaction> Pay(RequestPaymentDtos requestPaymentDtos)
    {
        var gateway = _braintreeService.GetGateway();
        
        var transactionRequest = new TransactionRequest
        {
            Amount = Convert.ToDecimal("4.99"),
            PaymentMethodNonce = requestPaymentDtos.Nonce,
            Options = new TransactionOptionsRequest
            {
                SubmitForSettlement = true
            }
        };
        
        var result = gateway.Transaction.Sale(transactionRequest);

        return result;
    }

    public void CreatePayment(RequestPaymentDtos requestPaymentDtos, Identifier identifier)
    {
        var payment = new Payment
        {
            UserId = identifier.Id,
            UserToken = requestPaymentDtos.UserToken,
            DateTime = DateTime.UtcNow
        };
        
        _paymentRepository.CreatePayment(payment);
    }
}