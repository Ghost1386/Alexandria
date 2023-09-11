using Alexandria.BusinessLogic.Interfaces;
using Alexandria.Common.DTOs.AuthDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Alexandria.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly Logger<AuthController> _logger;
    private readonly IAuthService _authService;
    
    public AuthController(Logger<AuthController> logger, IAuthService authService)
    {
        _logger = logger;
        _authService = authService;
    }
    
    [AllowAnonymous]
    [HttpPost("/auth/login")]
    public async Task<IActionResult> Login(UserLoginDto userLoginDto)
    {
        var token = await _authService.Login(userLoginDto);

        if (!string.IsNullOrEmpty(token))
        {
            _logger.LogInformation($"{DateTime.UtcNow}: User with email {userLoginDto.Email} is sing in");
            
            return Ok(token);
        }

        return Unauthorized();
    }
    
    [AllowAnonymous]
    [HttpPost("/auth/register")]
    public async Task<IActionResult> Register(UserRegisterDto userRegisterDto)
    {
        var userCheckDto = new UserCheckDto
        {
            Email = userRegisterDto.Email
        };

        if (!await _authService.IsRegistered(userCheckDto))
        {
            _authService.Register(userRegisterDto);

            _logger.LogInformation($"{DateTime.UtcNow}: Registered new user with email {userRegisterDto.Email}");

            return Ok();
        }

        return BadRequest();
    }
}