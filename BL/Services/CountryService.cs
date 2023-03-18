using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Models;
using BL.RepositoryInterfaces;

namespace BL.Services
{
    public class CountryService
    {
        private readonly ICountryRepository _countryRepository;
        private readonly ITeamRepository _teamRepository;
        private readonly ITournamentRepository _tournamentRepository;

        public CountryService(ICountryRepository countryRepository, ITeamRepository teamRepository, ITournamentRepository tournamentRepository)
        {
            _countryRepository = countryRepository;
            _teamRepository = teamRepository;
            _tournamentRepository = tournamentRepository;
        }

        public Country createCountry(string name, string confederation)
        {
            Country country = _countryRepository.getByName(name);
            if (country == null)
            {
                country = new Country(name, confederation);
                _countryRepository.create(country);
            }
            else
            {
                throw new Exception("Страна с таким названием уже существует.");
            }

            return country;
        }

        public Country getCountry(int id)
        {
            Country country = _countryRepository.getById(id);
            if (country == null)
            {
                throw new Exception("Страны с таким id не существует.");
            }

            return country;
        }

        public IEnumerable<Country> getAllCountries()
        {
            return _countryRepository.getAll();
        }

        public IEnumerable<Team> getCountryTeams(int id)
        {
            return _teamRepository.getByCountry(id);
        }

        public IEnumerable<Tournament> getCountryTournaments(int id)
        {
            return _tournamentRepository.getByCountry(id);
        }
    }
}
