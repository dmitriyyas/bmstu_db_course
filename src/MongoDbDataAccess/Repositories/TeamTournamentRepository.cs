using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Models;
using BL.RepositoryInterfaces;
using MongoDB.Driver;

namespace MongoDbDataAccess.Repositories
{
    public class TeamTournamentRepository : ITeamTournamentRepository
    {
        private readonly CollectionsFactory _collectionsFactory;

        public TeamTournamentRepository(CollectionsFactory collectionsFactory)
        {
            _collectionsFactory = collectionsFactory;
        }

        public void create(TeamTournament teamTournament)
        {
            try
            {
                var teamTournaments = _collectionsFactory.getTeamTournamentCollection();

                teamTournaments.InsertOne(teamTournament);
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при добавлении команды в турнир.");
            }
        }

        public TeamTournament get(int teamId, int tournamentId)
        {
            var teamTournaments = _collectionsFactory.getTeamTournamentCollection();

            return teamTournaments.Find(t => t.TournamentId == tournamentId && t.TeamId == teamId).FirstOrDefault();
        }
    }
}
