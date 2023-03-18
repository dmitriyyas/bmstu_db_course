using BL.Models;
using BL.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBL.Mocks
{
    public class MatchMock : Mock, IMatchRepository
    {
        public void create(Match match)
        {
            matches.Add(match);
        }

        public void delete(int id)
        {
            matches.RemoveAll(m => m.Id == id);
        }

        public IEnumerable<Match> getByGuestTeam(int teamId, int tournamentId)
        {
            return matches.Where(m => m.TournamentId == tournamentId && m.GuestTeamId == teamId);
        }

        public IEnumerable<Match> getByHostTeam(int teamId, int tournamentId)
        {
            return matches.Where(m => m.TournamentId == tournamentId && m.HomeTeamId == teamId);
        }

        public Match getById(int id)
        {
            return matches.FirstOrDefault(m => m.Id == id);
        }

        public IEnumerable<Match> getByTournament(int tournamentId)
        {
            return matches.Where(m => m.TournamentId == tournamentId);
        }

        public void update(Match match)
        {
            matches.RemoveAll(m => m.Id == match.Id);
            matches.Add(match);
        }
    }
}
