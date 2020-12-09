using DocumentManagement.Models.Entity.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookyBackend.Models.Entity.ViewModel
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public int Gender { get; set; }
        public int isVip { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public int StatusPayment { get; set; }
        public int CreatedUser { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifiedUser { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int Deleted { get; set; }
        public Token Token { get; set; }

    }
}
