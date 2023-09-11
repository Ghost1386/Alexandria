﻿using Alexandria.Common.DTOs;
using Alexandria.Models.Models;

namespace Alexandria.BusinessLogic.Interfaces;

public interface ITokenService
{
    void CreateToken(User user);

    Task<Token> GetToken(Identifier identifier);

    Task<string> UpdateToken(User user);
}