using Alexandria.Common.DTOs.AuthDTOs;
using Alexandria.Models.Models;

namespace Alexandria.DAL.Interfaces;

public interface IUserRepository
{
    Task<User> GetUser(UserLoginDto userLoginDto);

    Task<User> CreateUser(User user);
}