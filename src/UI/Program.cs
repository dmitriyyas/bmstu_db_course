using System.Diagnostics;
using BL.Models;
using BL.RepositoryInterfaces;
using DataAccess.DBContext;
using DataAccess.Repositories;
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
            });

            var host = builder.Build();

            using (var serviceScope = host.Services.CreateScope())
            {
                var services = serviceScope.ServiceProvider;
                try
                {
                    var userRepository = services.GetRequiredService<IUserRepository>();
                    //userRepository.create(new BL.Models.User("asdf", "asdf"));
                    //User user = userRepository.getByLogin("asdf");
                    //user.Password = "password";
                    //userRepository.update(user);
                    //user = userRepository.getByLogin("asdf");
                    var _user = userRepository.getById(2);
                    _user.Password = "gghghghjhdfjhf";
                    userRepository.update(_user);
                    var users = userRepository.getAll();
                    foreach(var user in users)
                    {
                        Debug.WriteLine($"{user.Id} {user.Password}");
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