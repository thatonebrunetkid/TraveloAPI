using System;
namespace Domain.User.DTO
{
    public class LoginResponseDTO
    {
        public int UserId { get; set; }
        public string BearerToken { get; set; }
    }
}

