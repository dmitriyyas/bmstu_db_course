using System.Diagnostics;
using BL.Models;
using BL.RepositoryInterfaces;
using BL.Services;
using DataAccess.DBContext;
using DataAccess.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using UI.WinFormViews;

namespace UI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            ApplicationConfiguration.Initialize();
            Application.Run(new WinFormMainView());

            /*IConfiguration configuration = new ConfigurationBuilder()
                                                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\..\\"))
                                                .AddJsonFile("appsettings.json")
                                                .Build();

            var builder = new HostBuilder().ConfigureServices((hostContext, services) =>
            {
                services.AddSingleton(configuration);
                services.AddDbContext<AdminDbContext>();
                services.AddDbContext<UserDbContext>();
                services.AddDbContext<GuestDbContext>();
                services.AddSingleton<DbContextFactory>();

                services.AddTransient<IUserRepository, UserRepository>();
                services.AddTransient<ITeamTournamentRepository, TeamTournamentRepository>();
                services.AddTransient<ITeamRepository, TeamRepository>();
                services.AddTransient<ICountryRepository, CountryRepository>();
                services.AddTransient<ITournamentRepository, TournamentRepository>();
                services.AddTransient<IMatchRepository, MatchRepository>();

                services.AddTransient<UserService>();
                services.AddTransient<TeamService>();
                services.AddTransient<TournamentService>();
                services.AddTransient<MatchService>();
                services.AddTransient<CountryService>();
            });

            var host = builder.Build();

            using (var serviceScope = host.Services.CreateScope())
            {
                var services = serviceScope.ServiceProvider;
                try
                {
                    var countryService = services.GetRequiredService<CountryService>();
                    var userService = services.GetRequiredService<UserService>();
                    var teamService = services.GetRequiredService<TeamService>();
                    var tournamentService = services.GetRequiredService<TournamentService>();

                    var country = countryService.createCountry("Russia", "UEFA");
                    var user = userService.register("test", "test");
                    var team = teamService.createTeam("Dinamo", country.Id);
                    var tournament = tournamentService.createTournament("RPL", user.Id, country.Id, new List<Team> { team });
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
            }*/

        }
    }
}