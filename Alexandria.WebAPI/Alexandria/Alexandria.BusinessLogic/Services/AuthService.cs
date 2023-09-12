using Alexandria.BusinessLogic.Interfaces;
using Alexandria.Common.DTOs;
using Alexandria.Common.DTOs.AuthDTOs;

namespace Alexandria.BusinessLogic.Services;

public class AuthService : IAuthService
{
    private readonly IUserService _userService;
    private readonly ITokenService _tokenService;
    
    public AuthService(IUserService userService, ITokenService tokenService)
    {
        _userService = userService;
        _tokenService = tokenService;
    }

    public async void Register(RequestUserRegisterDto requestUserRegisterDto)
    {
        var user = await _userService.CreateUser(requestUserRegisterDto);
        
        _tokenService.CreateToken(user);
    }
    
    public async Task<string> Login(RequestUserLoginDto requestUserLoginDto)
    {
        var user = await _userService.GetUser(requestUserLoginDto);

        if (user != null)
        {
            var identifier = new Identifier
            {
                Id = user.UserId
            };

            var token = await _tokenService.GetToken(identifier);

            if (DateTime.UtcNow > token.TimeEnd)
            {
                token.UserToken = await _tokenService.UpdateToken(user);
            }

            return token.UserToken;
        }

        return string.Empty;
    }

    public async Task<bool> IsRegistered(RequestUserCheckDto requestUserCheckDto)
    {
        var isRegistered = await _userService.CheckUser(requestUserCheckDto);

        return isRegistered;
    }
}