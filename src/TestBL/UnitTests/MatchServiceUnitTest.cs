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
    public class MatchServiceUnitTest
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
        public void TestCreateMatchDefault()
        {
            Mock.clear();
            var matchMock = new MatchMock();
            var matchService = new MatchService(matchMock);

            Match match = new Match(1, 1, 2, 1, 0);

            compare(match, matchService.createMatch(1, 1, 2, 1, 0));
        }

        [TestMethod]
        public void TestGetMatchDefault()
        {
            Mock.clear();
            var matchMock = new MatchMock();
            var matchService = new MatchService(matchMock);

            var match = new Match(1, 1, 2, 1, 0, 1);
            matchMock.create(match);

            compare(match, matchService.getMatch(1));
        }

        [TestMethod]
        public void TestGetMatchUnknownId()
        {
            Mock.clear();
            var matchMock = new MatchMock();
            var matchService = new MatchService(matchMock);

            Assert.ThrowsException<Exception>(() => matchService.getMatch(1));
        }

        [TestMethod]
        public void TestUpdateMatchDefault()
        {
            Mock.clear();
            var matchMock = new MatchMock();
            var matchService = new MatchService(matchMock);

            var match = new Match(1, 1, 2, 1, 0, 1);
            matchMock.create(match);

            matchService.updateMatch(1, 2, 2);
            compare(new Match(1, 1, 2, 2, 2, 1), matchMock.getById(1));
        }

        [TestMethod]
        public void TestUpdateMatchUnknownId()
        {
            Mock.clear();
            var matchMock = new MatchMock();
            var matchService = new MatchService(matchMock);

            Assert.ThrowsException<Exception>(() => matchService.updateMatch(1, 2, 2));
        }
    }
}
