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

    public async void Register(UserRegisterDto userRegisterDto)
    {
        var user = await _userService.CreateUser(userRegisterDto);
        
        _tokenService.CreateToken(user);
    }
    
    public async Task<string> Login(UserLoginDto userLoginDto)
    {
        var user = await _userService.GetUser(userLoginDto);

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

    public async Task<bool> IsRegistered(UserCheckDto userCheckDto)
    {
        var isRegistered = await _userService.CheckUser(userCheckDto);

        return isRegistered;
    }
}