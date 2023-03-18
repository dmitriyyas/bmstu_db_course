using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Models;

namespace BL.RepositoryInterfaces
{
    public interface ITournamentRepository
    {
        void create(Tournament tournament);
        void delete(int id);
        Tournament getById(int id);
        Tournament getByName(string name);

        IEnumerable<Tournament> getAll();
        IEnumerable<Tournament> getByCountry(int countryId);
        IEnumerable<Tournament> getByUser(int userId);
        IEnumerable<Tournament> getByTeam(int teamId);
    }
}
