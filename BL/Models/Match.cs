using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class Match
    {
        public int Id { get; set; }

        public int TournamentId { get; set; }
        public int HomeTeamId { get; set; }
        public int GuestTeamId { get; set; }
        public int HomeGoals { get; set; }
        public int GuestGoals { get; set; }

        public Match (int tournamentId, int homeTeamId, int guestTeamId, int homeGoals, int guestGoals, int id = 1)
        {
            Id = id;
            TournamentId = tournamentId;
            HomeTeamId = homeTeamId;
            GuestTeamId = guestTeamId;
            HomeGoals = homeGoals;
            GuestGoals = guestGoals;
        }
    }
}
