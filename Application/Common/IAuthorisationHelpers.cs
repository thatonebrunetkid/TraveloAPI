using System;
using Domain.User;

namespace Application.Common
{
    public interface IAuthorisationHelpers
    {
        string GenerateToken(int UserId);
        string GetRefreshToken(string token, int UserId);
        bool ValidatePropertyAuthorization(string token, int UserId);
    }
}

