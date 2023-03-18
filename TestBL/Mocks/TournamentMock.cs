using BL.Models;
using BL.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBL.Mocks
{
    public class TournamentMock : Mock, ITournamentRepository
    {
        public void create(Tournament tournament)
        {
            tournaments.Add(tournament);
        }

        public void delete(int id)
        {
            tournaments.RemoveAll(t => t.Id == id);

            teamTournaments.RemoveAll(t => t.TournamentId == id);
        }

        public IEnumerable<Tournament> getAll()
        {
            return tournaments;
        }

        public IEnumerable<Tournament> getByCountry(int countryId)
        {
            return tournaments.Where(t => t.CountryId == countryId);
        }

        public Tournament getById(int id)
        {
            return tournaments.Where(t => t.Id == id).FirstOrDefault();
        }

        public Tournament getByName(string name)
        {
            return tournaments.Where(t => t.Name == name).FirstOrDefault();
        }

        public IEnumerable<Tournament> getByTeam(int teamId)
        {
            var teamTours = teamTournaments.Where(t => t.TeamId == teamId).Select(t => t.TournamentId);

            return tournaments.Where(t => teamTours.Contains(t.Id));
        }

        public IEnumerable<Tournament> getByUser(int userId)
        {
            return tournaments.Where(t => t.UserId == userId);
        }
    }
}
