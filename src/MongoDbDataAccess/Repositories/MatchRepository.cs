using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.RepositoryInterfaces;
using BL.Models;
using MongoDB.Driver;

namespace MongoDbDataAccess.Repositories
{
    public class MatchRepository : IMatchRepository
    {
        private readonly CollectionsFactory _collectionsFactory;

        public MatchRepository(CollectionsFactory collectionsFactory)
        {
            _collectionsFactory = collectionsFactory;
        }
        public void create(Match match)
        {
            try
            {
                var matches = _collectionsFactory.getMatchCollection();

                if (matches.CountDocuments(_ => true) > 0)
                    match.Id = matches.AsQueryable().Select(c => c.Id).Max() + 1;
                else
                    match.Id = 1;

                matches.InsertOne(match);
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при добавлении матча.");
            }
        }

        public void delete(int id)
        {
            try
            {
                var matches = _collectionsFactory.getMatchCollection();

                var match = matches.Find(c => c.Id == id).FirstOrDefault();
                if (match == null)
                {
                    throw new Exception();
                }
                matches.DeleteOne(m => m.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при удалении матча.");
            }
        }

        public IEnumerable<Match> getByGuestTeam(int teamId, int tournamentId)
        {
            var matches = _collectionsFactory.getMatchCollection();

            return matches.Find(m => m.GuestTeamId == teamId && m.TournamentId == tournamentId).ToList();
        }

        public IEnumerable<Match> getByHostTeam(int teamId, int tournamentId)
        {
            var matches = _collectionsFactory.getMatchCollection();

            return matches.Find(m => m.HomeTeamId == teamId && m.TournamentId == tournamentId).ToList();
        }

        public Match getById(int id)
        {
            var matches = _collectionsFactory.getMatchCollection();

            return matches.Find(m => m.Id == id).FirstOrDefault();
        }

        public IEnumerable<Match> getByTournament(int tournamentId)
        {
            var matches = _collectionsFactory.getMatchCollection();

            return matches.Find(m => m.TournamentId == tournamentId).ToList();
        }

        public void update(Match match)
        {
            try
            {
                var matches = _collectionsFactory.getMatchCollection();

                matches.ReplaceOne(m => m.Id == match.Id, match);
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при обновлении матча.");
            }
        }
    }
}
