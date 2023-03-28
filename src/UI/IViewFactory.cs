using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.ViewInterfaces;

namespace UI
{
    public interface IViewFactory
    {
        IMainFormView createMainFormView();

        IUserView createUserView();

        ICountryView createCountryView();

        ITeamView createTeamView();

        ITournamentView createTournamentView();
    }
}
