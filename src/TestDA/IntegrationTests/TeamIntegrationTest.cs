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
    public class TeamIntegrationTest
    {
        private void compare(Team x, Team y)
        {
            Assert.AreEqual(x.Name, y.Name);
            Assert.AreEqual(x.Id, y.Id);
            Assert.AreEqual(x.CountryId, y.CountryId);
        }
        [TestMethod]
        public void TestCreate()
        {
            var factory = new InMemoryDbContextFactory();
            var repository = new TeamRepository(factory);

            var team = new Team("Dinamo", 1);

            repository.create(team);
            using (var dbContext = factory.getDbContext())
            {
                compare(team, dbContext.Teams.FirstOrDefault(u => u.Name == "Dinamo"));
            }
        }
        [TestMethod]

        public void TestUpdate()
        {
            var factory = new InMemoryDbContextFactory();
            var repository = new TeamRepository(factory);

            var team = new Team("Dinamo", 1);

            using (var dbContext = factory.getDbContext())
            {
                dbContext.Teams.Add(team);
                dbContext.SaveChanges();
            }

            team.CountryId = 2;

            repository.update(team);
            using (var dbContext = factory.getDbContext())
            {
                compare(team, dbContext.Teams.FirstOrDefault(u => u.Name == "Dinamo"));
            }
        }

        [TestMethod]
        public void TestGetByName()
        {
            var factory = new InMemoryDbContextFactory();
            var repository = new TeamRepository(factory);

            var team = new Team("Dinamo", 1);

            using (var dbContext = factory.getDbContext())
            {
                dbContext.Teams.Add(team);
                dbContext.SaveChanges();
            }

            compare(team, repository.getByName("Dinamo"));
        }
    }
}
