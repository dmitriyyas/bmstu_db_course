using BL.Models;
using BL.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBL.Mocks
{
    public class CountryMock : Mock, ICountryRepository
    {
        public void create(Country country)
        {
            countries.Add(country);
        }

        public IEnumerable<Country> getAll()
        {
            return countries;
        }

        public Country getById(int id)
        {
            return countries.FirstOrDefault(c => c.Id == id);
        }

        public Country getByName(string name)
        {
            return countries.FirstOrDefault(c => c.Name == name);
        }
    }
}
