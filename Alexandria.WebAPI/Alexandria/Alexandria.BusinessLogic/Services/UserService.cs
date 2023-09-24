using Alexandria.BusinessLogic.Interfaces;
using Alexandria.Common.DTOs;
using Alexandria.Common.DTOs.AuthDTOs;
using Alexandria.Common.Enums;
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
    
    public async Task<User> GetUser(RequestUserLoginDto requestUserLoginDto)
    {
        var user = await _userRepository.GetUser(requestUserLoginDto);

        if (user != null)
        {
            if (_hashService.VerifyPasswordHash(requestUserLoginDto.Password, user.PasswordSalt, user.PasswordHash))
            {
                return user;
            }
        }

        return new User();
    }
    
    public async Task<User> GetUser(Identifier identifier)
    {
        var user = await _userRepository.GetUser(identifier);

        return user;
    }
    
    public async Task<User> GetUserByEmail(string email)
    {
        var user = await _userRepository.GetUserByEmail(email);

        return user;
    }

    public async Task<User> CreateUser(RequestUserRegisterDto requestUserRegisterDto)
    {
        _hashService.CreatePasswordHash(requestUserRegisterDto.Password, out byte[] passwordHash, out byte[] passwordSalt);
        
        var user = new User
        {
            Email = requestUserRegisterDto.Email,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt,
            MobileName = requestUserRegisterDto.MobileName,
            DesktopName = requestUserRegisterDto.DesktopName,
            UserRoleType = (int)UserRoleType.User
        };
        
        var newUser = await _userRepository.CreateUser(user);

        return newUser;
    }

    public async Task<bool> CheckUser(RequestUserCheckDto requestUserCheckDto)
    {
        var isRegistered = await _userRepository.CheckUser(requestUserCheckDto);

        return isRegistered;
    }

    public async void ChangeUserRole(Identifier identifier, UserRoleType newUserRoleType)
    {
        var user = await _userRepository.GetUser(identifier);

        user.UserRoleType = (int)newUserRoleType;
        
        _userRepository.ChangeUserRole(user);
    }
}