using BL.Models;
using BL.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsSqlDataAccess.Repositories
{
    public class OutfitterRepository : IOutfitterRepository
    {
        private readonly IDbContextFactory _dbContextFactory;

        public OutfitterRepository(IDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
        public void create(Outfitter outfitter)
        {
            try
            {
                using var dbContext = _dbContextFactory.getDbContext();

                if (dbContext.Outfitters.Count() > 0)
                    outfitter.Id = dbContext.Outfitters.Select(x => x.Id).Max() + 1;
                else
                    outfitter.Id = 1;

                dbContext.Outfitters.Add(outfitter);
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при добавлении страны.");
            }
        }

        public IEnumerable<Outfitter> getAll()
        {
            using var dbContext = _dbContextFactory.getDbContext();

            return dbContext.Outfitters.ToList();
        }

        public Outfitter getById(int id)
        {
            using var dbContext = _dbContextFactory.getDbContext();

            return dbContext.Outfitters.FirstOrDefault(c => c.Id == id);
        }

        public Outfitter getByName(string name)
        {
            using var dbContext = _dbContextFactory.getDbContext();

            return dbContext.Outfitters.FirstOrDefault(c => c.Name == name);
        }
    }
}
