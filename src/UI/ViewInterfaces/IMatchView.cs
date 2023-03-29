using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Models;
using UI.Events;

namespace UI.ViewInterfaces
{
    public interface IMatchView : IView
    {
        Match MatchProfile { get; set; }
        Tournament MatchTournament { get; set; }
        Team Home { get; set; }
        Team Guest { get; set; }
        string HomeGoals { get; set; }
        string GuestGoals { get; set; }

        bool GoalsEnabled { get; set; }
        bool CreateMatchVisible { get; set; }
        bool EditMatchVisible { get; set; }

        event EventHandler<TeamClickedEventArgs> TeamClicked;
        event EventHandler MatchFormClosed;
        event EventHandler CreateMatchClicked;
        event EventHandler UpdateMatchClicked;
        event EventHandler DeleteMatchClicked;
    }
}
