using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Events;

namespace UI.ViewInterfaces
{
    public interface IMainFormView : IView
    {
        bool LogInGroupBoxVisible { get; set; }
        bool RegisterGroupBoxVisible { get; set; }
        bool StartGroupBoxVisible { get; set; }
        bool LogOutGroupBoxVisible { get; set; }

        string LogInLogin { get; set; }
        string LogInPassword { get; set; }
        string RegisterLogin { get; set; }
        string RegisterPassword { get; set; }
        string RegisterConfirmPassword { get; set; }

        string CurrentUserLogin { set; }

        event EventHandler StartLogInClicked;
        event EventHandler LogOutClicked;
        event EventHandler StartRegisterClicked;
        event EventHandler RegisterConfirmClicked;
        event EventHandler LogInConfirmClicked;
        event EventHandler LogInBackClicked;
        event EventHandler RegisterBackClicked;
        event EventHandler MainFormClosed;

        event EventHandler<UserClickedEventArgs> UserClicked;
        event EventHandler<CountryClickedEventArgs> CountryClicked;
        event EventHandler<TeamClickedEventArgs> TeamClicked;
        event EventHandler<TournamentClickedEventArgs> TournamentClicked;

    }
}
