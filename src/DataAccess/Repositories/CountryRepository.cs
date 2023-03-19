using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Models;
using BL.RepositoryInterfaces;
using DataAccess.DBContext;

namespace DataAccess.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly DbContextFactory _dbContextFactory;

        public CountryRepository(DbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public void create(Country country)
        {
            var dbContext = _dbContextFactory.getDbContext();

            try
            {
                country.Id = dbContext.Countries.Count() + 1;
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
            var dbContext = _dbContextFactory.getDbContext();

            return dbContext.Countries.ToList();
        }

        public Country getById(int id)
        {
            var dbContext = _dbContextFactory.getDbContext();

            return dbContext.Countries.FirstOrDefault(c => c.Id == id);
        }

        public Country getByName(string name)
        {
            var dbContext = _dbContextFactory.getDbContext();

            return dbContext.Countries.FirstOrDefault(c => c.Name == name);
        }
    }
}
