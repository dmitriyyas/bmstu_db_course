using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Models;
using BL.RepositoryInterfaces;
using MongoDB.Driver;

namespace MongoDbDataAccess.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly CollectionsFactory _collectionsFactory;

        public CountryRepository(CollectionsFactory collectionsFactory)
        {
            _collectionsFactory = collectionsFactory;
        }

        public void create(Country country)
        {
            try
            {
                var countries = _collectionsFactory.getCountryCollection();

                if (countries.CountDocuments(_ => true) > 0)
                    country.Id = countries.AsQueryable().Select(c => c.Id).Max() + 1;
                else
                    country.Id = 1;

                countries.InsertOne(country);
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при добавлении страны.");
            }
        }

        public IEnumerable<Country> getAll()
        {
            var countries = _collectionsFactory.getCountryCollection();

            return countries.Find(_ => true).ToList();
        }

        public Country getById(int id)
        {
            var countries = _collectionsFactory.getCountryCollection();

            return countries.Find(c => c.Id == id).FirstOrDefault();
        }

        public Country getByName(string name)
        {
            var countries = _collectionsFactory.getCountryCollection();

            return countries.Find(c => c.Name == name).FirstOrDefault();
        }
    }
}
