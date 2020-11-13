﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSBackend.Models.DTO
{
    public class UserDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; }
    }

    public class UserSelect2DTO
    {
        public string UserName { get; set; }
        public int UserID { get; set; }
    }
}
