using Alexandria.Common.DTOs.AuthDTOs;
using Alexandria.Models.Models;

namespace Alexandria.DAL.Interfaces;

public interface IUserRepository
{
    User GetUser(UserLoginDto userLoginDto);
}