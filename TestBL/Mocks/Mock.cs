using BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBL.Mocks
{
    public class Mock
    {
        protected static List<Country> countries = new List<Country>();
        protected static List<Team> teams = new List<Team>();
        protected static List<Tournament> tournaments = new List<Tournament>();
        protected static List<TeamTournament> teamTournaments = new List<TeamTournament>();
        protected static List<User> users = new List<User>();
        protected static List<Match> matches = new List<Match>();

        public static void clear()
        {
            countries.Clear();
            teams.Clear();
            tournaments.Clear();
            teamTournaments.Clear();
            users.Clear();
            matches.Clear();
        }
    }
}
