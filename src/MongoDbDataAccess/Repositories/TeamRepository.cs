using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Models;
using BL.RepositoryInterfaces;
using MongoDB.Driver;

namespace MongoDbDataAccess.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        private readonly CollectionsFactory _collectionsFactory;
        public TeamRepository(CollectionsFactory collectionsFactory)
        {
            _collectionsFactory = collectionsFactory;
        }
        public void create(Team team)
        {
            try
            {
                var teams = _collectionsFactory.getTeamCollection();

                if (teams.CountDocuments(_ => true) > 0)
                    team.Id = teams.AsQueryable().Select(x => x.Id).Max() + 1;
                else
                    team.Id = 1;

                teams.InsertOne(team);
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при добавлении команды.");
            }
        }

        public IEnumerable<Team> getAll()
        {
            var teams = _collectionsFactory.getTeamCollection();

            return teams.Find(_ => true).ToList();
        }

        public IEnumerable<Team> getByCountry(int countryId)
        {
            var teams = _collectionsFactory.getTeamCollection();

            return teams.Find(t => t.CountryId == countryId).ToList();
        }

        public Team getById(int id)
        {
            var teams = _collectionsFactory.getTeamCollection();

            return teams.Find(t => t.Id == id).FirstOrDefault();
        }

        public Team getByName(string name)
        {
            var teams = _collectionsFactory.getTeamCollection();

            return teams.Find(t => t.Name == name).FirstOrDefault();
        }

        public IEnumerable<Team> getByOutfitter(int outfitterId)
        {
            var teams = _collectionsFactory.getTeamCollection();

            return teams.Find(t => t.OutfitterId == outfitterId).ToList();
        }

        public IEnumerable<Team> getByTournament(int tournamentId)
        {
            var teams = _collectionsFactory.getTeamCollection();

            var teamTours = _collectionsFactory.getTeamTournamentCollection()
                                                .AsQueryable()
                                                .Where(t => t.TournamentId == tournamentId)
                                                .Select(t => t.TeamId);

            return teams.Find(t => teamTours.Contains(t.Id)).ToList();
        }

        public void update(Team team)
        {
            try
            {
                var teams = _collectionsFactory.getTeamCollection();

                teams.ReplaceOne(t => t.Id == team.Id, team);
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при обновлении команды.");
            }
        }
    }
}
