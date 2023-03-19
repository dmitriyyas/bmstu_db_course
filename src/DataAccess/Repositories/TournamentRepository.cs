using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Models;
using BL.RepositoryInterfaces;
using DataAccess.DBContext;

namespace DataAccess.Repositories
{
    public class TournamentRepository : ITournamentRepository
    {
        private readonly DbContextFactory _dbContextFactory;

        public TournamentRepository(DbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public void create(Tournament tournament)
        {
            var dbContext = _dbContextFactory.getDbContext();
            try
            {
                tournament.Id = dbContext.Tournaments.Count() + 1;

                dbContext.Tournaments.Add(tournament);
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при добавлении турнира.");
            }
        }

        public void delete(int id)
        {
            var dbContext = _dbContextFactory.getDbContext();
            try
            {
                var tournament = dbContext.Tournaments.FirstOrDefault(t => t.Id == id);
                if (tournament == null)
                {
                    throw new Exception();
                }
                dbContext.Tournaments.Remove(tournament);
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при удалении турнира.");
            }
        }

        public IEnumerable<Tournament> getAll()
        {
            var dbContext = _dbContextFactory.getDbContext();

            return dbContext.Tournaments.ToList();
        }

        public IEnumerable<Tournament> getByCountry(int countryId)
        {
            var dbContext = _dbContextFactory.getDbContext();

            return dbContext.Tournaments.Where(t => t.CountryId == countryId).ToList();
        }

        public Tournament getById(int id)
        {
            var dbContext = _dbContextFactory.getDbContext();

            return dbContext.Tournaments.FirstOrDefault(t => t.Id == id);
        }

        public Tournament getByName(string name)
        {
            var dbContext = _dbContextFactory.getDbContext();

            return dbContext.Tournaments.FirstOrDefault(t => t.Name == name);
        }

        public IEnumerable<Tournament> getByTeam(int teamId)
        {
            var dbContext = _dbContextFactory.getDbContext();

            var teamTours = dbContext.TeamTournaments.Where(t => t.TeamId == teamId).Select(t => t.TournamentId);

            return dbContext.Tournaments.Where(t => teamTours.Contains(t.Id)).ToList();
        }

        public IEnumerable<Tournament> getByUser(int userId)
        {
            var dbContext = _dbContextFactory.getDbContext();

            return dbContext.Tournaments.Where(t => t.UserId == userId).ToList();
        }
    }
}
