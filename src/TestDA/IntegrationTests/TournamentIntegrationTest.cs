using DataAccess.Repositories;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Models;

namespace TestDA.IntegrationTests
{
    public class TournamentIntegrationTest
    {
        private void compare(Tournament x, Tournament y)
        {
            Assert.AreEqual(x.Id, y.Id);
            Assert.AreEqual(x.Name, y.Name);
            Assert.AreEqual(x.CountryId, y.CountryId);
            Assert.AreEqual(x.UserId, y.UserId);
        }
        [TestMethod]
        public void TestCreate()
        {
            var factory = new InMemoryDbContextFactory();
            var repository = new TournamentRepository(factory);

            var tournament = new Tournament("RPL", 1, 1);

            repository.create(tournament);
            using (var dbContext = factory.getDbContext())
            {
                compare(tournament, dbContext.Tournaments.FirstOrDefault(u => u.Id == 1));
            }
        }

        [TestMethod]
        public void TestGetById()
        {
            var factory = new InMemoryDbContextFactory();
            var repository = new TournamentRepository(factory);

            var tournament = new Tournament("RPL", 1, 1, 1);

            using (var dbContext = factory.getDbContext())
            {
                dbContext.Tournaments.Add(tournament);
                dbContext.SaveChanges();
            }

            compare(tournament, repository.getById(1));
        }

        [TestMethod]
        public void TestDelete()
        {
            var factory = new InMemoryDbContextFactory();
            var repository = new TournamentRepository(factory);

            var tournament = new Tournament("RPL", 1, 1, 1);

            using (var dbContext = factory.getDbContext())
            {
                dbContext.Tournaments.Add(tournament);
                dbContext.SaveChanges();
            }

            repository.delete(1);
            using (var dbContext = factory.getDbContext())
            {
                Assert.IsNull(dbContext.Matches.FirstOrDefault(m => m.Id == 1));
            }
        }
    }
}
