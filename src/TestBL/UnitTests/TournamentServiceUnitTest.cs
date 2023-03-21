using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestBL.Mocks;
using BL.Models;
using BL.Services;
using BL.RepositoryInterfaces;
using System.Collections;

namespace TestBL.UnitTests
{
    [TestClass]
    public class TournamentServiceUnitTest
    {
        private void compare(Tournament x, Tournament y)
        {
            Assert.AreEqual(x.Id, y.Id);
            Assert.AreEqual(x.Name, y.Name);
            Assert.AreEqual(x.CountryId, y.CountryId);
            Assert.AreEqual(x.UserId, y.UserId);
        }

        [TestMethod]
        public void TestCreateTournamentDefault()
        {
            Mock.clear();
            var tournamentMock = new TournamentMock();
            var teamMock = new TeamMock();
            var teamTournamentMock = new TeamTournamentMock();
            var tournamentService = new TournamentService(tournamentMock, teamMock, null, teamTournamentMock);

            List<Team> teams = new List<Team>
            {
                new Team("Dinamo", 1, 1),
                new Team("Barcelona", 1, 2)
            };
            foreach (var team in teams)
            {
                teamMock.create(team);
            }

            Tournament tournament = new Tournament("Champions League", 3, 1, 1);
            var createdTournament = tournamentService.createTournament(tournament.Name, 
                                                                        tournament.UserId, 
                                                                        tournament.CountryId, 
                                                                        teams);

            compare(tournament, createdTournament);

            foreach (var team in teamMock.getAll())
            {
                Assert.IsNotNull(teamTournamentMock.get(team.Id, tournament.Id));
            }
        }

        [TestMethod]
        public void TestCreateTournamentAddSameTeam()
        {
            Mock.clear();
            var tournamentMock = new TournamentMock();
            var teamMock = new TeamMock();
            var teamTournamentMock = new TeamTournamentMock();
            var tournamentService = new TournamentService(tournamentMock, teamMock, null, teamTournamentMock);

            Team team = new Team("Dinamo", 1, 1);
            teamMock.create(team);

            List<Team> teams = new List<Team>
            {
                team,
                team
            };

            Tournament tournament = new Tournament("Champions League", 3, 1, 1);
            Assert.ThrowsException<Exception>(() => tournamentService.createTournament(tournament.Name, 
                                                                                        tournament.UserId, 
                                                                                        tournament.CountryId, 
                                                                                        teams));

        }

        [TestMethod]
        public void TestCreateTournamentSameName()
        {
            Mock.clear();
            var tournamentMock = new TournamentMock();
            var tournamentService = new TournamentService(tournamentMock, null, null, null);

            Tournament tournament = new Tournament("Champions League", 3, 1, 1);
            var createdTournament = tournamentService.createTournament(tournament.Name,
                                                                        tournament.UserId,
                                                                        tournament.CountryId,
                                                                        new List<Team>());
            Assert.ThrowsException<Exception>(() => tournamentService.createTournament(tournament.Name,
                                                                        tournament.UserId,
                                                                        tournament.CountryId,
                                                                        new List<Team>()));
        }

        [TestMethod]
        public void TestGetTournamentDefault()
        {
            Mock.clear();
            var tournamentMock = new TournamentMock();
            var tournamentService = new TournamentService(tournamentMock, null, null, null);

            Tournament tournament = new Tournament("Champions League", 3, 1, 1);
            tournamentMock.create(tournament);

            var gotTournament = tournamentService.getTournament(tournament.Id);

            compare(tournament, gotTournament);
        }

        [TestMethod]
        public void TestGetTournamentUnknownId()
        {
            Mock.clear();
            var tournamentMock = new TournamentMock();
            var tournamentService = new TournamentService(tournamentMock, null, null, null);

            Assert.ThrowsException<Exception>(() => tournamentService.getTournament(-1));
        }

        [TestMethod]
        public void TestGetTournamentTableDefault()
        {
            Mock.clear();
            var tournamentMock = new TournamentMock();
            var teamMock = new TeamMock();
            var teamTournamentMock = new TeamTournamentMock();
            var matchMock = new MatchMock();
            var tournamentService = new TournamentService(tournamentMock, teamMock, matchMock, teamTournamentMock);

            var tournament = new Tournament("Champions League", 1, 1, 1);
            tournamentMock.create(tournament);

            var dinamo = new Team("Dinamo", 1, 1);
            var barcelona = new Team("Barcelona", 1, 2);
            var chelsea = new Team("Chelsea", 2, 3);

            List<Team> teams = new List<Team>
            {
                dinamo, barcelona, chelsea
            };
            foreach (var team in teams)
            {
                teamMock.create(team);
                teamTournamentMock.create(new TeamTournament(team.Id, tournament.Id));
            }

            List<Match> matches = new List<Match>
            {
                /*
                 * Dinamo 1:2 Barcelona
                 * Dinamo 1:3 Chelsea
                 * Barcelona 2:1 Chelsea
                 * Barcelona 2:0 Dinamo
                 * Chelsea 1:1 Dinamo
                 * Chelsea 1:5 Barcelona
                 */
                new Match(tournament.Id, dinamo.Id, barcelona.Id, 1, 2, 1),
                new Match(tournament.Id, dinamo.Id, chelsea.Id, 1, 3, 2),
                new Match(tournament.Id, barcelona.Id, chelsea.Id, 2, 1, 3),
                new Match(tournament.Id, barcelona.Id, dinamo.Id, 2, 0, 4),
                new Match(tournament.Id, chelsea.Id, dinamo.Id, 1, 1, 5),
                new Match(tournament.Id, chelsea.Id, barcelona.Id, 1, 5, 6)
            };

            foreach (var match in matches)
            {
                matchMock.create(match);
            }

            List<TeamStatistics> statistics = new List<TeamStatistics>
            {
                /* name      m w d l gs gc p 
                 * Barcelona 4 4 0 0 11 3  12
                 * Chelsea   4 1 1 2 6  9  4
                 * Dinamo    4 0 1 3 3  8  1
                 */
                new TeamStatistics("Barcelona", 4, 4, 0, 0, 11, 3, 12),
                new TeamStatistics("Chelsea", 4, 1, 1, 2, 6, 9, 4),
                new TeamStatistics("Dinamo", 4, 0, 1, 3, 3, 8, 1)
            };

            var table = tournamentService.getTournamentTable(tournament.Id);
            var zipped = statistics.Zip(table, (s, t) => new { State = s, Row = t });
            foreach(var row in zipped)
            {
                Assert.AreEqual(row.State.Name, row.Row.Name);
                Assert.AreEqual(row.State.Matches, row.Row.Matches);
                Assert.AreEqual(row.State.Wins, row.Row.Wins);
                Assert.AreEqual(row.State.Draws, row.Row.Draws);
                Assert.AreEqual(row.State.Loses, row.Row.Loses);
                Assert.AreEqual(row.State.GoalsScored, row.Row.GoalsScored);
                Assert.AreEqual(row.State.GoalsConceded, row.Row.GoalsConceded);
                Assert.AreEqual(row.State.Points, row.Row.Points);
            }
        }
    }
}
