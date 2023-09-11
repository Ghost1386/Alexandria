using Alexandria.Common.DTOs.AuthDTOs;

namespace Alexandria.BusinessLogic.Interfaces;

public interface IAuthService
{
    Task<string> Login(UserLoginDto userLoginDto);
}