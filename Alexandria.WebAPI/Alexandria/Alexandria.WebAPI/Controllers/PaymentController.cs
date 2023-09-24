using Alexandria.BusinessLogic.Interfaces;
using Alexandria.Common.DTOs.PaymentDTOs;
using Alexandria.Common.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Alexandria.WebAPI.Controllers;

public class PaymentController : ControllerBase
{
    private readonly ILogger<PaymentController> _logger;
    private readonly IBraintreeService _braintreeService;
    private readonly IPaymentService _paymentService;
    private readonly AuthController _authController;
    private readonly IUserService _userService;

    public PaymentController(ILogger<PaymentController> logger, IBraintreeService braintreeService, 
        IPaymentService paymentService, AuthController authController, IUserService userService)
    {
        _logger = logger;
        _braintreeService = braintreeService;
        _paymentService = paymentService;
        _authController = authController;
        _userService = userService;
    }

    public IActionResult Get()
    {
        var braintreeGateway = _braintreeService.GetGateway();
        
        var clientToken = braintreeGateway.ClientToken.Generate();

        return Ok(clientToken);
    }

    public IActionResult Create(RequestPaymentDtos requestPaymentDtos)
    {
        try
        {
            var result = _paymentService.Pay(requestPaymentDtos);

            if (result.IsSuccess())
            {
                _logger.LogInformation($"{DateTime.UtcNow}: User with email {_authController.GetUserEmail()} " +
                                       $"created payment {requestPaymentDtos.UserToken}");

                var identifier = _authController.GetUserIdentifier();
                
                _paymentService.CreatePayment(requestPaymentDtos, identifier);
                
                _userService.ChangeUserRole(identifier, UserRoleType.Premium);
                
                return Ok();
            }

            return BadRequest(result.Errors);
        }
        catch (Exception e)
        {
            _logger.LogError($"{DateTime.UtcNow}: {e.Message}");

            return BadRequest();
        }
    }
}