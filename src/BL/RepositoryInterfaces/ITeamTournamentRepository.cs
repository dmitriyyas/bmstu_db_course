using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Models;

namespace BL.RepositoryInterfaces
{
    public interface ITeamTournamentRepository
    {
        void create(TeamTournament teamTournament);

        TeamTournament get(int teamId, int tournamentId);
    }
}
