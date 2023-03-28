using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Models;
using UI.Events;

namespace UI.ViewInterfaces
{
    public interface ITournamentView : IView
    {
        IEnumerable<Tournament> Tournaments { get; set; }
        Tournament TournamentProfile { get; set; }
        IEnumerable<Team> TournamentTeams { get; set; }
        IEnumerable<Country> Countries { get; set; }
        IEnumerable<Match> TournamentMatches { get; set; }
        IEnumerable<User> Users { get; set; }

        IEnumerable<TeamStatistics> Table { get; set; }

        bool TournamentProfileVisible { get; set; }
        bool AddTournamentGroupBoxVisible { get; set; }
        bool MatchesVisible { get; set; }
        bool TableVisible { get; set; }
        bool AddTournamentVisible { get; set; }

        bool DeleteTournamentVisible { get; set; }

        string NewTournamentName { get; set; }
        string NewTournamentCountry { get; set; }
        string NewTeamName { get; set; }
        string? SelectedTeamName { get; }
        List<Team> NewTournamentTeams { get; set; }
        IEnumerable<Team> Teams { get; set; }

        event EventHandler<TournamentClickedEventArgs> TournamentClicked;
        event EventHandler<CountryClickedEventArgs> CountryClicked;
        event EventHandler<UserClickedEventArgs> UserClicked;
        event EventHandler<MatchClickedEventArgs> MatchClicked;
        event EventHandler<TeamClickedEventArgs> TeamClicked;
        event EventHandler<NotExistedMatchEventArgs> NotExistedMatchClicked;
        event EventHandler AddTournamentClicked;
        event EventHandler DeleteTournamentClicked;
        event EventHandler ConfirmTournamentClicked;
        event EventHandler AddTeamToNewClicked;
        event EventHandler DeleteTeamFromNewClicked;
        event EventHandler TournamentFormClosed;
        event EventHandler ShowMatchesClicked;
        event EventHandler ShowTableClicked;
    }
}
