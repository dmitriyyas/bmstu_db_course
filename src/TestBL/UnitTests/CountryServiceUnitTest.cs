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
            Country createdCountry = countryService.getCountry(country.Id);

            Assert.AreEqual(country.Name, createdCountry.Name);
            Assert.AreEqual(country.Confederation, createdCountry.Confederation);
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
        public void TestGetByIdNotExist()
        {
            Mock.clear();
            var countryMock = new CountryMock();
            var countryService = new CountryService(countryMock, null, null);


            Assert.ThrowsException<Exception>(() => countryService.getCountry(-1));
        }
    }
}