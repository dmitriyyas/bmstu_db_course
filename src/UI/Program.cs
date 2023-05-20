using System.Configuration;
using System.Diagnostics;
using BL.Models;
using BL.RepositoryInterfaces;
using BL.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog.Extensions.Logging;
using Microsoft.Extensions.Options;
using Serilog;
using UI.WinFormViews;
using DataAccess.Repositories;

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
                var db = configuration["Database"];
                if (db == "postgres")
                {
                    services.AddSingleton<DataAccess.IDbContextFactory, DataAccess.PgSQLDbContextFactory>();
                    services.AddScoped<IUserRepository, DataAccess.Repositories.UserRepository>();
                    services.AddScoped<ITeamTournamentRepository, DataAccess.Repositories.TeamTournamentRepository>();
                    services.AddScoped<ITeamRepository, DataAccess.Repositories.TeamRepository>();
                    services.AddScoped<ICountryRepository, DataAccess.Repositories.CountryRepository>();
                    services.AddScoped<ITournamentRepository, DataAccess.Repositories.TournamentRepository>();
                    services.AddScoped<IMatchRepository, DataAccess.Repositories.MatchRepository>();
                    services.AddScoped<IOutfitterRepository, DataAccess.Repositories.OutfitterRepository>();
                }
                else if (db == "mongodb")
                {
                    services.AddSingleton<MongoDbDataAccess.CollectionsFactory>();
                    services.AddScoped<IUserRepository, MongoDbDataAccess.Repositories.UserRepository>();
                    services.AddScoped<ITeamTournamentRepository, MongoDbDataAccess.Repositories.TeamTournamentRepository>();
                    services.AddScoped<ITeamRepository, MongoDbDataAccess.Repositories.TeamRepository>();
                    services.AddScoped<ICountryRepository, MongoDbDataAccess.Repositories.CountryRepository>();
                    services.AddScoped<ITournamentRepository, MongoDbDataAccess.Repositories.TournamentRepository>();
                    services.AddScoped<IMatchRepository, MongoDbDataAccess.Repositories.MatchRepository>();
                    services.AddScoped<IOutfitterRepository, MongoDbDataAccess.Repositories.OutfitterRepository>();
                }
                
                services.AddSingleton<IViewFactory, WinFormViewFactory>();

                services.AddSingleton(configuration);
                services.AddSingleton(appContext);
                services.AddSingleton<Presenter>();

                services.AddScoped<UserService>();
                services.AddScoped<TeamService>();
                services.AddScoped<TournamentService>();
                services.AddScoped<MatchService>();
                services.AddScoped<CountryService>();
                services.AddScoped<OutfitterService>();
                /*
                var serilogLogger = new LoggerConfiguration()
                        .WriteTo.Console()
                        .WriteTo.File("log-.txt", rollingInterval: RollingInterval.Day)
                        .CreateLogger();
                */
                var serilogLogger = new LoggerConfiguration()
                        .ReadFrom.Configuration(configuration)
                        .CreateLogger();
                services.AddLogging(x =>
                {
                    x.AddSerilog(logger: serilogLogger, dispose: true);
                });
            });

            var host = builder.Build();

            using (var serviceScope = host.Services.CreateScope())
            {
                var services = serviceScope.ServiceProvider;
                try
                {
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