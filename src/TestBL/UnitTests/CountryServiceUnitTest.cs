using BL.Services;
using BL.RepositoryInterfaces;
using BL.Models;
using TestBL.Mocks;
using System.Diagnostics.Metrics;

namespace TestBL.UnitTests
{
    [TestClass]
    public class CountryServiceUnitTest
    {
        private void compare(Country x, Country y)
        {
            Assert.AreEqual(x.Id, y.Id);
            Assert.AreEqual(x.Name, y.Name);
            Assert.AreEqual(x.Confederation, y.Confederation);
        }

        [TestMethod]
        public void TestCreateCountryDefault()
        {
            Mock.clear();
            var countryMock = new CountryMock();
            var countryService = new CountryService(countryMock, null, null);

            string name = "Russia";
            string confederation = "UEFA";

            Country country = new Country(name, confederation);
            countryService.createCountry(name, confederation);
            Country createdCountry = countryMock.getById(country.Id);

            compare(createdCountry, country);
        }

        [TestMethod]
        public void TestCreateCountryWithSameName()
        {
            Mock.clear();
            var countryMock = new CountryMock();
            var countryService = new CountryService(countryMock, null, null);

            string name = "Russia";
            string confederation = "UEFA";

            Country country1 = new Country(name, confederation);
            countryService.createCountry(name, confederation);
            Country country2 = new Country(name, confederation);

            Assert.ThrowsException<Exception>(() => countryService.createCountry(name, confederation));
        }

        [TestMethod]
        public void TestGetByIdDefault()
        {
            Mock.clear();
            var countryMock = new CountryMock();
            var countryService = new CountryService(countryMock, null, null);

            Country country = new Country("Russia", "Uefa", 1);
            countryMock.create(country);

            compare(country, countryService.getCountry(1));
        }

        [TestMethod]
        public void TestGetByIdNotExist()
        {
            Mock.clear();
            var countryMock = new CountryMock();
            var countryService = new CountryService(countryMock, null, null);

            Assert.ThrowsException<Exception>(() => countryService.getCountry(-1));
        }
    }
}