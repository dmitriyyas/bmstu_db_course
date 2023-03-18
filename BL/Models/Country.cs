using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Confederation { get; set; }

        public Country(string name, string confederation, int id = 1)
        {
            Id = id;
            Name = name;
            Confederation = confederation;
        }
    }
}
