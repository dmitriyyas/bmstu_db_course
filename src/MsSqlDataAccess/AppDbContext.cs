using Microsoft.EntityFrameworkCore;
using BL.Models;

namespace MsSqlDataAccess
{
    public partial class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<TeamTournament> TeamTournaments { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.HasKey(u => u.Id);

                entity.Property(u => u.Id)
                    .IsRequired()
                    .HasColumnName("id");

                entity.Property(u => u.Login)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("login");

                entity.Property(u => u.PasswordHash)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("password");

                entity.Property(u => u.Permission)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("permissions");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("countries");

                entity.HasKey(u => u.Id);

                entity.Property(c => c.Id)
                    .IsRequired()
                    .HasColumnName("id");

                entity.Property(c => c.Name)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("name");

                entity.Property(c => c.Confederation)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("confederation");
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.ToTable("teams");

                entity.HasKey(u => u.Id);

                entity.Property(c => c.Id)
                    .IsRequired()
                    .HasColumnName("id");

                entity.Property(c => c.Name)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("name");

                entity.Property(c => c.CountryId)
                    .HasColumnName("country_id");
            });

            modelBuilder.Entity<Tournament>(entity =>
            {
                entity.ToTable("tournaments");

                entity.HasKey(u => u.Id);

                entity.Property(c => c.Id)
                    .IsRequired()
                    .HasColumnName("id");

                entity.Property(c => c.Name)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("name");

                entity.Property(c => c.CountryId)
                    .HasColumnName("country_id");

                entity.Property(c => c.UserId)
                    .IsRequired()
                    .HasColumnName("user_id");
            });

            modelBuilder.Entity<Match>(entity =>
            {
                entity.ToTable("matches");

                entity.HasKey(u => u.Id);

                entity.Property(c => c.Id)
                    .IsRequired()
                    .HasColumnName("id");

                entity.Property(c => c.TournamentId)
                    .IsRequired()
                    .HasColumnName("tournament_id");

                entity.Property(c => c.HomeTeamId)
                    .IsRequired()
                    .HasColumnName("home_team_id");

                entity.Property(c => c.GuestTeamId)
                    .IsRequired()
                    .HasColumnName("guest_team_id");

                entity.Property(c => c.HomeGoals)
                    .IsRequired()
                    .HasColumnName("home_goals");

                entity.Property(c => c.GuestGoals)
                    .IsRequired()
                    .HasColumnName("guest_goals");
            });

            modelBuilder.Entity<TeamTournament>(entity =>
            {
                entity.ToTable("team_tournaments");

                entity.HasKey(t => new { t.TeamId, t.TournamentId });

                entity.Property(c => c.TeamId)
                    .IsRequired()
                    .HasColumnName("team_id");

                entity.Property(c => c.TournamentId)
                    .IsRequired()
                    .HasColumnName("tournament_id");
            });

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
