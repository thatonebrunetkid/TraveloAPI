using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Application.Common;
using Domain.User;
using Infrastructure.Authentication;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.SCA
{
    public class AuthorizationHelpers : IAuthorisationHelpers
    {
        private readonly AuthenticationSettings AuthenticationSettings;
        private readonly IRedisHandler Redis;
        public AuthorizationHelpers(AuthenticationSettings AuthenticationSettings, IRedisHandler Redis)
        {
            this.AuthenticationSettings = AuthenticationSettings;
            this.Redis = Redis;
        }


        public string GenerateToken(int UserId)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, UserId.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AuthenticationSettings.JwtKey));
            var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddMinutes(AuthenticationSettings.JwtExpireMinutes);
            var token = new JwtSecurityToken(AuthenticationSettings.JwtIssuer, AuthenticationSettings.JwtIssuer, claims, expires: expires, signingCredentials: credential);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string GetRefreshToken(string token, int UserId)
        {
            if (new JwtSecurityTokenHandler().ReadJwtToken(token.Replace("Bearer ", string.Empty)).ValidTo.Minute - DateTime.Now.AddMinutes(-1).Minute <= 1)
                return GenerateToken(UserId);
            else
                return token;

        }

        public bool ValidatePropertyAuthorization(string token, int UserId)
        {
            var securityToken = new JwtSecurityTokenHandler().ReadJwtToken(token.Replace("Bearer ", string.Empty));
            return Int32.Parse(securityToken.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value) == UserId;
        }
    }
}

