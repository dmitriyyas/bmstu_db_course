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
    public class TeamTournamentRepository : ITeamTournamentRepository
    {
        private readonly DbContextFactory _dbContextFactory;

        public TeamTournamentRepository(DbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public void create(TeamTournament teamTournament)
        {
            var dbContext = _dbContextFactory.getDbContext();
            try
            {
                dbContext.TeamTournaments.Add(teamTournament);
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при добавлении команды в турнир.");
            }
        }

        public TeamTournament get(int teamId, int tournamentId)
        {
            var dbContext = _dbContextFactory.getDbContext();

            return dbContext.TeamTournaments.FirstOrDefault(t => t.TournamentId == tournamentId && t.TeamId == teamId);
        }
    }
}
