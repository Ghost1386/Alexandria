using Braintree;

namespace Alexandria.BusinessLogic.Interfaces;

public interface IBraintreeService
{
    IBraintreeGateway CreateGateway();
    
    IBraintreeGateway GetGateway();
}