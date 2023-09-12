using Alexandria.Common.DTOs;
using Alexandria.Common.DTOs.AuthDTOs;
using Alexandria.Common.Enums;
using Alexandria.Models.Models;

namespace Alexandria.BusinessLogic.Interfaces;

public interface IUserService
{
    Task<User> GetUser(UserLoginDto userLoginDto);

    Task<User> CreateUser(UserRegisterDto userRegisterDto);

    Task<bool> CheckUser(UserCheckDto userCheckDto);

    void ChangeUserRole(Identifier identifier, UserRoleType newUserRoleType);
}