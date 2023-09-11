using Alexandria.Common.DTOs.AuthDTOs;
using Alexandria.DAL.Interfaces;
using Alexandria.Models;
using Alexandria.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace Alexandria.DAL.Repositorys;

public class UserRepository : IUserRepository
{
    private readonly ApplicationContext _applicationContext;
    
    public UserRepository(ApplicationContext applicationContext)
    {
        _applicationContext = applicationContext;
    }
    
    public async Task<User> GetUser(UserLoginDto userLoginDto)
    {
        var user = await _applicationContext.Users.FirstOrDefaultAsync(u => u.Email == userLoginDto.Email);

        return user;
    }

    public async Task<User> CreateUser(User user)
    {
        await _applicationContext.Users.AddAsync(user);
        await _applicationContext.SaveChangesAsync();

        return user;
    }
    
    public async Task<bool> CheckUser(UserCheckDto userCheckDto)
    {
        var isRegistered = await _applicationContext.Users.AnyAsync(u => u.Email == userCheckDto.Email);

        return isRegistered;
    }
}