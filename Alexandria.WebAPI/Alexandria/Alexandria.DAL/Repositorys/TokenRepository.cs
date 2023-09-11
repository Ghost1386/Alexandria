using Alexandria.Common.DTOs;
using Alexandria.DAL.Interfaces;
using Alexandria.Models;
using Alexandria.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace Alexandria.DAL.Repositorys;

public class TokenRepository : ITokenRepository
{
    private readonly ApplicationContext _applicationContext;
    
    public TokenRepository(ApplicationContext applicationContext)
    {
        _applicationContext = applicationContext;
    }
    
    public async void CreateToken(Token token)
    {
       await _applicationContext.Tokens.AddAsync(token);
       await _applicationContext.SaveChangesAsync();
    }

    public async Task<Token> GetToken(Identifier identifier)
    {
        var token = await _applicationContext.Tokens.FirstOrDefaultAsync(t => t.UserId == identifier.Id);

        return token;
    }

    public async void UpdateToken(Token token)
    {
        _applicationContext.Tokens.Update(token);
        await _applicationContext.SaveChangesAsync();
    }
}