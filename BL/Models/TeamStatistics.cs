using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class TeamStatistics
    {
        public string Name { get; set; }
        public int Matches { get; set; }
        public int Wins { get; set; }
        public int Draws { get; set; }
        public int Loses { get; set; }
        public int GoalsScored { get; set; }
        public int GoalsConceded { get; set; }

        public int Points { get; set; }
        public TeamStatistics(string name, int matches = 0, int wins = 0, int draws = 0, int loses = 0, int goalsScored = 0, int goalsConceded = 0, int points = 0)
        {
            Name = name;
            Matches = matches;
            Wins = wins;
            Draws = draws;
            Loses = loses;
            GoalsScored = goalsScored;
            GoalsConceded= goalsConceded;
            Points = points;
        }
    }
}
