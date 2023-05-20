using BL.Models;
using BL.RepositoryInterfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDbDataAccess.Repositories
{
    public class OutfitterRepository : IOutfitterRepository
    {
        private readonly CollectionsFactory _collectionsFactory;

        public OutfitterRepository(CollectionsFactory collectionsFactory)
        {
            _collectionsFactory = collectionsFactory;
        }
        public void create(Outfitter outfitter)
        {
            try
            {
                var outfitters = _collectionsFactory.getOutfitterCollection();

                if (outfitters.CountDocuments(_ => true) > 0)
                    outfitter.Id = outfitters.AsQueryable().Select(x => x.Id).Max() + 1;
                else
                    outfitter.Id = 1;

                outfitters.InsertOne(outfitter);
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при добавлении производителя.");
            }
        }

        public IEnumerable<Outfitter> getAll()
        {
            var outfitters = _collectionsFactory.getOutfitterCollection();

            return outfitters.Find(_ => true).ToList();
        }

        public Outfitter getById(int id)
        {
            var outfitters = _collectionsFactory.getOutfitterCollection();

            return outfitters.Find(c => c.Id == id).FirstOrDefault();
        }

        public Outfitter getByName(string name)
        {
            var outfitters = _collectionsFactory.getOutfitterCollection();

            return outfitters.Find(c => c.Name == name).FirstOrDefault();
        }
    }
}
