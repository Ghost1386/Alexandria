using Alexandria.Common.DTOs;
using Alexandria.Common.DTOs.AuthDTOs;
using Alexandria.Models.Models;

namespace Alexandria.DAL.Interfaces;

public interface IUserRepository
{
    Task<User> GetUser(UserLoginDto userLoginDto);

    Task<User> GetUser(Identifier identifier);

    Task<User> CreateUser(User user);

    Task<bool> CheckUser(UserCheckDto userCheckDto);

    void ChangeUserRole(User user);
}