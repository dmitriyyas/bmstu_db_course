using BL.Services;
using BL.Models;
using BL.RepositoryInterfaces;
using DataAccess.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Diagnostics;
using DataAccess;

namespace TechUI
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                                                //.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\..\\"))
                                                .AddJsonFile("appsettings.json")
                                                .Build();

            var builder = new HostBuilder().ConfigureServices((hostContext, services) =>
            {
                services.AddSingleton<IDbContextFactory, PgSQLDbContextFactory>();

                services.AddSingleton(configuration);

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

                services.AddSingleton<TechUI>();
            });

            var host = builder.Build();

            using (var serviceScope = host.Services.CreateScope())
            {
                var services = serviceScope.ServiceProvider;
                try
                {
                    var techUI = services.GetRequiredService<TechUI>();
                    techUI.Run();

                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
            }
        }
    }
}


