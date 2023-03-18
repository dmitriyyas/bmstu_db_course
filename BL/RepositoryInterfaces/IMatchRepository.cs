using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Models;

namespace BL.RepositoryInterfaces
{
    public interface IMatchRepository
    {
        void create(Match match);
        void update(Match match);
        void delete(int id);
        Match getById(int id);
        IEnumerable<Match> getByTournament(int tournamentId);
        IEnumerable<Match> getByHostTeam(int teamId, int tournamentId);
        IEnumerable<Match> getByGuestTeam(int teamId, int tournamentId);
    }
}
