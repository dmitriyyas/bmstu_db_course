using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.ViewInterfaces;
using UI.WinFormViews;

namespace UI
{
    public class WinFormViewFactory : IViewFactory
    {
        public WinFormViewFactory() { }
        public IMainFormView createMainFormView()
        {
            return new WinFormMainView();
        }

        public IUserView createUserView()
        {
            return new WinFormUserView();
        }

        public ICountryView createCountryView()
        {
            return new WinFormCountryView();
        }
    }
}
