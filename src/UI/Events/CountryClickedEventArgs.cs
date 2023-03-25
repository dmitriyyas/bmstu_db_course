using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Models;

namespace UI.Events
{
    public class CountryClickedEventArgs : EventArgs
    {
        public Country country { get; set; }
    }
}
