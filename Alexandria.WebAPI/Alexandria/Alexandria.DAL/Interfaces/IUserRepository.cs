using Alexandria.Common.DTOs;
using Alexandria.Common.DTOs.AuthDTOs;
using Alexandria.Models.Models;

namespace Alexandria.DAL.Interfaces;

public interface IUserRepository
{
    Task<User> GetUser(RequestUserLoginDto requestUserLoginDto);

    Task<User> GetUser(Identifier identifier);

    Task<User> CreateUser(User user);

    Task<bool> CheckUser(RequestUserCheckDto requestUserCheckDto);

    void ChangeUserRole(User user);
}