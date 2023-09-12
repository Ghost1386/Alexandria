using Alexandria.Common.DTOs;
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
    
    public async Task<User> GetUser(RequestUserLoginDto requestUserLoginDto)
    {
        var user = await _applicationContext.Users.FirstOrDefaultAsync(u => u.Email == requestUserLoginDto.Email);

        return user;
    }
    
    public async Task<User> GetUser(Identifier identifier)
    {
        var user = await _applicationContext.Users.FirstOrDefaultAsync(u => u.UserId == identifier.Id);

        return user;
    }

    public async Task<User> CreateUser(User user)
    {
        await _applicationContext.Users.AddAsync(user);
        await _applicationContext.SaveChangesAsync();

        return user;
    }
    
    public async Task<bool> CheckUser(RequestUserCheckDto requestUserCheckDto)
    {
        var isRegistered = await _applicationContext.Users.AnyAsync(u => u.Email == requestUserCheckDto.Email);

        return isRegistered;
    }

    public async void ChangeUserRole(User user)
    {
        _applicationContext.Update(user);
        await _applicationContext.SaveChangesAsync();
    }
}