using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Application.Common;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Domain.User;
using Infrastructure.Authentication;
using Infrastructure.Azure;
using Infrastructure.Azure.Configuration;
using Infrastructure.Cache;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.SCA
{
    public class AuthorizationHelpers : IAuthorisationHelpers
    {
        private readonly AuthenticationSettings AuthenticationSettings;
        private readonly IConfiguration configuration;
        public AuthorizationHelpers(AuthenticationSettings AuthenticationSettings, IConfiguration configuration)
        {
            this.AuthenticationSettings = AuthenticationSettings;
            this.configuration = configuration;
        }


        public string GenerateToken(int UserId)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, UserId.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AuthenticationSettings.JwtKey));
            var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddHours(AuthenticationSettings.JwtExpireHours);
            var token = new JwtSecurityToken(AuthenticationSettings.JwtIssuer, AuthenticationSettings.JwtIssuer, claims, expires: expires, signingCredentials: credential);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public bool ValidatePropertyAuthorization(string token, int UserId)
        {
            var securityToken = new JwtSecurityTokenHandler().ReadJwtToken(token.Replace("Bearer ", string.Empty));
            return Int32.Parse(securityToken.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value) == UserId;
        }
    }
}

