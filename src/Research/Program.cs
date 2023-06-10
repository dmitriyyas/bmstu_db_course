using System.Configuration;
using System.Diagnostics;
using BL.Models;
using BL.RepositoryInterfaces;
using BL.Services;
using DataAccess;
using DataAccess.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Research
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            IConfiguration configuration = new ConfigurationBuilder()
                                                //.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\..\\"))
                                                .AddJsonFile("appsettings.json")
                                                .Build();

            var builder = new HostBuilder().ConfigureServices((hostContext, services) =>
            {
                services.AddSingleton<IDbContextFactory, TestDbContextFactory>();

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
            });

            var host = builder.Build();

            using (var serviceScope = host.Services.CreateScope())
            {
                var services = serviceScope.ServiceProvider;
                try
                {
                    var tournamentService = services.GetRequiredService<TournamentService>();
                    var stopWatch = new Stopwatch();
                    stopWatch.Start();
                    var table = tournamentService.getTournamentTable(1);
                    stopWatch.Stop();

                    for (int i = 0; i < 10; i++)
                    {
                        long dbtime = 0, apptime = 0;
                        for (int j = 0; j < 10; j++)
                        {
                            stopWatch.Restart();
                            table = tournamentService.getTournamentTable(i + 1, false);
                            stopWatch.Stop();
                            apptime += stopWatch.ElapsedMilliseconds;
                        }
                        Console.WriteLine($"teams: {(i + 1) * 10} app: {apptime / 10}");

                        for (int j = 0; j < 10; j++)
                        {
                            stopWatch.Restart();
                            table = tournamentService.getTournamentTable(i + 1, true);
                            stopWatch.Stop();
                            dbtime += stopWatch.ElapsedMilliseconds;
                        }
                        Console.WriteLine($"teams: {(i + 1) * 10} db: {dbtime / 10}");
                    }







                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
            }

        }
    }

}


/*
{
  "ConnectionStrings": {
    "default": "Server=localhost;Port=5432;Database=dbcourse;User Id=postgres;Password=1234;",
    "guest": "Server=localhost;Port=5432;Database=dbcourse;User Id=guest;Password=guest;",
    "user": "Server=localhost;Port=5432;Database=dbcourse;User Id=_user;Password=user;",
    "admin": "Server=localhost;Port=5432;Database=dbcourse;User Id=admin;Password=admin;"
  },
  "Serilog": {
    "Using": [ "Serilog.Sinks.Console", "Serilog.Sinks.File" ],
    "MinimumLevel": "Debug",
    "WriteTo": [
      { "Name": "Console" },
      {
        "Name": "File",
        "Args": {
          "path": "./log.txt",
          "OutputTemplate": "{Timestamp:u} [{Level}] {Message}{NewLine}{Exception}"
        }
      }
    ]
  }
}
 */
