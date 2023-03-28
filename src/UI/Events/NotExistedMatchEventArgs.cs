using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Models;

namespace UI.Events
{
    public class NotExistedMatchEventArgs : EventArgs
    {
        public Tournament tournament { get; set; }
        public Team hostTeam { get; set; }
        public Team guestTeam { get; set; }
    }
}
