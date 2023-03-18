using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Models;

namespace BL.RepositoryInterfaces
{
    public interface IUserRepository
    {
        void create(User user);

        User getById(int id);

        User getByLogin(string login);
        void update(User user);
        IEnumerable<User> getAll();
    }
}
