using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Models;
using UI.Events;

namespace UI.ViewInterfaces
{
    public interface ICountryView : IView
    {
        IEnumerable<Country> Countries { get; set; }
        Country CountryProfile { get; set; }
        IEnumerable<Team> CountryTeams { get; set; }
        IEnumerable<Tournament> CountryTournaments { get; set; }

        bool CountryProfileVisible { get; set; }
        bool AddCountryVisible { get; set; }
        bool AddCountryGroupBoxVisible { get; set; }

        string NewCountryName { get; set; }
        string NewCountryConfederation { get; set; }

        event EventHandler<TeamClickedEventArgs> TeamClicked;
        event EventHandler<TournamentClickedEventArgs> TournamentClicked;
        event EventHandler<CountryClickedEventArgs> CountryClicked;
        event EventHandler AddCountryClicked;
        event EventHandler ConfirmAddCountryClicked;
        event EventHandler CountryFormClosed;

    }
}
