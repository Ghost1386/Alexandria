using Alexandria.Common.DTOs;
using Alexandria.Models.Models;

namespace Alexandria.BusinessLogic.Interfaces;

public interface ITokenService
{
    string CreateToken(User user);
}