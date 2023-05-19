using BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Events
{
    public class OutfitterClickedEventArgs : EventArgs
    {
        public Outfitter outfitter { get; set; }
    }
}
