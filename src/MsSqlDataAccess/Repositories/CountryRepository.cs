using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Models;
using BL.RepositoryInterfaces;

namespace MsSqlDataAccess.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly IDbContextFactory _dbContextFactory;

        public CountryRepository(IDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public void create(Country country)
        {
            try
            {
                using var dbContext = _dbContextFactory.getDbContext();

                if (dbContext.Countries.Count() > 0)
                    country.Id = dbContext.Countries.Select(x => x.Id).Max() + 1;
                else
                    country.Id = 1;

                dbContext.Countries.Add(country);
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при добавлении страны.");
            }
        }

        public IEnumerable<Country> getAll()
        {
            using var dbContext = _dbContextFactory.getDbContext();

            return dbContext.Countries.ToList();
        }

        public Country getById(int id)
        {
            using var dbContext = _dbContextFactory.getDbContext();

            return dbContext.Countries.FirstOrDefault(c => c.Id == id);
        }

        public Country getByName(string name)
        {
            using var dbContext = _dbContextFactory.getDbContext();

            return dbContext.Countries.FirstOrDefault(c => c.Name == name);
        }
    }
}
