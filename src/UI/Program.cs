using System.Configuration;
using System.Diagnostics;
using BL.Models;
using BL.RepositoryInterfaces;
using BL.Services;
using DataAccess;
using DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
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
            //Application.Run(new WinFormMainView());

            ApplicationContext appContext = new ApplicationContext();

            IConfiguration configuration = new ConfigurationBuilder()
                                                //.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\..\\"))
                                                .AddJsonFile("appsettings.json")
                                                .Build();

            var builder = new HostBuilder().ConfigureServices((hostContext, services) =>
            {
                services.AddSingleton<IDbContextFactory, PgSQLDbContextFactory>();
                services.AddSingleton<IViewFactory, WinFormViewFactory>();

                services.AddSingleton(configuration);
                services.AddSingleton(appContext);
                services.AddSingleton<Presenter>();

                services.AddScoped<IUserRepository, UserRepository>();
                services.AddScoped<ITeamTournamentRepository, TeamTournamentRepository>();
                services.AddScoped<ITeamRepository, TeamRepository>();
                services.AddScoped<ICountryRepository, CountryRepository>();
                services.AddScoped<ITournamentRepository, TournamentRepository>();
                services.AddScoped<IMatchRepository, MatchRepository>();

                services.AddScoped<UserService>();
                services.AddScoped<TeamService>();
                services.AddScoped<TournamentService>();
                services.AddScoped<MatchService>();
                services.AddScoped<CountryService>();
            });

            var host = builder.Build();

            using (var serviceScope = host.Services.CreateScope())
            {
                var services = serviceScope.ServiceProvider;
                try
                {
                    /*
                    var countryService = services.GetRequiredService<CountryService>();
                    var userService = services.GetRequiredService<UserService>();
                    var teamService = services.GetRequiredService<TeamService>();
                    var tournamentService = services.GetRequiredService<TournamentService>();

                    var country = countryService.createCountry("Russia", "UEFA");
                    var user = userService.register("test", "test");
                    var team = teamService.createTeam("Dinamo", country.Id);
                    var tournament = tournamentService.createTournament("RPL", user.Id, country.Id, new List<Team> { team });
                    */
                    var presenter = services.GetRequiredService<Presenter>();
                    Application.Run(presenter.AppContext);

                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
            }

        }
    }
}