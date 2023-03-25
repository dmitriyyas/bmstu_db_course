using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Models;
using BL.RepositoryInterfaces;
using BL.Services;
using Microsoft.Extensions.Configuration;
using UI.ViewInterfaces;
using UI.Events;

namespace UI
{
    public class Presenter
    {
        private readonly UserService _userService;
        private readonly CountryService _countryService;
        private readonly TeamService _teamService;
        private readonly TournamentService _tournamentService;
        private readonly MatchService _matchService;

        private readonly IViewFactory _viewFactory;

        private IConfiguration _configuration;

        private User currentUser;

        private IMainFormView? _mainFormView;
        private IUserView? _userView;

        public ApplicationContext AppContext { get; set; }

        public Presenter(UserService userService, CountryService countryService, TeamService teamService, TournamentService tournamentService, MatchService matchService, IViewFactory viewFactory, IConfiguration configuration, ApplicationContext context)
        {
            _userService = userService;
            _countryService = countryService;
            _teamService = teamService;
            _tournamentService = tournamentService;
            _matchService = matchService;
            _viewFactory = viewFactory;
            _configuration = configuration;
            AppContext = context;

            _configuration["DbConnection"] = "guest";

            OpenMainForm();
        }

        public void OpenMainForm()
        {
            _mainFormView = _viewFactory.createMainFormView();

            _mainFormView.StartLogInClicked += LogIn;
            _mainFormView.StartRegisterClicked += Register;
            _mainFormView.LogInConfirmClicked += ConfirmLogIn;
            _mainFormView.RegisterConfirmClicked += ConfirmRegister;
            _mainFormView.LogOutClicked += LogOut;
            _mainFormView.MainFormClosed += MainFormClose;
            _mainFormView.LogInBackClicked += LogInBack;
            _mainFormView.RegisterBackClicked += RegisterBack;
            _mainFormView.UserClicked += OpenUserForm;

            _mainFormView.Show();
        }

        public void LogIn(object sender, EventArgs e)
        { 
            _mainFormView.StartGroupBoxVisible = false;
            _mainFormView.LogInGroupBoxVisible = true;
        }

        public void Register(object sender, EventArgs e)
        {
            _mainFormView.StartGroupBoxVisible = false;
            _mainFormView.RegisterGroupBoxVisible = true;
        }

        public void ConfirmLogIn(object sender, EventArgs e)
        {
            try
            {
                currentUser = _userService.logIn(_mainFormView.LogInLogin, _mainFormView.LogInPassword);
                _configuration["DbConnection"] = currentUser.Permission;

                _mainFormView.LogInGroupBoxVisible = false;
                _mainFormView.LogInLogin = "";
                _mainFormView.LogInPassword = "";

                _mainFormView.CurrentUserLogin = currentUser.Login;
                _mainFormView.LogOutGroupBoxVisible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        public void ConfirmRegister(object sender, EventArgs e)
        {
            try
            {
                var login = _mainFormView.RegisterLogin;
                var password = _mainFormView.RegisterPassword;
                var passwordCopy = _mainFormView.RegisterConfirmPassword;

                if (login.Length < 3)
                {
                    throw new Exception("Логин должен состоять из не менее 3 символов.");
                }

                if (password.Length < 8)
                {
                    throw new Exception("Пароль должен состоять из не менее чем 8 символов.");
                }

                if (password != passwordCopy)
                {
                    throw new Exception("Пароли не совпадают.");
                }

                currentUser = _userService.register(login, password);
                _configuration["DbConnection"] = currentUser.Permission;

                _mainFormView.RegisterGroupBoxVisible = false;
                _mainFormView.RegisterLogin = "";
                _mainFormView.RegisterPassword = "";
                _mainFormView.RegisterConfirmPassword = "";

                _mainFormView.CurrentUserLogin = currentUser.Login;
                _mainFormView.LogOutGroupBoxVisible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        public void LogOut(object sender, EventArgs e)
        {
            currentUser = null;
            _configuration["DbConnection"] = "guest";

            _userView?.Close();
            _userView = null;

            _mainFormView.LogOutGroupBoxVisible = false;
            _mainFormView.StartGroupBoxVisible = true;
        }

        public void LogInBack(object sender, EventArgs e)
        {
            _mainFormView.LogInGroupBoxVisible = false;
            _mainFormView.LogInLogin = "";
            _mainFormView.LogInPassword = "";

            _mainFormView.StartGroupBoxVisible = true;
        }

        public void RegisterBack(object sender, EventArgs e)
        {
            _mainFormView.RegisterGroupBoxVisible = false;
            _mainFormView.RegisterLogin = "";
            _mainFormView.RegisterPassword = "";
            _mainFormView.RegisterConfirmPassword = "";

            _mainFormView.StartGroupBoxVisible = true;
        }

        public void MainFormClose(object sender, EventArgs e)
        {
            _mainFormView = null;
            _userView?.Close();
            AppContext.ExitThread();
        }

        public void ChangePermissions(object sender, EventArgs e)
        {
            try
            {
                _userService.changeUserPermissions(_userView.UserProfile.Id);
                _userView.Users = _userService.getAllUsers();
                _userView.UserProfile = _userService.getUser(_userView.UserProfile.Id);
                _userView.ChangePermsVisible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }

        }

        public void OpenUserForm(object sender, UserClickedEventArgs e)
        {
            try
            {
                if (_userView == null)
                {
                    _createUserForm();
                }

                if (e.user != null)
                {
                    _userView.UserProfile = e.user;
                    _userView.UserTournaments = _userService.getUserTournaments(e.user.Id);
                    _userView.UserProfileVisible = true;
                    if (currentUser?.Permission == "admin" && e.user.Permission == "user")
                    {
                        _userView.ChangePermsVisible = true;
                    }
                    else
                    {
                        _userView.ChangePermsVisible = false;
                    }
                }
                else if (currentUser != null)
                {
                    _userView.UserProfile = currentUser;
                    _userView.UserTournaments = _userService.getUserTournaments(currentUser.Id);
                    _userView.UserProfileVisible = true;
                }

                _userView.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        private void _createUserForm()
        {
            _userView = _viewFactory.createUserView();

            //add handlers
            _userView.UserClicked += OpenUserForm;
            _userView.UserFormClosed += UserFormClosed;
            _userView.ChangePermsClicked += ChangePermissions;

            _userView.Users = _userService.getAllUsers();
        }

        public void UserFormClosed(object sender, EventArgs e)
        {
            _userView = null;
        }

    }
}
