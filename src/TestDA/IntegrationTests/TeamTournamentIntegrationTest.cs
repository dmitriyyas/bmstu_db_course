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
    public class TeamTournamentIntegrationTest
    {
        private void compare(TeamTournament x, TeamTournament y)
        {
            Assert.AreEqual(x.TeamId, y.TeamId);
            Assert.AreEqual(x.TournamentId, y.TournamentId);
        }

        [TestMethod]
        public void TestCreate()
        {
            var factory = new InMemoryDbContextFactory();
            var repository = new TeamTournamentRepository(factory);

            var tt = new TeamTournament(1, 2);

            repository.create(tt);
            using (var dbContext = factory.getDbContext())
            {
                compare(tt, dbContext.TeamTournaments.FirstOrDefault(u => u.TeamId == 1 && u.TournamentId == 2));
            }
        }

        [TestMethod]
        public void TestGet()
        {
            var factory = new InMemoryDbContextFactory();
            var repository = new TeamTournamentRepository(factory);

            var tt = new TeamTournament(1, 2);

            using (var dbContext = factory.getDbContext())
            {
                dbContext.TeamTournaments.Add(tt);
                dbContext.SaveChanges();
            }

            compare(tt, repository.get(1, 2));
        }
    }
}
