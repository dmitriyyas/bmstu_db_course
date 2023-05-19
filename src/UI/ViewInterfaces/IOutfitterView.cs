using BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Events;

namespace UI.ViewInterfaces
{
    public interface IOutfitterView: IView
    {
        IEnumerable<Outfitter> Outfitters { get; set; }
        Outfitter OutfitterProfile { get; set; }
        IEnumerable<Team> OutfitterTeams { get; set; }
        bool OutfitterProfileVisible { get; set; }
        bool AddOutfitterVisible { get; set; }
        bool AddOutfitterGroupBoxVisible { get; set; }

        string NewOutfitterName { get; set; }
        string NewOutfitterYear { get; set; }

        event EventHandler<OutfitterClickedEventArgs> OutfitterClicked;
        event EventHandler<TeamClickedEventArgs> TeamClicked;
        event EventHandler AddOutfitterClicked;
        event EventHandler ConfirmAddOutfitterClicked;
        event EventHandler OutfitterFormClosed;
    }
}
