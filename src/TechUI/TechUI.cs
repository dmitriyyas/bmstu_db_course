using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Services;
using BL.Models;
using DataAccess.Repositories;
using Microsoft.Extensions.Configuration;
using System.Security;

namespace TechUI
{
    public class TechUI
    {
        private readonly UserService _userService;
        private readonly TournamentService _tournamentService;
        private readonly TeamService _teamService;
        private readonly MatchService _matchService;
        private readonly CountryService _countryService;

        private readonly IConfiguration _configuration;

        private User? currentUser;

        public TechUI(UserService userService, TournamentService tournamentService, TeamService teamService, MatchService matchService, CountryService countryService, IConfiguration configuration)
        {
            _userService = userService;
            _tournamentService = tournamentService;
            _teamService = teamService;
            _matchService = matchService;
            _countryService = countryService;
            _configuration = configuration;

            configuration["DbConnection"] = "guest";
        }

        public void Run()
        {
            _openMainView();
        }

        private void _openMainView()
        {
            int choice = -1;
            while (choice != 0)
            {
                if (currentUser == null)
                {
                    Console.WriteLine("Роль: гость");
                    Console.WriteLine("1 - зарегистрироваться");
                    Console.WriteLine("2 - войти в аккаунт");
                    Console.WriteLine("3 - просмотр информации о пользователях");
                    Console.WriteLine("4 - просмотр информации о странах");
                    Console.WriteLine("5 - просмотр информации о командах");
                    Console.WriteLine("6 - просмотр информации о турнирах");
                    Console.WriteLine("0 - выход");
                    Console.Write("Выбор: ");

                    if (int.TryParse(Console.ReadLine(), out choice))
                    {
                        switch (choice)
                        {
                            case 1:
                                _register();
                                break;
                            case 2:
                                _logIn();
                                break;
                            case 3:
                                _openUserView();
                                break;
                            case 4:
                                _openCountryView();
                                break;
                            case 5:
                                _openTeamView();
                                break;
                            case 6:
                                _openTournamentView();
                                break;
                            case 0:
                                Console.WriteLine("Выход из приложения");
                                break;
                            default:
                                Console.WriteLine("Такого номера нет.");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ошибка ввода.");
                    }
                }
                else
                {
                    if (currentUser.Permission == "user")
                        Console.WriteLine("Роль: гость");
                    else
                        Console.WriteLine("Роль: администратор");

                    Console.WriteLine("1 - выйти из аккаунта");
                    Console.WriteLine("2 - просмотр информации о пользователях");
                    Console.WriteLine("3 - просмотр информации о странах");
                    Console.WriteLine("4 - просмотр информации о командах");
                    Console.WriteLine("5 - просмотр информации о турнирах");
                    Console.WriteLine("0 - выход");
                    Console.Write("Выбор: ");

                    if (int.TryParse(Console.ReadLine(), out choice))
                    {
                        switch (choice)
                        {
                            case 1:
                                _logOut();
                                break;
                            case 2:
                                _openUserView();
                                break;
                            case 3:
                                _openCountryView();
                                break;
                            case 4:
                                _openTeamView();
                                break;
                            case 5:
                                _openTournamentView();
                                break;
                            case 0:
                                Console.WriteLine("Выход из приложения");
                                break;
                            default:
                                Console.WriteLine("Такого номера нет.");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ошибка ввода.");
                    }
                }
            }
        }

        private void _register()
        {
            Console.WriteLine("Регистрация");
            Console.Write("Введите логин: ");
            string? login = Console.ReadLine();
            Console.Write("Введите пароль: ");
            string? password = Console.ReadLine();

            if (login?.Length < 3)
            {
                Console.WriteLine("Некорректный логин.");
                return;
            }

            if (password?.Length < 8)
            {
                Console.WriteLine("Некорректный пароль.");
                return;
            }

            try
            {
                currentUser = _userService.register(login, password);
                _configuration["DbConnection"] = currentUser.Permission;
                Console.WriteLine("Регистрация прошла успешно.");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void _logIn()
        {
            Console.WriteLine("Вход в аккаунт");
            Console.Write("Введите логин: ");
            string? login = Console.ReadLine();
            Console.Write("Введите пароль: ");
            string? password = Console.ReadLine();

            try
            {
                currentUser = _userService.logIn(login, password);
                _configuration["DbConnection"] = currentUser.Permission;
                Console.WriteLine("Вход в аккаунт произошел успешно.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void _logOut()
        {
            currentUser = null;
            _configuration["DbConnection"] = "guest";
            Console.WriteLine("Выход из аккаунта произошел успешно.");
        }

        private void _openUserView()
        {
            int choice = -1;
            while (choice != 0)
            {
                if (currentUser == null || currentUser.Permission == "user")
                {
                    if (currentUser == null)
                        Console.WriteLine("Роль: гость");
                    else
                        Console.WriteLine("Роль: пользователь");
                    Console.WriteLine("1 - вывести всех пользователей");
                    Console.WriteLine("2 - вывести конкретного пользователя");
                    Console.WriteLine("0 - выход");
                    Console.Write("Выбор: ");

                    if (int.TryParse(Console.ReadLine(), out choice))
                    {
                        switch(choice)
                        {
                            case 1:
                                _printAllUsers();
                                break;
                            case 2:
                                _printUser();
                                break;
                            case 0:
                                Console.WriteLine("Выход");
                                break;
                            default:
                                Console.WriteLine("Такого номера нет.");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ошибка ввода.");
                    }
                }
                else
                {
                    Console.WriteLine("Роль: администратор");
                    Console.WriteLine("1 - вывести всех пользователей");
                    Console.WriteLine("2 - вывести конкретного пользователя");
                    Console.WriteLine("3 - изменить права пользователя");
                    Console.WriteLine("0 - выход");
                    Console.Write("Выбор: ");

                    if (int.TryParse(Console.ReadLine(), out choice))
                    {
                        switch (choice)
                        {
                            case 1:
                                _printAllUsers();
                                break;
                            case 2:
                                _printUser();
                                break;
                            case 3:
                                _changePerms();
                                break;
                            case 0:
                                Console.WriteLine("Выход");
                                break;
                            default:
                                Console.WriteLine("Такого номера нет.");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ошибка ввода.");
                    }
                }
            }
        }

        private void _printUserInfo(User user)
        {
            Console.WriteLine($"Id: {user.Id} Логин: {user.Login} Права: {user.Permission}");
        }

        private void _printTournamentInfo(Tournament tournament)
        {
            Console.WriteLine($"Id: {tournament.Id} Название: {tournament.Name} Id страны проведения: {tournament.CountryId}");
        }

        private void _printCountryInfo(Country country)
        {
            Console.WriteLine($"Id: {country.Id} Название: {country.Name} Конфедерация: {country.Confederation}");
        }

        private void _printTeamInfo(Team team)
        {
            Console.WriteLine($"Id: {team.Id} Название: {team.Name} Id страны базирования: {team.CountryId}");
        }

        private void _printMatchInfo(Match match, Team home, Team guest)
        {
            Console.WriteLine($"Id: {match.Id} {home.Name} {match.HomeGoals}:{match.GuestGoals} {guest.Name}");
        }

        private void _printAllUsers()
        {
            try
            {
                var users = _userService.getAllUsers().OrderBy(u => u.Id);
                Console.WriteLine("Информация о всех пользователях:");
                foreach(var user in users)
                {
                    _printUserInfo(user);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void _printUser()
        {
            Console.Write("Введите Id пользователя: ");
            int id;
            if (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Ошибка ввода.");
                return;
            }

            try
            {
                var user = _userService.getUser(id);
                Console.WriteLine($"Id: {user.Id}");
                Console.WriteLine($"Логин: {user.Login}");
                Console.WriteLine($"Права: {user.Permission}");

                var tournaments = _userService.getUserTournaments(id);
                Console.WriteLine("Турниры пользователя:");
                foreach(var tournament in tournaments)
                {
                    _printTournamentInfo(tournament);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void _changePerms()
        {
            Console.Write("Введите Id пользователя: ");
            int id;
            if (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Ошибка ввода.");
                return;
            }

            try
            {
                _userService.changeUserPermissions(id);
                Console.WriteLine("Права пользователя изменены на администратора.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void _openTournamentView()
        {
            int choice = -1;
            while (choice != 0)
            {
                if (currentUser == null)
                {
                    Console.WriteLine("Роль: гость");
                    Console.WriteLine("1 - вывести все турниры");
                    Console.WriteLine("2 - вывести информацию о конкретном турнире");
                    Console.WriteLine("0 - выход");
                    Console.Write("Выбор: ");

                    if (int.TryParse(Console.ReadLine(), out choice))
                    {
                        switch (choice)
                        {
                            case 1:
                                _printAllTournaments();
                                break;
                            case 2:
                                _printTournament();
                                break;
                            case 0:
                                Console.WriteLine("Выход");
                                break;
                            default:
                                Console.WriteLine("Такого номера нет.");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ошибка ввода.");
                    }
                }
                else
                {
                    if (currentUser.Permission == "user")
                        Console.WriteLine("Роль: пользователь");
                    else
                        Console.WriteLine("Роль: администратор");
                    Console.WriteLine("1 - вывести все турниры");
                    Console.WriteLine("2 - вывести информацию о конкретном турнире");
                    Console.WriteLine("3 - создать турнир");
                    Console.WriteLine("4 - удалить свой турнир");
                    Console.WriteLine("5 - создать матч своего турнира");
                    Console.WriteLine("6 - изменить матч своего турнира");
                    Console.WriteLine("7 - удалить матч своего турнира");
                    Console.WriteLine("0 - выход");
                    Console.Write("Выбор: ");

                    if (int.TryParse(Console.ReadLine(), out choice))
                    {
                        switch (choice)
                        {
                            case 1:
                                _printAllTournaments();
                                break;
                            case 2:
                                _printTournament();
                                break;
                            case 3:
                                _createTournament();
                                break;
                            case 4:
                                _deleteTournament();
                                break;
                            case 5:
                                _createMatch();
                                break;
                            case 6:
                                _updateMatch();
                                break;
                            case 7:
                                _deleteMatch();
                                break;
                            case 0:
                                Console.WriteLine("Выход");
                                break;
                            default:
                                Console.WriteLine("Такого номера нет.");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ошибка ввода.");
                    }
                }
            }
        }

        private void _printAllTournaments()
        {
            try
            {
                var tournaments = _tournamentService.getAllTournaments();
                Console.WriteLine("Информация о всех турнирах:");
                foreach(var item in tournaments)
                {
                    _printTournamentInfo(item);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void _printTournament()
        {
            Console.Write("Введите Id турнира: ");
            int id;
            if (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Ошибка ввода.");
                return;
            }

            try
            {
                var tournament = _tournamentService.getTournament(id);
                var user = _userService.getUser(tournament.UserId);
                var country = _countryService.getCountry(id);
                var teams = _tournamentService.getTournamentTeams(id);
                Console.WriteLine($"Id: {tournament.Id}");
                Console.WriteLine($"Название: {tournament.Name}");
                Console.WriteLine($"Создатель турнира: {user.Login}");
                Console.WriteLine($"Страна проведения: {country.Name}");

                var matches = _tournamentService.getTournamentMatches(id);
                Console.WriteLine("Матчи турнира:");
                foreach(var match in matches)
                {
                    _printMatchInfo(match, teams.FirstOrDefault(t => t.Id == match.HomeTeamId), teams.FirstOrDefault(t => t.Id == match.GuestTeamId));
                }

                var table = _tournamentService.getTournamentTable(id);
                Console.WriteLine("Турнирная таблица:");
                foreach(var row in table)
                {
                    Console.WriteLine($"{row.Name};M = {row.Matches};W = {row.Wins};D = {row.Draws};L = {row.Loses};GS = {row.GoalsScored};GC = {row.GoalsConceded};P = {row.Points}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void _createTournament()
        {
            try
            {
                Console.Write("Введите название турнира: ");
                string? name = Console.ReadLine();
                Console.Write("Введите Id страны проведения:");
                int countryId;
                if (!int.TryParse(Console.ReadLine(), out countryId))
                {
                    throw new Exception("Ошибка ввода.");
                }

                List<int> teamIds = new List<int>();
                int id = -1;
                while (id != 0)
                {
                    Console.Write("Введите Id команды или 0, чтобы закончить: ");
                    if (!int.TryParse(Console.ReadLine(), out id))
                    {
                        Console.WriteLine("Ошибка ввода.");
                    }
                    else
                    {
                        teamIds.Add(id);
                    }
                }

                List<Team> teams = new List<Team>();
                foreach (var teamId in teamIds)
                {
                    teams.Add(_teamService.getTeam(teamId));
                }
                var country = _countryService.getCountry(countryId);
                _tournamentService.createTournament(name, currentUser, country, teams);
                Console.WriteLine("Турнир создан успешно.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void _deleteTournament()
        {
            try
            {
                Console.WriteLine("Введите Id турнира: ");
                int id;
                if (!int.TryParse(Console.ReadLine(), out id))
                {
                    throw new Exception("Ошибка ввода.");
                }

                var tournament = _tournamentService.getTournament(id);
                if (tournament.UserId == currentUser.Id)
                {
                    _tournamentService.deleteTournament(id);
                }
                else
                {
                    Console.WriteLine("Вы не можете удалить этот турнир, так как не являетесь его создателем.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void _createMatch()
        {
            try
            { 
                Console.Write("Введите Id турнира: ");
                int id;
                if (!int.TryParse(Console.ReadLine(), out id))
                {
                    throw new Exception("Ошибка ввода.");
                }

                var tournament = _tournamentService.getTournament(id);
                if (tournament.UserId != currentUser.Id)
                {
                    throw new Exception("Вы не можете создать матч, так как не являетесь создателем этого турнира.");
                }

                Console.Write("Введите Id домашней команды: ");
                int homeId;
                if (!int.TryParse(Console.ReadLine(), out homeId))
                {
                    throw new Exception("Ошибка ввода.");
                }
                Console.Write("Введите Id гостевой команды: ");
                int guestId;
                if (!int.TryParse(Console.ReadLine(), out guestId))
                {
                    throw new Exception("Ошибка ввода.");
                }
                Console.Write("Введите количество голов домашней команды: ");
                int homeGoals;
                if (!int.TryParse(Console.ReadLine(), out homeGoals) || homeGoals < 0)
                {
                    throw new Exception("Ошибка ввода.");
                }
                Console.Write("Введите количество голов гостевой команды: ");
                int guestGoals;
                if (!int.TryParse(Console.ReadLine(), out guestGoals) || guestGoals < 0)
                {
                    throw new Exception("Ошибка ввода.");
                }

                var matches = _tournamentService.getTournamentMatches(id);
                var teams = _tournamentService.getTournamentTeams(id);
                if (teams.FirstOrDefault(t => t.Id == homeId) == null)
                {
                    throw new Exception("Домашняя команда с таким Id не учатсвует в этом турнире.");
                }
                if (teams.FirstOrDefault(t => t.Id == guestId) == null)
                {
                    throw new Exception("Гостевая команда с таким Id не учатсвует в этом турнире.");
                }
                if (matches.FirstOrDefault(m => m.HomeTeamId == homeId && m.GuestTeamId == guestId) != null)
                {
                    throw new Exception("Такой матч уже есть.");
                }

                _matchService.createMatch(tournament.Id, homeId, guestId, homeGoals, guestGoals);
                Console.WriteLine("Матч создан успешно.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void _updateMatch()
        {
            try
            {
                Console.Write("Введите Id турнира: ");
                int tournamentId;
                if (!int.TryParse(Console.ReadLine(), out tournamentId))
                {
                    throw new Exception("Ошибка ввода.");
                }

                var tournament = _tournamentService.getTournament(tournamentId);
                if (tournament.UserId != currentUser.Id)
                {
                    throw new Exception("Вы не можете обновить матч, так как не являетесь создателем этого турнира.");
                }

                Console.Write("Введите Id матча: ");
                int id;
                if (!int.TryParse(Console.ReadLine(), out id))
                {
                    throw new Exception("Ошибка ввода.");
                }

                Console.Write("Введите количество голов домашней команды: ");
                int homeGoals;
                if (!int.TryParse(Console.ReadLine(), out homeGoals) || homeGoals < 0)
                {
                    throw new Exception("Ошибка ввода.");
                }
                Console.Write("Введите количество голов гостевой команды: ");
                int guestGoals;
                if (!int.TryParse(Console.ReadLine(), out guestGoals) || guestGoals < 0)
                {
                    throw new Exception("Ошибка ввода.");
                }

                _matchService.updateMatch(id, homeGoals, guestGoals);
                Console.WriteLine("Матч успешно обновлен.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void _deleteMatch()
        {
            try
            {
                Console.Write("Введите Id турнира: ");
                int tournamentId;
                if (!int.TryParse(Console.ReadLine(), out tournamentId))
                {
                    throw new Exception("Ошибка ввода.");
                }

                var tournament = _tournamentService.getTournament(tournamentId);
                if (tournament.UserId != currentUser.Id)
                {
                    throw new Exception("Вы не можете обновить матч, так как не являетесь создателем этого турнира.");
                }

                Console.Write("Введите Id матча: ");
                int id;
                if (!int.TryParse(Console.ReadLine(), out id))
                {
                    throw new Exception("Ошибка ввода.");
                }

                _matchService.deleteMatch(id);
                Console.WriteLine("Матч успешно удален.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void _openTeamView()
        {
            int choice = -1;
            while (choice != 0)
            {
                if (currentUser == null)
                {
                    Console.WriteLine("Роль: гость");
                    Console.WriteLine("1 - вывести все команды");
                    Console.WriteLine("2 - вывести информацию о конкретной команде");
                    Console.WriteLine("0 - выход");
                    Console.Write("Выбор: ");

                    if (int.TryParse(Console.ReadLine(), out choice))
                    {
                        switch(choice)
                        {
                            case 1:
                                _printAllTeams();
                                break;
                            case 2:
                                _printTeam();
                                break;
                            case 0:
                                break;
                            default:
                                Console.WriteLine("Такого номера нет.");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ошибка ввода.");
                    }
                }
                else
                {
                    if (currentUser.Permission == "user")
                        Console.WriteLine("Роль: пользователь");
                    else
                        Console.WriteLine("Роль: администратор");
                    Console.WriteLine("1 - вывести все команды");
                    Console.WriteLine("2 - вывести информацию о конкретной команде");
                    Console.WriteLine("3 - создать команду");
                    Console.WriteLine("0 - выход");
                    Console.Write("Выбор: ");

                    if (int.TryParse(Console.ReadLine(), out choice))
                    {
                        switch (choice)
                        {
                            case 1:
                                _printAllTeams();
                                break;
                            case 2:
                                _printTeam();
                                break;
                            case 3:
                                _createTeam();
                                break;
                            case 0:
                                break;
                            default:
                                Console.WriteLine("Такого номера нет.");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ошибка ввода.");
                    }
                }
            }
        }

        private void _printAllTeams()
        {
            try
            {
                var teams = _teamService.getAllTeams();
                Console.WriteLine("Информация о всех командах:");
                foreach (var team in teams)
                {
                    _printTeamInfo(team);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void _printTeam()
        {
            try
            {
                Console.Write("Введите Id команды: ");
                int id;
                if (!int.TryParse(Console.ReadLine(), out id))
                {
                    throw new Exception("Ошибка ввода.");
                }

                try
                {
                    var team = _teamService.getTeam(id);
                    Console.WriteLine($"Id: {team.Id}");
                    Console.WriteLine($"Название: {team.Name}");
                    Console.WriteLine($"Id страны: {team.CountryId}");

                    var tournaments = _teamService.getTeamTournaments(id);
                    Console.WriteLine("Информация о турнирах команды:");
                    foreach(var tournament in tournaments)
                    {
                        _printTournamentInfo(tournament);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void _createTeam()
        {
            try
            {
                Console.Write("Введите название команды: ");
                string? name = Console.ReadLine();
                if (name?.Length < 2)
                {
                    throw new Exception("Навзание команды должно состоять минимум из 2 символов.");
                }

                Console.Write("Введите Id страны базирования:");
                int countryId;
                if (!int.TryParse(Console.ReadLine(), out countryId))
                {
                    throw new Exception("Ошибка ввода.");
                }

                _teamService.createTeam(name, countryId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void _openCountryView()
        {
            int choice = -1;
            while (choice != 0)
            {
                if (currentUser == null || currentUser.Permission == "user")
                {
                    if (currentUser == null)
                        Console.WriteLine("Роль: гость");
                    else
                        Console.WriteLine("Роль: пользователь");
                    Console.WriteLine("1 - вывести все страны");
                    Console.WriteLine("2 - вывести информацию о конкретной стране");
                    Console.WriteLine("0 - выход");
                    Console.Write("Выбор: ");

                    if (int.TryParse(Console.ReadLine(), out choice))
                    {
                        switch (choice)
                        {
                            case 1:
                                _printAllCountries();
                                break;
                            case 2:
                                _printCountry();
                                break;
                            case 0:
                                break;
                            default:
                                Console.WriteLine("Такого номера нет.");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ошибка ввода.");
                    }
                }
                else
                {
                    Console.WriteLine("Роль: администратор");
                    Console.WriteLine("1 - вывести все страны");
                    Console.WriteLine("2 - вывести информацию о конкретной стране");
                    Console.WriteLine("3 - создать страну");
                    Console.WriteLine("0 - выход");
                    Console.Write("Выбор: ");

                    if (int.TryParse(Console.ReadLine(), out choice))
                    {
                        switch (choice)
                        {
                            case 1:
                                _printAllCountries();
                                break;
                            case 2:
                                _printCountry();
                                break;
                            case 3:
                                _createCountry();
                                break;
                            case 0:
                                break;
                            default:
                                Console.WriteLine("Такого номера нет.");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ошибка ввода.");
                    }
                }
            }
        }

        private void _printAllCountries()
        {
            try
            {
                var countries = _countryService.getAllCountries();
                Console.WriteLine("Информация о всех странах:");
                foreach (var country in countries)
                {
                    _printCountryInfo(country);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void _printCountry()
        {
            try
            {
                Console.Write("Введите Id команды: ");
                int id;
                if (!int.TryParse(Console.ReadLine(), out id))
                {
                    throw new Exception("Ошибка ввода.");
                }

                try
                {
                    var country = _countryService.getCountry(id);
                    Console.WriteLine($"Id: {country.Id}");
                    Console.WriteLine($"Название: {country.Name}");
                    Console.WriteLine($"Конфедерация: {country.Confederation}");

                    var teams = _countryService.getCountryTeams(id);
                    Console.WriteLine("Информация о командах страны:");
                    foreach (var team in teams)
                    {
                        _printTeamInfo(team);
                    }

                    var tournaments = _countryService.getCountryTournaments(id);
                    Console.WriteLine("Информация о турнирах страны:");
                    foreach (var tournament in tournaments)
                    {
                        _printTournamentInfo(tournament);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void _createCountry()
        {
            try
            {
                Console.Write("Введите название страны: ");
                string? name = Console.ReadLine();
                if (name?.Length < 2)
                {
                    throw new Exception("Навзание страны должно состоять минимум из 2 символов.");
                }

                Console.Write("Введите название конфедерации: ");
                string? conf = Console.ReadLine();
                if (name?.Length < 2)
                {
                    throw new Exception("Конфедерация страны должна состоять минимум из 2 символов.");
                }

                _countryService.createCountry(name, conf);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
