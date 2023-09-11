using Alexandria.Common.DTOs.AuthDTOs;

namespace Alexandria.BusinessLogic.Interfaces;

public interface IAuthService
{
    Task<string> Login(UserLoginDto userLoginDto);

    void Register(UserRegisterDto userRegisterDto);

    Task<bool> IsRegistered(UserCheckDto userCheckDto);
}