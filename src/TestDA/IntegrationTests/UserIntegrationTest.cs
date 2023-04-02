using BL.Models;
using DataAccess.Repositories;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Services;

namespace TestDA.IntegrationTests
{
    [TestClass]
    public class UserIntegrationTest
    {
        private void compare(User x, User y)
        {
            Assert.AreEqual(x.Id, y.Id);
            Assert.AreEqual(x.Login, y.Login);
            Assert.AreEqual(x.Permission, y.Permission);
        }

        [TestMethod]
        public void TestCreate()
        {
            var factory = new InMemoryDbContextFactory();
            var userRepository = new UserRepository(factory);

            string login = "login";
            string password = BCrypt.Net.BCrypt.HashPassword("password");
            User user = new User(login, password);

            userRepository.create(user);
            using (var dbContext = factory.getDbContext())
            {
                compare(user, dbContext.Users.FirstOrDefault(u => u.Login == login));
            }
        }
        [TestMethod]

        public void TestUpdate()
        {
            var factory = new InMemoryDbContextFactory();
            var userRepository = new UserRepository(factory);

            string login = "login";
            User user = new User(login, "password", "user");

            using (var dbContext = factory.getDbContext())
            {
                dbContext.Users.Add(user);
                dbContext.SaveChanges();
            }

            user.Permission = "admin";

            userRepository.update(user);
            using (var dbContext = factory.getDbContext())
            {
                compare(user, dbContext.Users.FirstOrDefault(u => u.Login == login));
            }
        }

        [TestMethod]
        public void TestGetByLogin()
        {
            var factory = new InMemoryDbContextFactory();
            var userRepository = new UserRepository(factory);

            string login = "login";
            User user = new User(login, "password", "user");

            using (var dbContext = factory.getDbContext())
            {
                dbContext.Users.Add(user);
                dbContext.SaveChanges();
            }

            compare(user, userRepository.getByLogin("login"));
        }
    }
}
