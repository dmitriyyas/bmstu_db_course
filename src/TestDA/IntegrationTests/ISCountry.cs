using BL.Models;
using DataAccess.Repositories;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.RepositoryInterfaces;
using BL.Services;

namespace TestDA.IntegrationTests
{
    [TestClass]
    public class ISCountry
    {
        private void compare(Country x, Country y)
        {
            Assert.AreEqual(x.Id, y.Id);
            Assert.AreEqual(x.Name, y.Name);
            Assert.AreEqual(x.Confederation, y.Confederation);
        }
        [TestMethod]
        public void TestCreate()
        {
            var factory = new InMemoryDbContextFactory();
            var repository = new CountryRepository(factory);
            var service = new CountryService(repository, null, null);

            string name = "Russia";
            var country = service.createCountry(name, "UEFA");
            using (var dbContext = factory.getDbContext())
            {
                compare(country, dbContext.Countries.FirstOrDefault(c => c.Name == name));
            }
        }

        [TestMethod]
        public void TestGet()
        {
            var factory = new InMemoryDbContextFactory();
            var repository = new CountryRepository(factory);
            var service = new CountryService(repository, null, null);

            var country = new Country("Russia", "UEFA", 1);

            using (var dbContext = factory.getDbContext())
            {
                dbContext.Countries.Add(country);
                dbContext.SaveChanges();
            }

            compare(country, service.getCountry(1));
        }
    }
}
