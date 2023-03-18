using BL.Models;
using BL.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBL.Mocks
{
    public class TeamMock : Mock, ITeamRepository
    {
        public void create(Team team)
        {
            teams.Add(team);
        }

        public IEnumerable<Team> getAll()
        {
            return teams;
        }

        public IEnumerable<Team> getByCountry(int countryId)
        {
            return teams.Where(t => t.CountryId == countryId);
        }

        public Team getById(int id)
        {
            return teams.FirstOrDefault(t => t.Id == id);
        }

        public Team getByName(string name)
        {
            return teams.FirstOrDefault(t => t.Name == name);
        }

        public IEnumerable<Team> getByTournament(int tournamentId)
        {
            var teamTours = teamTournaments.Where(t => t.TournamentId == tournamentId).Select(t => t.TeamId);

            return teams.Where(t => teamTours.Contains(t.Id));
        }

        public void update(Team team)
        {
            Team oldTeam = teams.First(t => t.Id == team.Id);
            teams.Remove(oldTeam);
            teams.Add(team);
        }
    }
}
