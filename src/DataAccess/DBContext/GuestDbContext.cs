using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Models;

namespace DataAccess.DBContext
{
    public partial class GuestDbContext : DbContext, IAppDbContext
    {
        protected readonly IConfiguration _configuration;
        public DbSet<User> Users { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<TeamTournament> TeamTournaments { get; set; }

        public GuestDbContext(DbContextOptions<GuestDbContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseNpgsql(_configuration.GetConnectionString("guest"));
                optionsBuilder.UseNpgsql(_configuration.GetConnectionString("admin"))
                    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            IAppDbContext.initModels(modelBuilder);

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        void IAppDbContext.SaveChanges()
        {
            base.SaveChanges();
        }
    }
}
