using Microsoft.IdentityModel.Tokens;
using Models;
using System;

namespace WebApi.Authentication
{
    public interface ITokenProvider
    {
        string CreateToken(Users user, DateTime expiry);
        TokenValidationParameters GetValidationParameters();
    }
}
