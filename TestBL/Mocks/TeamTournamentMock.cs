using BL.Models;
using BL.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBL.Mocks
{
    public class TeamTournamentMock : Mock, ITeamTournamentRepository
    {
        public void create(TeamTournament teamTournament)
        {
            teamTournaments.Add(teamTournament);
        }

        public TeamTournament get(int teamId, int tournamentId)
        {
            return teamTournaments.FirstOrDefault(t => t.TeamId == teamId && t.TournamentId == tournamentId);
        }
    }
}
