using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string PasswordHash { get; set; }
        public string Permission { get;set ; }

        public User(string login, string passwordHash, string permission = "user", int id = 1)
        {
            Id = id;
            Login = login;
            PasswordHash = passwordHash;
            Permission = permission;
        }

        public bool verify(string password)
        {
            return BCrypt.Net.BCrypt.Verify(password, PasswordHash);
        }
    }
}
