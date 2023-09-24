using Alexandria.BusinessLogic.Interfaces;
using Braintree;
using Microsoft.Extensions.Configuration;

namespace Alexandria.BusinessLogic.Services;

public class BraintreeService : IBraintreeService
{
    private readonly IConfiguration _configuration;

    public BraintreeService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public IBraintreeGateway CreateGateway()
    {
        var braintreeGateway = new BraintreeGateway()
        {
            Environment = Braintree.Environment.SANDBOX,
            MerchantId = _configuration.GetValue<string>("BraintreeGateway:MerchantId"),
            PublicKey = _configuration.GetValue<string>("BraintreeGateway:PublicKey"),
            PrivateKey = _configuration.GetValue<string>("BraintreeGateway:PrivateKey")
        };

        return braintreeGateway;
    }

    public IBraintreeGateway GetGateway()
    {
        return CreateGateway();
    }
}