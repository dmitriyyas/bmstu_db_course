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
        private ICountryView? _countryView;
        private ITeamView? _teamView;

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
            _mainFormView.CountryClicked += OpenCountryForm;
            _mainFormView.TeamClicked += OpenTeamForm;
            //add other form opens

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
            _countryView?.Close();
            _countryView = null;
            _teamView?.Close();
            _teamView = null;
            //close other forms

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
            _countryView?.Close();
            _teamView?.Close();
            //close other forms
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
                _userView.BringToFront();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        private void _createUserForm()
        {
            _userView = _viewFactory.createUserView();

            //add tournament open
            _userView.UserClicked += OpenUserForm;
            _userView.UserFormClosed += UserFormClosed;
            _userView.ChangePermsClicked += ChangePermissions;

            _userView.Users = _userService.getAllUsers();
        }

        public void UserFormClosed(object sender, EventArgs e)
        {
            _userView = null;
        }

        private void _createCountryForm()
        {
            _countryView = _viewFactory.createCountryView();

            _countryView.CountryClicked += OpenCountryForm;
            _countryView.AddCountryClicked += AddCountryClicked;
            _countryView.ConfirmAddCountryClicked += ConfirmAddCountryClicked;
            _countryView.CountryFormClosed += CountryFormClosed;
            _countryView.TeamClicked += OpenTeamForm;
            //add tournament click

            _countryView.Countries = _countryService.getAllCountries();
            if (currentUser?.Permission == "admin")
            {
                _countryView.AddCountryVisible = true;
            }
        }

        public void OpenCountryForm(object sender, CountryClickedEventArgs e)
        {
            try
            {
                if (_countryView == null)
                {
                    _createCountryForm();
                }

                if (e.country != null)
                {
                    _countryView.CountryProfile = e.country;
                    _countryView.CountryTeams = _countryService.getCountryTeams(e.country.Id);
                    _countryView.CountryTournaments = _countryService.getCountryTournaments(e.country.Id);
                    _countryView.CountryProfileVisible = true;
                    if (currentUser?.Permission == "admin")
                    {
                        _countryView.AddCountryVisible = true;
                    }
                }

                _countryView.Show();
                _countryView.BringToFront();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        public void AddCountryClicked(object sender, EventArgs e)
        {
            _countryView.AddCountryVisible = false;
            _countryView.CountryProfileVisible = false;
            _countryView.AddCountryGroupBoxVisible = true;
        }

        public void ConfirmAddCountryClicked(object sender, EventArgs e)
        {
            try
            {
                string name = _countryView.NewCountryName;
                string confederation = _countryView.NewCountryConfederation;

                if (name.Length == 0)
                {
                    throw new Exception("Вы не ввели название страны!");
                }

                if (confederation.Length == 0)
                {
                    throw new Exception("Вы не ввели конфедерацию!");
                }

                Country country = _countryService.createCountry(name, confederation);
                _countryView.CountryProfile = country;
                _countryView.Countries = _countryService.getAllCountries();
                _countryView.CountryTeams = _countryService.getCountryTeams(country.Id);
                _countryView.CountryTournaments = _countryService.getCountryTournaments(country.Id);

                _countryView.AddCountryGroupBoxVisible = false;
                _countryView.CountryProfileVisible = true;
                _countryView.AddCountryVisible = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        public void CountryFormClosed(object sender, EventArgs e)
        {
            _countryView = null;
        }

        private void _createTeamForm()
        {
            _teamView = _viewFactory.createTeamView();

            //add tournament click
            _teamView.TeamClicked += OpenTeamForm;
            _teamView.AddTeamClicked += AddTeamClicked;
            _teamView.CountryClicked += OpenCountryForm;
            _teamView.ConfirmTeamClicked += ConfirmAddTeamClicked;
            _teamView.TeamFormClosed += TeamFormClosed;

            _teamView.Countries = _countryService.getAllCountries();
            _teamView.Teams = _teamService.getAllTeams();
            if (currentUser != null)
            {
                _teamView.AddTeamVisible = true;
            }
        }

        public void OpenTeamForm(object sender, TeamClickedEventArgs e)
        {
            try
            {
                if (_teamView == null)
                {
                    _createTeamForm();
                }

                if (e.team != null)
                {
                    _teamView.TeamProfile = e.team;
                    _teamView.TeamTournaments = _teamService.getTeamTournaments(e.team.Id);
                    _teamView.TeamProfileVisible = true;
                    if (currentUser != null)
                    {
                        _teamView.AddTeamVisible = true;
                    }
                }

                _teamView.Show();
                _teamView.BringToFront();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        public void AddTeamClicked(object sender, EventArgs e)
        {
            _teamView.AddTeamVisible = false;
            _teamView.TeamProfileVisible = false;
            _teamView.AddTeamGroupBoxVisible = true;
        }

        public void ConfirmAddTeamClicked(object sender, EventArgs e)
        {
            try
            {
                string name = _teamView.NewTeamName;
                string countryName = _teamView.NewTeamCountry;

                if (name.Length == 0)
                {
                    throw new Exception("Вы не ввели название команды!");
                }

                if (countryName.Length == 0)
                {
                    throw new Exception("Вы не выбрали страну!");
                }

                Country country = _countryService.getAllCountries().FirstOrDefault(c => c.Name == countryName);

                if (country == null)
                {
                    throw new Exception("Такой страны нет!");
                }

                Team team = _teamService.createTeam(name, country.Id);

                _teamView.TeamProfile = team;
                _teamView.Teams = _teamService.getAllTeams();
                _teamView.TeamTournaments = _teamService.getTeamTournaments(team.Id);

                _teamView.AddTeamGroupBoxVisible = false;
                _teamView.TeamProfileVisible = true;
                _teamView.AddTeamVisible = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        public void TeamFormClosed(object sender, EventArgs e)
        {
            _teamView = null;
        }
    }
}
