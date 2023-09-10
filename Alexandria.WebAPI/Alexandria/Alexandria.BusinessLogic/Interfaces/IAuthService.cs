using Alexandria.Common.DTOs.AuthDTOs;

namespace Alexandria.BusinessLogic.Interfaces;

public interface IAuthService
{
    string Login(UserLoginDto userLoginDto);
}