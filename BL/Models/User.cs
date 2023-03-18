using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Permission { get;set ; }

        public User(string login, string password, string permission = "authorized", int id = 1)
        {
            Id = id;
            Login = login;
            Password = password;
            Permission = permission;
        }
    }
}
