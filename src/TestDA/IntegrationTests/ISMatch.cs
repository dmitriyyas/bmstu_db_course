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
    public class ISMatch
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
            var service = new MatchService(repository);

            var match = service.createMatch(1, 1, 2, 4, 0);

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
            var service = new MatchService(repository);

            var match = new Match(1, 1, 2, 1, 1, 1);

            using (var dbContext = factory.getDbContext())
            {
                dbContext.Matches.Add(match);
                dbContext.SaveChanges();
            }

            match.HomeGoals = 5;
            service.updateMatch(1, 5, 1);
            using (var dbContext = factory.getDbContext())
            {
                compare(match, dbContext.Matches.FirstOrDefault(u => u.Id == 1));
            }
        }

        [TestMethod]
        public void TestGet()
        {
            var factory = new InMemoryDbContextFactory();
            var repository = new MatchRepository(factory);
            var service = new MatchService(repository);

            var match = new Match(1, 1, 2, 1, 1, 1);

            using (var dbContext = factory.getDbContext())
            {
                dbContext.Matches.Add(match);
                dbContext.SaveChanges();
            }

            compare(match, service.getMatch(1));
        }

        [TestMethod]
        public void TestDelete()
        {
            var factory = new InMemoryDbContextFactory();
            var repository = new MatchRepository(factory);
            var service = new MatchService(repository);

            var match = new Match(1, 1, 2, 1, 1, 1);

            using (var dbContext = factory.getDbContext())
            {
                dbContext.Matches.Add(match);
                dbContext.SaveChanges();
            }

            service.deleteMatch(1);
            using (var dbContext = factory.getDbContext())
            {
                Assert.IsNull(dbContext.Matches.FirstOrDefault(m => m.Id == 1));
            }
        }
    }
}
