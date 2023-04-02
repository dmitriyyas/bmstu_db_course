using BL.Models;
using DataAccess.Repositories;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.RepositoryInterfaces;

namespace TestDA.IntegrationTests
{
    [TestClass]
    public class CountryIntegrationTest
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

            string name = "Russia";
            var country = new Country(name, "UEFA");

            repository.create(country);
            using (var dbContext = factory.getDbContext())
            {
                compare(country, dbContext.Countries.FirstOrDefault(c => c.Name == name));
            }
        }

        [TestMethod]
        public void TestGetByName()
        {
            var factory = new InMemoryDbContextFactory();
            var repository = new CountryRepository(factory);

            var country = new Country("Russia", "UEFA");

            using (var dbContext = factory.getDbContext())
            {
                dbContext.Countries.Add(country);
                dbContext.SaveChanges();
            }

            compare(country, repository.getByName("Russia"));
        }
    }
}
