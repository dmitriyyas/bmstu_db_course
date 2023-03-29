using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Models;
using BL.RepositoryInterfaces;
using DataAccess.DBContext;
using Microsoft.EntityFrameworkCore;

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
            try
            {
                using var dbContext = _dbContextFactory.getDbContext();

                if (dbContext.Tournaments.Count() > 0)
                    tournament.Id = dbContext.Tournaments.Select(x => x.Id).Max() + 1;
                else
                    tournament.Id = 1;

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
            try
            {
                using var dbContext = _dbContextFactory.getDbContext();

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
            using var dbContext = _dbContextFactory.getDbContext();

            return dbContext.Tournaments.ToList();
        }

        public IEnumerable<Tournament> getByCountry(int countryId)
        {
            using var dbContext = _dbContextFactory.getDbContext();

            return dbContext.Tournaments.Where(t => t.CountryId == countryId).ToList();
        }

        public Tournament getById(int id)
        {
            using var dbContext = _dbContextFactory.getDbContext();

            return dbContext.Tournaments.FirstOrDefault(t => t.Id == id);
        }

        public Tournament getByName(string name)
        {
            using var dbContext = _dbContextFactory.getDbContext();

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
            using var dbContext = _dbContextFactory.getDbContext();

            return dbContext.Tournaments.Where(t => t.UserId == userId).ToList();
        }
    }
}
