using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class Tournament
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        public int CountryId { get; set; }

        public Tournament (string name, int userId, int countryId, int id = 1)
        {
            Id = id;
            Name = name;
            UserId = userId;
            CountryId = countryId;
        }
    }
}
