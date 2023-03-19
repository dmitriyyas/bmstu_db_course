using System.Diagnostics;
using DataAccess.DBContext;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace dbcourse
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

            //ApplicationConfiguration.Initialize();
            //Application.Run(new Form1());

            IConfiguration configuration = new ConfigurationBuilder()
                                                .SetBasePath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\"))
                                                .AddJsonFile("appsettings.json")
                                                .Build();

            var builder = new HostBuilder().ConfigureServices((hostContext, services) =>
            {
                services.AddSingleton(configuration);
                services.AddDbContext<AdminDbContext>();
                services.AddDbContext<UserDbContext>();
                services.AddDbContext<GuestDbContext>();
                services.AddSingleton<DbContextFactory>();
            });

            var host = builder.Build();

            using (var serviceScope = host.Services.CreateScope())
            {
                var services = serviceScope.ServiceProvider;
                try
                {
                    var dbContextFactory = services.GetRequiredService<DbContextFactory>();
                    var dbContext = dbContextFactory.getDbContext();
                    int count = dbContext.Users.Count();

                    Debug.WriteLine($"Success {count}");
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
            }

        }
    }
}