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
    public class ISUser
    {
        private void compare(User x, User y)
        {
            Assert.AreEqual(x.Id, y.Id);
            Assert.AreEqual(x.Login, y.Login);
            Assert.AreEqual(x.Permission, y.Permission);
        }

        [TestMethod]
        public void TestRegister()
        {
            var factory = new InMemoryDbContextFactory();
            var userRepository = new UserRepository(factory);
            var tournamentRepository = new TournamentRepository(factory);
            var userService = new UserService(userRepository, tournamentRepository);

            string login = "login";
            string password = "password";
            User user = userService.register(login, password);

            using (var dbContext = factory.getDbContext())
            {
                compare(user, dbContext.Users.FirstOrDefault(u => u.Login == login));
            }

            user = userService.logIn(login, password);
            using (var dbContext = factory.getDbContext())
            {
                compare(user, dbContext.Users.FirstOrDefault(u => u.Login == login));
            }
        }
    }
}
