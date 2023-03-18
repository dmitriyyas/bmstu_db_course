using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class TeamTournament
    {
        public int TeamId { get; set; }
        public int TournamentId { get; set; }
        public TeamTournament(int teamId, int tournamentId)
        {
            TeamId = teamId;
            TournamentId = tournamentId;
        }
    }
}
