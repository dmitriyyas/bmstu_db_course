using Microsoft.Extensions.Configuration;
using BL.Models;
using MongoDB.Driver;

namespace MongoDbDataAccess
{
    public class CollectionsFactory
    {
        private readonly IConfiguration _configuration;

        private readonly IMongoDatabase _database;

        public CollectionsFactory(IConfiguration configuration)
        {
            _configuration = configuration;
            var client = new MongoClient(_configuration["Connections:mongodb"]);
            _database = client.GetDatabase("ppo");
        }

        public IMongoCollection<User> getUserCollection()
        {
            return _database.GetCollection<User>("users");
        }

        public IMongoCollection<Country> getCountryCollection()
        {
            return _database.GetCollection<Country>("countries");
        }

        public IMongoCollection<Team> getTeamCollection()
        {
            return _database.GetCollection<Team>("teams");
        }

        public IMongoCollection<Tournament> getTournamentCollection()
        {
            return _database.GetCollection<Tournament>("tournaments");
        }

        public IMongoCollection<TeamTournament> getTeamTournamentCollection()
        {
            return _database.GetCollection<TeamTournament>("team_tournaments");
        }

        public IMongoCollection<Match> getMatchCollection()
        {
            return _database.GetCollection<Match>("matches");
        }

        public IMongoCollection<Outfitter> getOutfitterCollection()
        {
            return _database.GetCollection<Outfitter>("outfitters");
        }
    }
}