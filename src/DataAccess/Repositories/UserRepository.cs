using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.RepositoryInterfaces;
using BL.Models;
using DataAccess.DBContext;

namespace DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DbContextFactory _dbContextFactory;

        public UserRepository(DbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public void create(User user)
        {
            var dbContext = _dbContextFactory.getDbContext();
            try
            {
                if (dbContext.Users.Count() > 0)
                    user.Id = dbContext.Users.Select(x => x.Id).Max() + 1;
                else
                    user.Id = 1;

                dbContext.Users.Add(user);
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при добавлении пользователя.");
            }
        }

        public IEnumerable<User> getAll()
        {
            var dbContext = _dbContextFactory.getDbContext();

            return dbContext.Users.ToList();
        }

        public User getById(int id)
        {
            var dbContext = _dbContextFactory.getDbContext();

            return dbContext.Users.FirstOrDefault(u => u.Id == id);
        }

        public User getByLogin(string login)
        {
            var dbContext = _dbContextFactory.getDbContext();

            return dbContext.Users.FirstOrDefault(u => u.Login == login);
        }

        public void update(User user)
        {
            var dbContext = _dbContextFactory.getDbContext();

            try
            {
                dbContext.Users.Update(user);
                dbContext.SaveChanges();
            }
            catch(Exception ex) 
            {
                throw new Exception("Ошибка при обновлении пользователя.");
            }
        }
    }
}
