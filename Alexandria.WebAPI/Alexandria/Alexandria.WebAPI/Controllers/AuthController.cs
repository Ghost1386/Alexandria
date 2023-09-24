using System.Security.Claims;
using System.Text.Json;
using Alexandria.BusinessLogic.Interfaces;
using Alexandria.Common.DTOs;
using Alexandria.Common.DTOs.AuthDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Alexandria.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly ILogger<AuthController> _logger;
    private readonly IAuthService _authService;
    
    public AuthController(ILogger<AuthController> logger, IAuthService authService)
    {
        _logger = logger;
        _authService = authService;
    }
    
    [AllowAnonymous]
    [HttpPost("/auth/login")]
    public async Task<IActionResult> Login([FromForm] RequestUserLoginDto requestUserLoginDto)
    {
        try
        {
            var token = await _authService.Login(requestUserLoginDto);

            if (!string.IsNullOrEmpty(token))
            {
                var jsonToken = JsonSerializer.Serialize(token);
            
                _logger.LogInformation($"{DateTime.UtcNow}: User with email {requestUserLoginDto.Email} is sing in");
            
                return Ok(jsonToken);
            }

            return Unauthorized();
        }
        catch (Exception e)
        {
            _logger.LogError($"{DateTime.UtcNow}: {e.Message}");

            return BadRequest();
        }
    }
    
    [AllowAnonymous]
    [HttpPost("/auth/register")]
    public async Task<IActionResult> Register([FromForm] RequestUserRegisterDto requestUserRegisterDto)
    {
        try
        {
            var requestUserCheckDto = new RequestUserCheckDto
            {
                Email = requestUserRegisterDto.Email
            };

            if (!await _authService.IsRegistered(requestUserCheckDto))
            {
                _authService.Register(requestUserRegisterDto);

                _logger.LogInformation($"{DateTime.UtcNow}: Registered new user with email {requestUserRegisterDto.Email}");

                return Ok();
            }

            return BadRequest();
        }
        catch (Exception e)
        {
            _logger.LogError($"{DateTime.UtcNow}: {e.Message}");

            return BadRequest();
        }
    }
    
    [AllowAnonymous]
    [HttpPost("/auth/getUserIdentifier")]
    public Identifier GetUserIdentifier()
    {
        var identifier = new Identifier
        {
            Id = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier))
        };

        return identifier;
    }
    
    [AllowAnonymous]
    [HttpPost("/auth/getUserEmail")]
    public string GetUserEmail()
    {
        var email = Convert.ToString(User.FindFirstValue(ClaimTypes.Email));

        return email;
    }
}