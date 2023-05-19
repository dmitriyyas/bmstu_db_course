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
using Microsoft.Extensions.Logging;

namespace UI
{
    public class Presenter
    {
        private readonly UserService _userService;
        private readonly CountryService _countryService;
        private readonly TeamService _teamService;
        private readonly TournamentService _tournamentService;
        private readonly MatchService _matchService;
        private readonly OutfitterService _outfitterService;

        private readonly IViewFactory _viewFactory;
        private readonly ILogger<Presenter> _logger;

        private IConfiguration _configuration;

        private User currentUser;

        private IMainFormView? _mainFormView;
        private IUserView? _userView;
        private ICountryView? _countryView;
        private ITeamView? _teamView;
        private ITournamentView? _tournamentView;
        private IMatchView? _matchView;
        private IOutfitterView? _outfitterView;

        public ApplicationContext AppContext { get; set; }

        public Presenter(UserService userService, CountryService countryService, TeamService teamService, TournamentService tournamentService, MatchService matchService, OutfitterService outfitterService, IViewFactory viewFactory, IConfiguration configuration, ApplicationContext context, ILogger<Presenter> logger)
        {
            _userService = userService;
            _countryService = countryService;
            _teamService = teamService;
            _tournamentService = tournamentService;
            _matchService = matchService;
            _outfitterService = outfitterService;
            _viewFactory = viewFactory;
            _configuration = configuration;
            _logger = logger;
            AppContext = context;


            _configuration["DbConnection"] = "guest";
            _logger.LogInformation("Presenter started");

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
            _mainFormView.OutfitterClicked += OpenOutfitterForm;

            _mainFormView.Show();
        }

        public void LogIn(object sender, EventArgs e)
        {
            _logger.LogInformation("LogIn clicked");

            _mainFormView.StartGroupBoxVisible = false;
            _mainFormView.LogInGroupBoxVisible = true;
        }

        public void Register(object sender, EventArgs e)
        {
            _logger.LogInformation("Register clicked");

            _mainFormView.StartGroupBoxVisible = false;
            _mainFormView.RegisterGroupBoxVisible = true;
        }

        public void ConfirmLogIn(object sender, EventArgs e)
        {
            _logger.LogInformation("Confirm login clicked");
            try
            {
                currentUser = _userService.logIn(_mainFormView.LogInLogin, _mainFormView.LogInPassword);
                _configuration["DbConnection"] = currentUser.Permission;

                _mainFormView.LogInGroupBoxVisible = false;
                _mainFormView.LogInLogin = "";
                _mainFormView.LogInPassword = "";

                _mainFormView.CurrentUserLogin = currentUser.Login;
                _mainFormView.LogOutGroupBoxVisible = true;

                _logger.LogInformation("LogIn success");
            }
            catch (Exception ex)
            {
                _logger.LogError($"LogIn fail: {ex.Message}");
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        public void ConfirmRegister(object sender, EventArgs e)
        {
            _logger.LogInformation("Confirm register clicked");
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

                _logger.LogInformation("Register success");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Register error: {ex.Message}");
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        public void LogOut(object sender, EventArgs e)
        {
            _logger.LogInformation("LogOut clicked");

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
            _outfitterView?.Close();
            _outfitterView = null;

            _mainFormView.LogOutGroupBoxVisible = false;
            _mainFormView.StartGroupBoxVisible = true;
        }

        public void LogInBack(object sender, EventArgs e)
        {
            _logger.LogInformation("LogInBack clicked");

            _mainFormView.LogInGroupBoxVisible = false;
            _mainFormView.LogInLogin = "";
            _mainFormView.LogInPassword = "";

            _mainFormView.StartGroupBoxVisible = true;
        }

        public void RegisterBack(object sender, EventArgs e)
        {
            _logger.LogInformation("RegisterBack clicked");

            _mainFormView.RegisterGroupBoxVisible = false;
            _mainFormView.RegisterLogin = "";
            _mainFormView.RegisterPassword = "";
            _mainFormView.RegisterConfirmPassword = "";

            _mainFormView.StartGroupBoxVisible = true;
        }

        public void MainFormClose(object sender, EventArgs e)
        {
            _logger.LogInformation("MainForm closed");

            _mainFormView = null;
            _userView?.Close();
            _countryView?.Close();
            _teamView?.Close();
            _tournamentView?.Close();
            _matchView?.Close();
            _outfitterView?.Close();

            AppContext.ExitThread();
        }

        private void _loadUserViewProfile(User user)
        {
            _userView.UserProfile = _userService.getUser(user.Id);
            _userView.UserTournaments = _userService.getUserTournaments(user.Id);
            if (currentUser?.Permission == "admin" && user.Permission == "user")
            {
                _userView.ChangePermsVisible = true;
            }
            else
            {
                _userView.ChangePermsVisible = false;
            }
            _userView.UserProfileVisible = true;
        }

        private void _loadUserViewEmpty()
        {
            _userView.UserProfileVisible = false;
        }

        private void _reloadUsers()
        {
            if (_userView != null)
            {
                _userView.Users = _userService.getAllUsers();
            }
        }

        public void ChangePermissions(object sender, EventArgs e)
        {
            _logger.LogInformation("ChangePermissions clicked");
            try
            {
                _userService.changeUserPermissions(_userView.UserProfile.Id);
                _reloadUsers();
                _loadUserViewProfile(_userView.UserProfile);

                _logger.LogInformation("Permissions successfully changed");
            }
            catch (Exception ex)
            {
                _logger.LogError($"ChangePermissions error: {ex.Message}");
                MessageBox.Show(ex.Message, "Ошибка");
            }

        }

        public void OpenUserForm(object sender, UserClickedEventArgs e)
        {
            _logger.LogInformation("OpenUserForm clicked");
            try
            {
                if (_userView == null)
                {
                    _createUserForm();
                }

                if (e.user != null)
                {
                    _loadUserViewProfile(e.user);
                }
                else if (currentUser != null)
                {
                    _loadUserViewProfile(currentUser);
                }
                else
                {
                    _loadUserViewEmpty();
                }

                _userView.Show();
                _userView.BringToFront();
                _logger.LogInformation("UserForm succesfully opened");
            }
            catch (Exception ex)
            {
                _logger.LogError($"OpenUserForm error: {ex.Message}");
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
            _logger.LogInformation("UserForm closed");
            _userView = null;
        }

        private void _loadCountryViewEmpty()
        {
            if (currentUser?.Permission == "admin")
            {
                _countryView.AddCountryVisible = true;
            }
            _countryView.AddCountryGroupBoxVisible = false;
            _countryView.CountryProfileVisible = false;
        }

        private void _loadCountryViewProfile(Country country)
        {
            if (currentUser?.Permission == "admin")
            {
                _countryView.AddCountryVisible = true;
            }
            _countryView.CountryProfile = country;
            _countryView.CountryTeams = _countryService.getCountryTeams(country.Id);
            _countryView.CountryTournaments = _countryService.getCountryTournaments(country.Id);
            _countryView.AddCountryGroupBoxVisible = false;
            _countryView.CountryProfileVisible = true;
        }

        private void _loadCountryViewCreating()
        {
            _countryView.AddCountryVisible = false;
            _countryView.CountryProfileVisible = false;
            _countryView.AddCountryGroupBoxVisible = true;

            _countryView.NewCountryName = "";
            _countryView.NewCountryConfederation = "";
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
        }

        private void _reloadCountries()
        {
            if (_countryView != null)
            {
                _countryView.Countries = _countryService.getAllCountries();
            }
            if (_teamView!= null)
            {
                _teamView.Countries = _countryService.getAllCountries();
            }
            if (_tournamentView != null)
            {
                _tournamentView.Countries = _countryService.getAllCountries();
            }
        }

        public void OpenCountryForm(object sender, CountryClickedEventArgs e)
        {
            _logger.LogInformation("OpenCountryForm clicked");
            try
            {
                if (_countryView == null)
                {
                    _createCountryForm();
                }

                if (e.country != null)
                {
                    _loadCountryViewProfile(e.country);
                }
                else
                {
                    _loadCountryViewEmpty();
                }

                _countryView.Show();
                _countryView.BringToFront();

                _logger.LogInformation("CountryForm succesfully opened");
            }
            catch (Exception ex)
            {
                _logger.LogError($"OpenCountryForm error: {ex.Message}");
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        public void AddCountryClicked(object sender, EventArgs e)
        {
            _logger.LogInformation("AddCountry clicked");
            _loadCountryViewCreating();
        }

        public void ConfirmAddCountryClicked(object sender, EventArgs e)
        {
            _logger.LogInformation("ConfirmAddCountry clicked");
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
                _reloadCountries();
                _loadCountryViewProfile(country);
                _logger.LogInformation("Country successfully added");
            }
            catch (Exception ex)
            {
                _logger.LogError($"ConfirmAddCountry error: {ex.Message}");
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
            _teamView.OutfitterClicked += OpenOutfitterForm;

            _teamView.Countries = _countryService.getAllCountries();
            _teamView.Outfitters = _outfitterService.getAllOutfitters();
            _teamView.Teams = _teamService.getAllTeams();
        }

        private void _loadTeamViewEmpty()
        {
            if (currentUser != null)
            {
                _teamView.AddTeamVisible = true;
            }
            _teamView.AddTeamGroupBoxVisible = false;
            _teamView.TeamProfileVisible = false;
        }

        private void _loadTeamViewProfile(Team team)
        {
            if (currentUser != null)
            {
                _teamView.AddTeamVisible = true;
            }

            _teamView.TeamProfile = team;
            _teamView.TeamTournaments = _teamService.getTeamTournaments(team.Id);
            _teamView.AddTeamGroupBoxVisible = false;
            _teamView.TeamProfileVisible = true;
        }

        private void _loadTeamViewCreating()
        {
            _teamView.AddTeamVisible = false;
            _teamView.TeamProfileVisible = false;
            _teamView.AddTeamGroupBoxVisible = true;
            _teamView.NewTeamName = "";
            _teamView.NewTeamCountry = "";
        }

        private void _reloadTeams()
        {
            if (_teamView != null)
            {
                _teamView.Teams = _teamService.getAllTeams();
            }
            if (_countryView?.CountryProfile != null)
            {
                _countryView.CountryTeams = _countryService.getCountryTeams(_countryView.CountryProfile.Id);
            }
            if (_tournamentView != null)
            {
                _tournamentView.Teams = _teamService.getAllTeams();
            }
        }

        public void OpenTeamForm(object sender, TeamClickedEventArgs e)
        {
            _logger.LogInformation("OpenTeamForm clicked");
            try
            {
                if (_teamView == null)
                {
                    _createTeamForm();
                }

                if (e.team != null)
                {
                    _loadTeamViewProfile(e.team);
                }
                else
                {
                    _loadTeamViewEmpty();
                }

                _teamView.Show();
                _teamView.BringToFront();
                _logger.LogInformation("TeamForm successfully opened");
            }
            catch (Exception ex)
            {
                _logger.LogError($"OpenTeamForm error: {ex.Message}");
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        public void AddTeamClicked(object sender, EventArgs e)
        {
            _logger.LogInformation("AddTeam clicked");
            _loadTeamViewCreating();
        }

        public void ConfirmAddTeamClicked(object sender, EventArgs e)
        {
            _logger.LogInformation("ConfirmAddTeam clicked");
            try
            {
                string name = _teamView.NewTeamName;
                string countryName = _teamView.NewTeamCountry;
                string outfitterName = _teamView.NewTeamOutfitter;

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

                Outfitter outfitter = _outfitterService.getAllOutfitters().FirstOrDefault(o => o.Name == outfitterName);

                Team team = _teamService.createTeam(name, country.Id, outfitter?.Id);
                _reloadTeams();
                _loadTeamViewProfile(team);
                _logger.LogInformation("Team successfully added");
            }
            catch (Exception ex)
            {
                _logger.LogError($"ConfirmAddTeam error: {ex.Message}");
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        public void TeamFormClosed(object sender, EventArgs e)
        {
            _logger.LogInformation("TeamForm closed");
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
            _tournamentView.Tournaments = _tournamentService.getAllTournaments();
        }

        private void _loadTournamentViewEmpty()
        {
            if (currentUser != null)
            {
                _tournamentView.AddTournamentVisible = true;
            }

            _tournamentView.AddTournamentGroupBoxVisible = false;
            _tournamentView.TournamentProfileVisible = false;
        }

        private void _loadTournamentViewProfile(Tournament tournament)
        {
            if (currentUser != null)
            {
                _tournamentView.AddTournamentVisible = true;
            }

            _tournamentView.TournamentProfile = tournament;
            _tournamentView.TournamentTeams = _tournamentService.getTournamentTeams(tournament.Id);
            _tournamentView.Table = _tournamentService.getTournamentTable(tournament.Id);
            _tournamentView.TournamentMatches = _tournamentService.getTournamentMatches(tournament.Id);

            if (currentUser != null && currentUser.Id == tournament.UserId)
                _tournamentView.DeleteTournamentVisible = true;
            else
                _tournamentView.DeleteTournamentVisible = false;

            _tournamentView.AddTournamentGroupBoxVisible = false;
            _tournamentView.TournamentProfileVisible = true;
        }

        private void _loadTournamentViewCreating()
        {
            _tournamentView.Teams = _teamService.getAllTeams();

            _tournamentView.AddTournamentVisible = false;
            _tournamentView.TournamentProfileVisible = false;
            _tournamentView.AddTournamentGroupBoxVisible = true;

            _tournamentView.NewTournamentName = "";
            _tournamentView.NewTournamentTeams.Clear();
            _tournamentView.NewTournamentCountry = "";
            _tournamentView.NewTeamName = "";
        }

        private void _reloadTournaments()
        {
            if (_tournamentView != null)
            {
                _tournamentView.Tournaments = _tournamentService.getAllTournaments();
            }
            if (_teamView?.TeamProfile != null)
            {
                _teamView.TeamTournaments = _teamService.getTeamTournaments(_teamView.TeamProfile.Id);
            }
            if (_countryView?.CountryProfile != null)
            {
                _countryView.CountryTournaments = _countryService.getCountryTournaments(_countryView.CountryProfile.Id);
            }
            if (_userView?.UserProfile != null)
            {
                _userView.UserTournaments = _userService.getUserTournaments(_userView.UserProfile.Id);
            }
        }

        public void OpenTournamentForm(object sender, TournamentClickedEventArgs e)
        {
            _logger.LogInformation("OpenTournamentForm clicked");
            try
            {
                if (_tournamentView == null)
                {
                    _createTournamentForm();
                }

                if (e.tournament != null)
                {
                    _loadTournamentViewProfile(e.tournament);
                }
                else
                {
                    _loadTournamentViewEmpty();
                }

                _tournamentView.Show();
                _tournamentView.BringToFront();
                _logger.LogInformation("TournamentForm successfully opened");
            }
            catch(Exception ex)
            {
                _logger.LogError($"OpenTournamentForm error: {ex.Message}");
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        public void AddTournamentClicked(object sender, EventArgs e)
        {
            _logger.LogInformation("AddTournament clicked");
            _loadTournamentViewCreating();
        }

        public void DeleteTournamentClicked(object sender, EventArgs e)
        {
            _logger.LogInformation("DeleteTournament clicked");
            try
            {
                _tournamentService.deleteTournament(_tournamentView.TournamentProfile.Id);
                _reloadTournaments();
                _loadTournamentViewEmpty();
                _logger.LogInformation("Tournament successfully deleted");
            }
            catch (Exception ex)
            {
                _logger.LogError($"DeleteTournament error: {ex.Message}");
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        public void ShowMatchesClicked(object sender, EventArgs e)
        {
            _logger.LogInformation("ShowMatches clicked");
            _tournamentView.TableVisible = false;
            _tournamentView.MatchesVisible = true;
        }

        public void ShowTableClicked(object sender, EventArgs e)
        {
            _logger.LogInformation("ShowTable clicked");
            _tournamentView.MatchesVisible = false;
            _tournamentView.TableVisible = true;
        }

        public void AddTeamToNewClicked(object sender, EventArgs e)
        {
            _logger.LogInformation("AddTeamToNew clicked");
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
                _logger.LogInformation("Team successfully added to new");
            }
            catch (Exception ex)
            {
                _logger.LogError($"AddTeamToNew error: {ex.Message}");
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        public void DeleteTeamFromNewClicked(object sender, EventArgs e)
        {
            _logger.LogInformation("DeleteTeamFromNew clicked");
            try
            {
                string? name = _tournamentView.SelectedTeamName;
                if (name == null)
                    throw new Exception("Команда для удаления не выбрана.");

                var teams = _tournamentView.NewTournamentTeams;
                var team = _tournamentView.Teams.FirstOrDefault(t => t.Name == name);
                teams.RemoveAll(t => t.Id == team.Id);
                _tournamentView.NewTournamentTeams = teams;
                _logger.LogInformation("Team successfully deleted from new");
            }
            catch (Exception ex)
            {
                _logger.LogError($"DeleteTEamFromNew error: {ex.Message}");
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        public void ConfirmAddTournamentClicked(object sender, EventArgs e)
        {
            _logger.LogInformation("ConfirmAddTournament clicked");
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

                var tournament = _tournamentService.createTournament(name, currentUser, country, teams);
                _teamService.getAllTeams();
                _loadTournamentViewProfile(tournament);
                _logger.LogInformation("Tournament successfully added");
            }
            catch (Exception ex)
            {
                _logger.LogError($"ConfirmAddTournament error: {ex.Message}");
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        public void TournamentFormClosed(object sender, EventArgs e)
        {
            _logger.LogInformation("TournamentForm closed");
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

        private void _loadMatchViewProfile(Match match)
        {
            _matchView.MatchProfile = match;
            _matchView.Home = _teamService.getTeam(match.HomeTeamId);
            _matchView.Guest = _teamService.getTeam(match.GuestTeamId);
            _matchView.MatchTournament = _tournamentService.getTournament(match.TournamentId);
            _matchView.CreateMatchVisible = false;

            var tournament = _tournamentService.getTournament(match.TournamentId);
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
        }

        private void _loadMatchViewEmpty(Tournament tournament, Team home, Team guest)
        {
            _matchView.Home = home;
            _matchView.Guest = guest;
            _matchView.MatchTournament = tournament;
            _matchView.HomeGoals = "-";
            _matchView.GuestGoals = "-";
            _matchView.EditMatchVisible = false;

            if (currentUser != null && currentUser.Id == tournament.UserId)
            {
                _matchView.CreateMatchVisible = true;
                _matchView.GoalsEnabled = true;
            }
            else
            {
                _matchView.CreateMatchVisible = false;
                _matchView.GoalsEnabled = false;
            }
        }

        private void _reloadMatches()
        {
            if (_tournamentView?.TournamentProfile != null)
            {
                _tournamentView.TournamentMatches = _tournamentService.getTournamentMatches(_tournamentView.TournamentProfile.Id);
                _tournamentView.Table = _tournamentService.getTournamentTable(_tournamentView.TournamentProfile.Id);
            }
        }

        public void OpenMatchForm(object sender, MatchClickedEventArgs e)
        {
            _logger.LogInformation("OpenMatchForm clicked");
            try
            {
                if (_matchView == null)
                {
                    _createMatchView();
                }

                _loadMatchViewProfile(e.match);

                _matchView.Show();
                _matchView.BringToFront();
                _logger.LogInformation("Match form successfully opened");
            }
            catch (Exception ex)
            {
                _logger.LogError($"OpenMatchForm error: {ex.Message}");
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        public void OpenNotExistedMatchForm(object sender, NotExistedMatchEventArgs e)
        {
            _logger.LogWarning("OpenNotExistedMatchForm clicked");
            try
            {
                if (_matchView == null)
                {
                    _createMatchView();
                }

                _loadMatchViewEmpty(e.tournament, e.hostTeam, e.guestTeam);
                
                _matchView.Show();
                _matchView.BringToFront();
                _logger.LogInformation("Match form successfully opened");
            }
            catch (Exception ex)
            {
                _logger.LogError($"OpenNotExistedMatchForm error: {ex.Message}");
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        public void CreateMatchClicked(object sender, EventArgs e)
        {
            _logger.LogInformation("CreateMatch clicked");
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
                _loadMatchViewProfile(match);

                _reloadMatches();

                _logger.LogInformation("Match successfully created");
            }
            catch (Exception ex)
            {
                _logger.LogError($"CreateMatch error: {ex.Message}");
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        public void UpdateMatchClicked(object sender, EventArgs e)
        {
            _logger.LogInformation("UpdateMatch clicked");
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
                _loadMatchViewProfile(_matchService.getMatch(_matchView.MatchProfile.Id));

                _reloadMatches();
                _logger.LogInformation("Match successfully updated");
            }
            catch (Exception ex)
            {
                _logger.LogError($"UpdateMatch error: {ex.Message}");
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        public void DeleteMatchClicked(object sender, EventArgs e)
        {
            _logger.LogInformation("DeleteMatch clicked");
            try
            {
                var match = _matchView.MatchProfile;
                var home = _teamService.getTeam(match.HomeTeamId);
                var guest = _teamService.getTeam(match.GuestTeamId);
                var tournament = _tournamentService.getTournament(match.TournamentId);

                _matchService.deleteMatch(match.Id);
                _loadMatchViewEmpty(tournament, home, guest);
                _reloadMatches();

                _logger.LogInformation("Match successfully deleted");
            }
            catch (Exception ex)
            {
                _logger.LogError($"DeleteMatch error: {ex.Message}");
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        public void MatchFormClosed(object sender, EventArgs e)
        {
            _logger.LogInformation("MatchForm closed");
            _matchView = null;
        }

        private void _loadOutfitterViewEmpty()
        {
            if (currentUser?.Permission == "admin")
            {
                _outfitterView.AddOutfitterVisible = true;
            }
            _outfitterView.AddOutfitterGroupBoxVisible = false;
            _outfitterView.OutfitterProfileVisible = false;
        }

        private void _loadOutfitterViewProfile(Outfitter outfitter)
        {
            if (currentUser?.Permission == "admin")
            {
                _outfitterView.AddOutfitterVisible = true;
            }
            _outfitterView.OutfitterProfile = outfitter;
            _outfitterView.OutfitterTeams = _outfitterService.getOutfitterTeams(outfitter.Id);
            _outfitterView.AddOutfitterGroupBoxVisible = false;
            _outfitterView.OutfitterProfileVisible = true;
        }

        private void _loadOutfitterViewCreating()
        {
            _outfitterView.AddOutfitterVisible = false;
            _outfitterView.OutfitterProfileVisible = false;
            _outfitterView.AddOutfitterGroupBoxVisible = true;

            _outfitterView.NewOutfitterName = "";
            _outfitterView.NewOutfitterYear = "";
        }

        private void _createOutfitterForm()
        {
            _outfitterView = _viewFactory.createOutfitterView();

            _outfitterView.OutfitterClicked += OpenOutfitterForm;
            _outfitterView.AddOutfitterClicked += AddOutfitterClicked;
            _outfitterView.ConfirmAddOutfitterClicked += ConfirmAddOutfitterClicked;
            _outfitterView.OutfitterFormClosed += OutfitterFormClosed;
            _outfitterView.TeamClicked += OpenTeamForm;

            _outfitterView.Outfitters = _outfitterService.getAllOutfitters();
        }

        private void _reloadOutfitters()
        {
            if (_outfitterView != null)
            {
                _outfitterView.Outfitters = _outfitterService.getAllOutfitters();
            }
            if (_teamView != null)
            {
                _teamView.Outfitters = _outfitterService.getAllOutfitters();
            }
        }

        public void OpenOutfitterForm(object sender, OutfitterClickedEventArgs e)
        {
            _logger.LogInformation("OpenOutfitterForm clicked");
            try
            {
                if (_outfitterView == null)
                {
                    _createOutfitterForm();
                }

                if (e.outfitter != null)
                {
                    _loadOutfitterViewProfile(e.outfitter);
                }
                else
                {
                    _loadOutfitterViewEmpty();
                }

                _outfitterView.Show();
                _outfitterView.BringToFront();

                _logger.LogInformation("OutfitterForm succesfully opened");
            }
            catch (Exception ex)
            {
                _logger.LogError($"OpenOutfitterForm error: {ex.Message}");
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        public void AddOutfitterClicked(object sender, EventArgs e)
        {
            _logger.LogInformation("AddOutfitter clicked");
            _loadOutfitterViewCreating();
        }

        public void ConfirmAddOutfitterClicked(object sender, EventArgs e)
        {
            _logger.LogInformation("ConfirmAddOutfitter clicked");
            try
            {
                string name = _outfitterView.NewOutfitterName;
                string yearStr = _outfitterView.NewOutfitterYear;

                if (name.Length == 0)
                {
                    throw new Exception("Вы не ввели название производителя!");
                }

                if (yearStr.Length == 0)
                {
                    throw new Exception("Вы не ввели год основания!");
                }

                int year;
                if (!int.TryParse(yearStr, out year) || year <= 0)
                {
                    throw new Exception("Некорректный год основания.");
                }

                Outfitter outfitter = _outfitterService.createOutfitter(name, year);
                _reloadOutfitters();
                _loadOutfitterViewProfile(outfitter);
                _logger.LogInformation("Outfitter successfully added");
            }
            catch (Exception ex)
            {
                _logger.LogError($"ConfirmAddOutfitter error: {ex.Message}");
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        public void OutfitterFormClosed(object sender, EventArgs e)
        {
            _outfitterView = null;
        }
    }
}
