using Alexandria.BusinessLogic.Interfaces;
using Alexandria.Common.DTOs.AuthDTOs;
using Alexandria.DAL.Interfaces;
using Alexandria.Models.Models;

namespace Alexandria.BusinessLogic.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IHashService _hashService;
    
    public UserService(IUserRepository userRepository, IHashService hashService)
    {
        _userRepository = userRepository;
        _hashService = hashService;
    }
    
    public User GetUser(UserLoginDto userLoginDto)
    {
        var user = _userRepository.GetUser(userLoginDto);

        if (user != null)
        {
            if (_hashService.VerifyPasswordHash(userLoginDto.Password, user.PasswordSalt, user.PasswordHash))
            {
                return user;
            }
        }

        return new User();
    }
}