using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Models;

namespace BL.RepositoryInterfaces
{
    public interface ITeamRepository
    {
        void create(Team team);
        void update(Team team);
        Team getById(int id);
        Team getByName (string name);
        IEnumerable<Team> getByCountry(int countryId);
        IEnumerable<Team> getByTournament(int tournamentId);

        IEnumerable<Team> getByOutfitter(int outfitterId);
        IEnumerable<Team> getAll();

    }
}
