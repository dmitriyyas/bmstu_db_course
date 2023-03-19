using BL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DBContext
{
    public interface IAppDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Country> Countries { get; set; }
        DbSet<Team> Teams { get; set; }
        DbSet<Tournament> Tournaments { get; set; }
        DbSet<Match> Matches { get; set; }
        DbSet<TeamTournament> TeamTournaments { get; set; }

        void SaveChanges();

        static void initModels(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.Property(u => u.Id)
                    .IsRequired()
                    .HasColumnName("id");

                entity.Property(u => u.Login)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("login");

                entity.Property(u => u.Password)
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

                entity.Property(c => c.Id)
                    .IsRequired()
                    .HasColumnName("id");

                entity.Property(c => c.Name)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("name");

                entity.Property(c => c.CountryId)
                    .HasColumnName("id");

                entity.Property(c => c.UserId)
                    .IsRequired()
                    .HasColumnName("user_id");
            });

            modelBuilder.Entity<Match>(entity =>
            {
                entity.ToTable("matches");

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
                entity.ToTable("team_tournamemts");

                entity.Property(c => c.TeamId)
                    .IsRequired()
                    .HasColumnName("team_id");

                entity.Property(c => c.TournamentId)
                    .IsRequired()
                    .HasColumnName("tournament_id");
            });
        }
    }
}
