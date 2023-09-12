using Alexandria.Common.DTOs;
using Alexandria.Common.DTOs.AuthDTOs;
using Alexandria.Common.Enums;
using Alexandria.Models.Models;

namespace Alexandria.BusinessLogic.Interfaces;

public interface IUserService
{
    Task<User> GetUser(RequestUserLoginDto requestUserLoginDto);

    Task<User> GetUser(Identifier identifier);

    Task<User> CreateUser(RequestUserRegisterDto requestUserRegisterDto);

    Task<bool> CheckUser(RequestUserCheckDto userCheckDto);

    void ChangeUserRole(Identifier identifier, UserRoleType newUserRoleType);
}