using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; } 

        public int? OutfitterId { get; set; }

        public Team(string name, int countryId, int? outfitterId, int id = 1)
        {
            Id = id;
            Name = name;
            CountryId = countryId;
            OutfitterId = outfitterId;
        }

        public void changeCountry(Country country)
        {
            CountryId = country.Id;
        }
    }
}
