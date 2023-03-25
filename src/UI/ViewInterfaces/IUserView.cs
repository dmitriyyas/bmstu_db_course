using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Models;
using UI.Events;

namespace UI.ViewInterfaces
{
    public interface IUserView : IView
    {
        IEnumerable<User> Users { get;  set; }
        User UserProfile { get; set; }
        IEnumerable<Tournament> UserTournaments { get; set; }
        bool UserProfileVisible { get; set; }
        bool ChangePermsVisible { get; set; }

        event EventHandler<UserClickedEventArgs> UserClicked;
        event EventHandler<TournamentClickedEventArgs> TournamentClicked;
        event EventHandler ChangePermsClicked;
        event EventHandler UserFormClosed;
    }
}
