using Alexandria.Common.DTOs.AuthDTOs;
using Alexandria.Models.Models;

namespace Alexandria.BusinessLogic.Interfaces;

public interface IUserService
{
    Task<User> GetUser(UserLoginDto userLoginDto);

    Task<User> CreateUser(UserRegisterDto userRegisterDto);
}