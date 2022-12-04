using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Identity.DTOs
{
    public class AuthResponse
    {
        public string Id { get; set; }
        public string Token { get; set; }
    }
}
