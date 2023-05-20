using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.RepositoryInterfaces;
using BL.Models;
using MongoDB.Driver;
using MongoDbDataAccess;

namespace MongoDbDataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly CollectionsFactory _collectionsFactory;

        public UserRepository(CollectionsFactory collectionsFactory)
        {
            _collectionsFactory = collectionsFactory;
        }

        public void create(User user)
        {
            try
            {
                var users = _collectionsFactory.getUserCollection();

                if (users.CountDocuments(_ => true) > 0)
                    user.Id = users.AsQueryable().Select(x => x.Id).Max() + 1;
                else
                    user.Id = 1;

                users.InsertOne(user);
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при добавлении пользователя.");
            }
        }

        public IEnumerable<User> getAll()
        {
            var users = _collectionsFactory.getUserCollection();

            return users.Find(_ => true).ToList();
        }

        public User getById(int id)
        {
            var users = _collectionsFactory.getUserCollection();

            return users.Find(u => u.Id == id).FirstOrDefault();
        }

        public User getByLogin(string login)
        {
            var users = _collectionsFactory.getUserCollection();

            return users.Find(u => u.Login == login).FirstOrDefault();
        }

        public void update(User user)
        {
            try
            {
                var users = _collectionsFactory.getUserCollection();

                users.ReplaceOne(u => u.Id == user.Id, user);
            }
            catch(Exception ex) 
            {
                throw new Exception("Ошибка при обновлении пользователя.");
            }
        }
    }
}
