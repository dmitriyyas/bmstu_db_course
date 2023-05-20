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
    public class TournamentRepository : ITournamentRepository
    {
        private readonly CollectionsFactory _collectionsFactory;

        public TournamentRepository(CollectionsFactory collectionsFactory)
        {
            _collectionsFactory = collectionsFactory;
        }

        public void create(Tournament tournament)
        {
            try
            {
                var tournaments = _collectionsFactory.getTournamentCollection();

                if (tournaments.CountDocuments(_ => true) > 0)
                    tournament.Id = tournaments.AsQueryable().Select(x => x.Id).Max() + 1;
                else
                    tournament.Id = 1;

                tournaments.InsertOne(tournament);
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
                var tournaments = _collectionsFactory.getTournamentCollection();

                var tournament = tournaments.Find(t => t.Id == id).FirstOrDefault();
                if (tournament == null)
                {
                    throw new Exception();
                }
                tournaments.DeleteOne(t => t.Id == id);

                _collectionsFactory.getMatchCollection().DeleteMany(m => m.TournamentId == id);
                _collectionsFactory.getTeamTournamentCollection().DeleteMany(t => t.TournamentId == id);
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при удалении турнира.");
            }
        }

        public IEnumerable<Tournament> getAll()
        {
            var tournaments = _collectionsFactory.getTournamentCollection();

            return tournaments.Find(_ => true).ToList();
        }

        public IEnumerable<Tournament> getByCountry(int countryId)
        {
            var tournaments = _collectionsFactory.getTournamentCollection();

            return tournaments.Find(t => t.CountryId == countryId).ToList();
        }

        public Tournament getById(int id)
        {
            var tournaments = _collectionsFactory.getTournamentCollection();

            return tournaments.Find(t => t.Id == id).FirstOrDefault();
        }

        public Tournament getByName(string name)
        {
            var tournaments = _collectionsFactory.getTournamentCollection();

            return tournaments.Find(t => t.Name == name).FirstOrDefault();
        }

        public IEnumerable<Tournament> getByTeam(int teamId)
        {
            var tournaments = _collectionsFactory.getTournamentCollection();

            var teamTours = _collectionsFactory.getTeamTournamentCollection()
                                                .AsQueryable()
                                                .Where(t => t.TeamId == teamId)
                                                .Select(t => t.TournamentId);

            return tournaments.Find(t => teamTours.Contains(t.Id)).ToList();
        }

        public IEnumerable<Tournament> getByUser(int userId)
        {
            var tournaments = _collectionsFactory.getTournamentCollection();

            return tournaments.Find(t => t.UserId == userId).ToList();
        }
    }
}
