using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Models;
using BL.RepositoryInterfaces;
using DataAccess.DBContext;

namespace DataAccess.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        private readonly DbContextFactory _dbContextFactory;
        public TeamRepository(DbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
        public void create(Team team)
        {
            try
            {
                using var dbContext = _dbContextFactory.getDbContext();

                if (dbContext.Teams.Count() > 0)
                    team.Id = dbContext.Teams.Select(x => x.Id).Max() + 1;
                else
                    team.Id = 1;

                dbContext.Teams.Add(team);
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при добавлении команды.");
            }
        }

        public IEnumerable<Team> getAll()
        {
            using var dbContext = _dbContextFactory.getDbContext();

            return dbContext.Teams.ToList();
        }

        public IEnumerable<Team> getByCountry(int countryId)
        {
            using var dbContext = _dbContextFactory.getDbContext();

            return dbContext.Teams.Where(t => t.CountryId == countryId).ToList();
        }

        public Team getById(int id)
        {
            using var dbContext = _dbContextFactory.getDbContext();

            return dbContext.Teams.FirstOrDefault(t => t.Id == id);
        }

        public Team getByName(string name)
        {
            using var dbContext = _dbContextFactory.getDbContext();

            return dbContext.Teams.FirstOrDefault(t => t.Name == name);
        }

        public IEnumerable<Team> getByTournament(int tournamentId)
        {
            using var dbContext = _dbContextFactory.getDbContext();

            var teamTours = dbContext.TeamTournaments.Where(t => t.TournamentId == tournamentId).Select(t => t.TeamId);

            return dbContext.Teams.Where(t => teamTours.Contains(t.Id)).ToList();
        }

        public void update(Team team)
        {
            try
            {
                using var dbContext = _dbContextFactory.getDbContext();

                dbContext.Teams.Update(team);
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при обновлении команды.");
            }
        }
    }
}
