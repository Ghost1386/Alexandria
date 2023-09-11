using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Alexandria.BusinessLogic.Interfaces;
using Alexandria.Common.DTOs;
using Alexandria.DAL.Interfaces;
using Alexandria.Models.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Alexandria.BusinessLogic.Services;

public class TokenService : ITokenService
{
    private readonly IConfiguration _configuration;
    private readonly ITokenRepository _tokenRepository;
    
    public TokenService(IConfiguration configuration, ITokenRepository tokenRepository)
    {
        _configuration = configuration;
        _tokenRepository = tokenRepository;
    }
    
    public void CreateToken(User user)
    {
        var userToken = GenerateToken(user);

        var token = new Token
        {
            UserId = user.UserId,
            UserToken = userToken,
            TimeStart = DateTime.UtcNow,
            TimeEnd = DateTime.UtcNow.AddMonths(1)
        };
        
        _tokenRepository.CreateToken(token);
    }

    public async Task<Token> GetToken(Identifier identifier)
    {
        var token = await _tokenRepository.GetToken(identifier);

        return token;
    }

    public async Task<string> UpdateToken(User user)
    {
        var identifier = new Identifier
        {
            Id = user.UserId
        };
        
        var token = await _tokenRepository.GetToken(identifier);

        token.UserToken = GenerateToken(user);
        token.TimeStart = DateTime.UtcNow;
        token.TimeEnd = DateTime.UtcNow.AddMonths(1);
        
        _tokenRepository.UpdateToken(token);

        return token.UserToken;
    }

    private string GenerateToken(User user)
    {
        var claims = new[] {
            new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString(CultureInfo.CurrentCulture)),
            new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim("MobileName", user.MobileName),
            new Claim("DesktopName", user.DesktopName)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var tokenSettings = new JwtSecurityToken(
            _configuration["Jwt:Issuer"],
            _configuration["Jwt:Audience"],
            claims,
            expires: DateTime.UtcNow.AddMonths(1),
            signingCredentials: signIn);

        return new JwtSecurityTokenHandler().WriteToken(tokenSettings);
    }
}