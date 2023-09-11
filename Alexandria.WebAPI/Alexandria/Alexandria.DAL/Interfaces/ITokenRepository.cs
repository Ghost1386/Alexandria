using Alexandria.Common.DTOs;
using Alexandria.Models.Models;

namespace Alexandria.DAL.Interfaces;

public interface ITokenRepository
{ 
    void CreateToken(Token token);

    Task<Token> GetToken(Identifier identifier);

    void UpdateToken(Token token);
}