using Alexandria.Common.DTOs.AuthDTOs;
using Alexandria.Models.Models;

namespace Alexandria.BusinessLogic.Interfaces;

public interface IUserService
{
    User GetUser(UserLoginDto userLoginDto);
}