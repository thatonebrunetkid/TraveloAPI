﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.User
{
    public class UsersDto
    {
        public ICollection<UserDTO> Users { get; set; }
    }
}
