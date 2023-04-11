using DataAccess.Repositories;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Models;
using BL.Services;
using BL.RepositoryInterfaces;

namespace TestDA.IntegrationTests
{
    public class ISTournament
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
            var tournamentRepository = new TournamentRepository(factory);
            var teamRepository = new TeamRepository(factory);
            var teamTournamentRepository = new TeamTournamentRepository(factory);
            var service = new TournamentService(tournamentRepository, teamRepository, null, teamTournamentRepository);

            var teams = new List<Team> { new Team("Dinamo", 1), new Team("Spartak", 2) };
            var tournament = service.createTournament("RPL", new User("login", "hash"), new Country("Russia", "UEFA"), teams);

            using (var dbContext = factory.getDbContext())
            {
                compare(tournament, dbContext.Tournaments.FirstOrDefault(u => u.Id == 1));
                foreach(var team in teams)
                {
                    Assert.IsNotNull(dbContext.TeamTournaments.FirstOrDefault(t => t.TeamId == team.Id && t.TournamentId == tournament.Id));
                }
            }
        }

        [TestMethod]
        public void TestGet()
        {
            var factory = new InMemoryDbContextFactory();
            var repository = new TournamentRepository(factory);
            var service = new TournamentService(repository, null, null, null);
            var tournament = new Tournament("RPL", 1, 1, 1);

            using (var dbContext = factory.getDbContext())
            {
                dbContext.Tournaments.Add(tournament);
                dbContext.SaveChanges();
            }

            compare(tournament, service.getTournament(1));
        }

        [TestMethod]
        public void TestDelete()
        {
            var factory = new InMemoryDbContextFactory();
            var repository = new TournamentRepository(factory);
            var service = new TournamentService(repository, null, null, null);

            var tournament = new Tournament("RPL", 1, 1, 1);

            using (var dbContext = factory.getDbContext())
            {
                dbContext.Tournaments.Add(tournament);
                dbContext.SaveChanges();
            }

            service.deleteTournament(1);
            using (var dbContext = factory.getDbContext())
            {
                Assert.IsNull(dbContext.Matches.FirstOrDefault(m => m.Id == 1));
            }
        }
    }
}
