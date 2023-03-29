using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.RepositoryInterfaces;
using BL.Models;
using DataAccess.DBContext;

namespace DataAccess.Repositories
{
    public class MatchRepository : IMatchRepository
    {
        private readonly DbContextFactory _dbContextFactory;

        public MatchRepository(DbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
        public void create(Match match)
        {
            var dbContext = _dbContextFactory.getDbContext();
            try
            {
                if (dbContext.Matches.Count() > 0)
                    match.Id = dbContext.Matches.Select(x => x.Id).Max() + 1;
                else
                    match.Id = 1;

                dbContext.Matches.Add(match);
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при добавлении матча.");
            }
        }

        public void delete(int id)
        {
            var dbContext = _dbContextFactory.getDbContext();
            try
            {
                var match = dbContext.Matches.FirstOrDefault(t => t.Id == id);
                if (match == null)
                {
                    throw new Exception();
                }
                dbContext.Matches.Remove(match);
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при удалении матча.");
            }
        }

        public IEnumerable<Match> getByGuestTeam(int teamId, int tournamentId)
        {
            var dbContext = _dbContextFactory.getDbContext();

            return dbContext.Matches.Where(m => m.GuestTeamId == teamId && m.TournamentId == tournamentId).ToList();
        }

        public IEnumerable<Match> getByHostTeam(int teamId, int tournamentId)
        {
            var dbContext = _dbContextFactory.getDbContext();

            return dbContext.Matches.Where(m => m.HomeTeamId == teamId && m.TournamentId == tournamentId).ToList();
        }

        public Match getById(int id)
        {
            var dbContext = _dbContextFactory.getDbContext();

            return dbContext.Matches.FirstOrDefault(m => m.Id == id);
        }

        public IEnumerable<Match> getByTournament(int tournamentId)
        {
            var dbContext = _dbContextFactory.getDbContext();

            return dbContext.Matches.Where(m => m.TournamentId == tournamentId).ToList();
        }

        public void update(Match match)
        {
            var dbContext = _dbContextFactory.getDbContext();

            try
            {

                dbContext.Matches.Update(match);
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при обновлении матча.");
            }
        }
    }
}
