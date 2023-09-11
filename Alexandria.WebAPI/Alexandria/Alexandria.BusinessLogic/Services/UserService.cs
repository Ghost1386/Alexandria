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
    
    public async Task<User> GetUser(UserLoginDto userLoginDto)
    {
        var user = await _userRepository.GetUser(userLoginDto);

        if (user != null)
        {
            if (_hashService.VerifyPasswordHash(userLoginDto.Password, user.PasswordSalt, user.PasswordHash))
            {
                return user;
            }
        }

        return new User();
    }

    public async Task<User> CreateUser(UserRegisterDto userRegisterDto)
    {
        _hashService.CreatePasswordHash(userRegisterDto.Password, out byte[] passwordHash, out byte[] passwordSalt);
        
        var user = new User
        {
            Email = userRegisterDto.Email,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt,
            MobileName = userRegisterDto.MobileName,
            DesktopName = userRegisterDto.DesktopName
        };
        
        var newUser = await _userRepository.CreateUser(user);

        return newUser;
    }

    public async Task<bool> CheckUser(UserCheckDto userCheckDto)
    {
        var isRegistered = await _userRepository.CheckUser(userCheckDto);

        return isRegistered;
    }
}