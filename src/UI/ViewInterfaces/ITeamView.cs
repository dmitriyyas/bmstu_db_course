using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Models;
using UI.Events;

namespace UI.ViewInterfaces
{
    public interface ITeamView : IView
    {
        IEnumerable<Team> Teams { get; set; }
        Team TeamProfile { get; set; }
        IEnumerable<Tournament> TeamTournaments { get; set; }
        IEnumerable<Country> Countries { get; set; }

        bool TeamProfileVisible { get; set; }
        bool AddTeamGroupBoxVisible { get; set; }
        bool AddTeamVisible { get; set; }

        string NewTeamName { get; set; }
        string NewTeamCountry { get; set; }

        event EventHandler<TeamClickedEventArgs> TeamClicked;
        event EventHandler<TournamentClickedEventArgs> TournamentClicked;
        event EventHandler<CountryClickedEventArgs> CountryClicked;
        event EventHandler AddTeamClicked;
        event EventHandler ConfirmTeamClicked;
        event EventHandler TeamFormClosed;
    }
}
