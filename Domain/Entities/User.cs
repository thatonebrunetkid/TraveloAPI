using Domain.Common;
using System;


namespace Domain.Entities
{
    public class User : BaseDomainEntityDateCreated
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime PasswordDateUpdated { get; set; }
        public DateTime? LastLogin { get; set; }
    }
}
