using Alexandria.Common.DTOs.AuthDTOs;
using Alexandria.DAL.Interfaces;
using Alexandria.Models;
using Alexandria.Models.Models;

namespace Alexandria.DAL.Repositorys;

public class UserRepository : IUserRepository
{
    private readonly ApplicationContext _applicationContext;
    
    public UserRepository(ApplicationContext applicationContext)
    {
        _applicationContext = applicationContext;
    }
    
    public User GetUser(UserLoginDto userLoginDto)
    {
        var user = _applicationContext.Users.FirstOrDefault(u => u.Email == userLoginDto.Email);

        return user;
    }
}