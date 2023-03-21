using BL.Models;
using BL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestBL.Mocks;

namespace TestBL.UnitTests
{
    [TestClass]
    public class TeamServiceUnitTest
    {
        private void compare(Team x, Team y)
        {
            Assert.AreEqual(x.Name, y.Name);
            Assert.AreEqual(x.Id, y.Id);
            Assert.AreEqual(x.CountryId, y.CountryId);
        }

        [TestMethod]
        public void TestCreateTeamDefault()
        {
            Mock.clear();
            var teamMock = new TeamMock();
            var teamService = new TeamService(teamMock, null);

            Team team = new Team("Dinamo", 1);

            Team createdTeam = teamService.createTeam("Dinamo", 1);

            compare(team, createdTeam);
        }

        [TestMethod]
        public void TestCreateTeamSameName()
        {
            Mock.clear();
            var teamMock = new TeamMock();
            var teamService = new TeamService(teamMock, null);

            teamMock.create(new Team("Dinamo", 1));
            Assert.ThrowsException<Exception>(() => teamService.createTeam("Dinamo", 2));
        }

        [TestMethod]
        public void TestGetTeamDefault()
        {
            Mock.clear();
            var teamMock = new TeamMock();
            var teamService = new TeamService(teamMock, null);

            var team = new Team("Dinamo", 1);
            teamMock.create(team);

            compare(team, teamService.getTeam(1));
        }

        [TestMethod]
        public void TestGetTeamUnknownId() 
        {
            Mock.clear();
            var teamMock = new TeamMock();
            var teamService = new TeamService(teamMock, null);

            Assert.ThrowsException<Exception>(() => teamService.getTeam(-1));
        }
    }
}
