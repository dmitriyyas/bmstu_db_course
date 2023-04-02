using BL.Models;
using DataAccess.Repositories;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDA.IntegrationTests
{
    [TestClass]
    public class MatchIntegrationTest
    {
        private void compare(Match x, Match y)
        {
            Assert.AreEqual(x.Id, y.Id);
            Assert.AreEqual(x.TournamentId, y.TournamentId);
            Assert.AreEqual(x.HomeGoals, y.HomeGoals);
            Assert.AreEqual(x.GuestGoals, y.GuestGoals);
            Assert.AreEqual(x.GuestTeamId, y.GuestTeamId);
            Assert.AreEqual(x.HomeTeamId, y.HomeTeamId);
        }
        [TestMethod]
        public void TestCreate()
        {
            var factory = new InMemoryDbContextFactory();
            var repository = new MatchRepository(factory);

            var match = new Match(1, 1, 2, 1, 1);

            repository.create(match);
            using (var dbContext = factory.getDbContext())
            {
                compare(match, dbContext.Matches.FirstOrDefault(u => u.Id == 1));
            }
        }
        [TestMethod]

        public void TestUpdate()
        {
            var factory = new InMemoryDbContextFactory();
            var repository = new MatchRepository(factory);

            var match = new Match(1, 1, 2, 1, 1, 1);

            using (var dbContext = factory.getDbContext())
            {
                dbContext.Matches.Add(match);
                dbContext.SaveChanges();
            }

            match.HomeGoals = 5;

            repository.update(match);
            using (var dbContext = factory.getDbContext())
            {
                compare(match, dbContext.Matches.FirstOrDefault(u => u.Id == 1));
            }
        }

        [TestMethod]
        public void TestGetById()
        {
            var factory = new InMemoryDbContextFactory();
            var repository = new MatchRepository(factory);

            var match = new Match(1, 1, 2, 1, 1, 1);

            using (var dbContext = factory.getDbContext())
            {
                dbContext.Matches.Add(match);
                dbContext.SaveChanges();
            }

            compare(match, repository.getById(1));
        }

        [TestMethod]
        public void TestDelete()
        {
            var factory = new InMemoryDbContextFactory();
            var repository = new MatchRepository(factory);

            var match = new Match(1, 1, 2, 1, 1, 1);

            using (var dbContext = factory.getDbContext())
            {
                dbContext.Matches.Add(match);
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
