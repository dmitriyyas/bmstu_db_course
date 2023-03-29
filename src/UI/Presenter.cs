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
using System.Linq.Expressions;
using System.Diagnostics;
using System.Text.RegularExpressions;

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
        private ITournamentView? _tournamentView;
        private IMatchView? _matchView;

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
            _mainFormView.TournamentClicked += OpenTournamentForm;

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
            _tournamentView?.Close();
            _tournamentView = null;
            _matchView?.Close();
            _matchView = null;

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
            _tournamentView?.Close();
            _matchView?.Close();
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

            _userView.UserClicked += OpenUserForm;
            _userView.UserFormClosed += UserFormClosed;
            _userView.ChangePermsClicked += ChangePermissions;
            _userView.TournamentClicked += OpenTournamentForm;

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
            _countryView.TournamentClicked += OpenTournamentForm;

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
                    _countryView.AddCountryGroupBoxVisible = false;
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

            _teamView.TeamClicked += OpenTeamForm;
            _teamView.AddTeamClicked += AddTeamClicked;
            _teamView.CountryClicked += OpenCountryForm;
            _teamView.ConfirmTeamClicked += ConfirmAddTeamClicked;
            _teamView.TeamFormClosed += TeamFormClosed;
            _teamView.TournamentClicked += OpenTournamentForm;

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
                    _teamView.AddTeamGroupBoxVisible = false;
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

        private void _createTournamentForm()
        {
            _tournamentView = _viewFactory.createTournamentView();

            _tournamentView.TournamentClicked += OpenTournamentForm;
            _tournamentView.TournamentFormClosed += TournamentFormClosed;
            _tournamentView.CountryClicked += OpenCountryForm;
            _tournamentView.UserClicked += OpenUserForm;
            _tournamentView.TeamClicked += OpenTeamForm;
            _tournamentView.AddTournamentClicked += AddTournamentClicked;
            _tournamentView.DeleteTournamentClicked += DeleteTournamentClicked;
            _tournamentView.ShowMatchesClicked += ShowMatchesClicked;
            _tournamentView.ShowTableClicked += ShowTableClicked;
            _tournamentView.AddTeamToNewClicked += AddTeamToNewClicked;
            _tournamentView.DeleteTeamFromNewClicked += DeleteTeamFromNewClicked;
            _tournamentView.ConfirmTournamentClicked += ConfirmAddTournamentClicked;
            _tournamentView.MatchClicked += OpenMatchForm;
            _tournamentView.NotExistedMatchClicked += OpenNotExistedMatchForm;

            _tournamentView.Countries = _countryService.getAllCountries();
            _tournamentView.Users = _userService.getAllUsers();
            _tournamentView.Teams= _teamService.getAllTeams();
            _tournamentView.Tournaments = _tournamentService.getAllTournaments();
            if (currentUser != null)
            {
                _tournamentView.AddTournamentVisible = true;
            }
        }

        public void OpenTournamentForm(object sender, TournamentClickedEventArgs e)
        {
            try
            {
                if (_tournamentView == null)
                {
                    _createTournamentForm();
                }

                if (e.tournament != null)
                {
                    _tournamentView.TournamentProfile = e.tournament;
                    _tournamentView.TournamentTeams = _tournamentService.getTournamentTeams(e.tournament.Id);
                    _tournamentView.Table = _tournamentService.getTournamentTable(e.tournament.Id);
                    _tournamentView.TournamentMatches = _tournamentService.getTournamentMatches(e.tournament.Id);
                    if (currentUser != null)
                    {
                        _tournamentView.AddTournamentVisible = true;
                    }
                    if (currentUser != null && currentUser.Id == e.tournament.UserId)
                        _tournamentView.DeleteTournamentVisible = true;
                    else
                        _tournamentView.DeleteTournamentVisible = false;

                    _tournamentView.AddTournamentGroupBoxVisible = false;
                    _tournamentView.TournamentProfileVisible = true;
                }

                _tournamentView.Show();
                _tournamentView.BringToFront();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        public void AddTournamentClicked(object sender, EventArgs e)
        {
            _tournamentView.AddTournamentVisible = false;
            _tournamentView.TournamentProfileVisible = false;
            _tournamentView.AddTournamentGroupBoxVisible = true;
        }

        public void DeleteTournamentClicked(object sender, EventArgs e)
        {
            try
            {
                _tournamentService.deleteTournament(_tournamentView.TournamentProfile.Id);
                _tournamentView.TournamentProfileVisible = false;
                _tournamentView.Tournaments = _tournamentService.getAllTournaments();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        public void ShowMatchesClicked(object sender, EventArgs e)
        {
            _tournamentView.TableVisible = false;
            _tournamentView.MatchesVisible = true;
        }

        public void ShowTableClicked(object sender, EventArgs e)
        {
            _tournamentView.MatchesVisible = false;
            _tournamentView.TableVisible = true;
        }

        public void AddTeamToNewClicked(object sender, EventArgs e)
        {
            try
            {
                var teams = _tournamentView.NewTournamentTeams;
                var team = _teamService.getAllTeams().FirstOrDefault(t => t.Name == _tournamentView.NewTeamName);
                if (team == null)
                {
                    throw new Exception("Такой команды не существует.");
                }
                if (teams.FirstOrDefault(t => t.Id == team.Id) != null)
                {
                    throw new Exception("Такая команда уже есть в турнире.");
                }
                teams.Add(team);
                _tournamentView.NewTournamentTeams = teams;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        public void DeleteTeamFromNewClicked(object sender, EventArgs e)
        {
            try
            {
                string? name = _tournamentView.SelectedTeamName;
                if (name == null)
                    throw new Exception("Команда для удаления не выбрана.");

                var teams = _tournamentView.NewTournamentTeams;
                var team = _tournamentView.Teams.FirstOrDefault(t => t.Name == name);
                teams.RemoveAll(t => t.Id == team.Id);
                _tournamentView.NewTournamentTeams = teams;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        public void ConfirmAddTournamentClicked(object sender, EventArgs e)
        {
            try
            {
                string name = _tournamentView.NewTournamentName;
                string countryName = _tournamentView.NewTournamentCountry;

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

                var teams = _tournamentView.NewTournamentTeams;
                if (teams.Count < 2)
                {
                    throw new Exception("Турнир должен состоять как минимум из 2 команд.");
                }

                var tournament = _tournamentService.createTournament(name, currentUser.Id, country.Id, teams);

                _tournamentView.TournamentProfile = tournament;
                _tournamentView.TournamentTeams = _tournamentService.getTournamentTeams(tournament.Id);
                _tournamentView.Table = _tournamentService.getTournamentTable(tournament.Id);
                _tournamentView.TournamentMatches = _tournamentService.getTournamentMatches(tournament.Id);
                _tournamentView.Tournaments = _tournamentService.getAllTournaments();

                _tournamentView.AddTournamentVisible = true;
                _tournamentView.DeleteTournamentVisible = true;

                _tournamentView.AddTournamentGroupBoxVisible = false;
                _tournamentView.TournamentProfileVisible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        public void TournamentFormClosed(object sender, EventArgs e)
        {
            _tournamentView = null;
        }

        private void _createMatchView()
        {
            _matchView = _viewFactory.createMatchView();

            _matchView.MatchFormClosed += MatchFormClosed;
            _matchView.TeamClicked += OpenTeamForm;
            _matchView.CreateMatchClicked += CreateMatchClicked;
            _matchView.UpdateMatchClicked += UpdateMatchClicked;
            _matchView.DeleteMatchClicked += DeleteMatchClicked;
        }

        public void OpenMatchForm(object sender, MatchClickedEventArgs e)
        {
            try
            {
                if (_matchView == null)
                {
                    _createMatchView();
                }

                _matchView.MatchProfile = e.match;
                _matchView.Home = _teamService.getTeam(e.match.HomeTeamId);
                _matchView.Guest = _teamService.getTeam(e.match.GuestTeamId);
                _matchView.MatchTournament = _tournamentService.getTournament(e.match.TournamentId);
                _matchView.CreateMatchVisible = false;

                var tournament = _tournamentService.getTournament(e.match.TournamentId);
                if (currentUser != null && currentUser.Id == tournament.UserId)
                {
                    _matchView.EditMatchVisible = true;
                    _matchView.GoalsEnabled = true;
                }
                else
                {
                    _matchView.EditMatchVisible = false;
                    _matchView.GoalsEnabled = false;
                }

                _matchView.Show();
                _matchView.BringToFront();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        public void OpenNotExistedMatchForm(object sender, NotExistedMatchEventArgs e)
        {
            try
            {
                if (_matchView == null)
                {
                    _createMatchView();
                }


                _matchView.Home = e.hostTeam;
                _matchView.Guest = e.guestTeam;
                _matchView.MatchTournament = e.tournament;
                _matchView.HomeGoals = "-";
                _matchView.GuestGoals = "-";
                _matchView.EditMatchVisible = false;

                if (currentUser != null && currentUser.Id == e.tournament.UserId)
                {
                    _matchView.CreateMatchVisible = true;
                    _matchView.GoalsEnabled = true;
                }
                else
                {
                    _matchView.CreateMatchVisible = false;
                    _matchView.GoalsEnabled = false;
                }

                _matchView.Show();
                _matchView.BringToFront();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        public void CreateMatchClicked(object sender, EventArgs e)
        {
            try
            {
                int homeGoals, guestGoals;
                bool isValid = int.TryParse(_matchView.HomeGoals, out homeGoals);
                if (!isValid || homeGoals < 0)
                {
                    throw new Exception("Некорректное значение гола!");
                }

                isValid = int.TryParse(_matchView.GuestGoals, out guestGoals);
                if (!isValid || guestGoals < 0)
                {
                    throw new Exception("Некорректное значение гола!");
                }

                var match = _matchService.createMatch(_matchView.MatchTournament.Id, _matchView.Home.Id, _matchView.Guest.Id, homeGoals, guestGoals);
                OpenMatchForm(this, new MatchClickedEventArgs { match = match });

                if (_tournamentView != null)
                {
                    //OpenTournamentForm(this, new TournamentClickedEventArgs { tournament = _matchView.MatchTournament});
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        public void UpdateMatchClicked(object sender, EventArgs e)
        {
            try
            {
                int homeGoals, guestGoals;
                bool isValid = int.TryParse(_matchView.HomeGoals, out homeGoals);
                if (!isValid || homeGoals < 0)
                {
                    throw new Exception("Некорректное значение гола!");
                }

                isValid = int.TryParse(_matchView.GuestGoals, out guestGoals);
                if (!isValid || guestGoals < 0)
                {
                    throw new Exception("Некорректное значение гола!");
                }

                _matchService.updateMatch(_matchView.MatchProfile.Id, homeGoals, guestGoals);
                OpenMatchForm(this, new MatchClickedEventArgs { match = _matchService.getMatch(_matchView.MatchProfile.Id) });

                if (_tournamentView != null)
                {
                    //OpenTournamentForm(this, new TournamentClickedEventArgs { tournament = _matchView.MatchTournament });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        public void DeleteMatchClicked(object sender, EventArgs e)
        {
            try
            {
                var match = _matchView.MatchProfile;
                var home = _teamService.getTeam(match.HomeTeamId);
                var guest = _teamService.getTeam(match.GuestTeamId);
                var tournament = _tournamentService.getTournament(match.TournamentId);

                _matchService.deleteMatch(match.Id);
                OpenNotExistedMatchForm(this, new NotExistedMatchEventArgs { tournament = tournament, hostTeam = home, guestTeam = guest });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        public void MatchFormClosed(object sender, EventArgs e)
        {
            _matchView = null;
        }
    }
}
