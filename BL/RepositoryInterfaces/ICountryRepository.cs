using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Models;

namespace BL.RepositoryInterfaces
{
    public interface ICountryRepository
    {
        void create(Country country);
        Country getById(int id);
        Country getByName(string name);

        IEnumerable<Country> getAll();
    }
}
