using BL.Models;
using BL.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBL.Mocks
{
    public class UserMock : Mock, IUserRepository
    {
        public void create(User user)
        {
            users.Add(user);
        }

        public IEnumerable<User> getAll()
        {
            return users;
        }

        public User getById(int id)
        {
            return users.FirstOrDefault(u => u.Id == id);
        }

        public User getByLogin(string login)
        {
            return users.FirstOrDefault(u => u.Login == login);
        }

        public void update(User user)
        {
            users.RemoveAll(u => u.Id == user.Id);
            users.Add(user);
        }
    }
}
