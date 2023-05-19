using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class Outfitter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }

        public Outfitter(string name, int year, int id = 1)
        {
            Id = id;
            Name = name;
            Year = year;
        }
    }
}
