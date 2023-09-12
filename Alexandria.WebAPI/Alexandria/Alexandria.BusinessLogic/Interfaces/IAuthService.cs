using Alexandria.Common.DTOs.AuthDTOs;

namespace Alexandria.BusinessLogic.Interfaces;

public interface IAuthService
{
    Task<string> Login(RequestUserLoginDto requestUserLoginDto);

    void Register(RequestUserRegisterDto requestUserRegisterDto);

    Task<bool> IsRegistered(RequestUserCheckDto requestUserCheckDto);
}