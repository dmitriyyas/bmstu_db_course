using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class InMemoryDbContextFactory : IDbContextFactory
    {
        private readonly string _dbName;
        public InMemoryDbContextFactory()
        {
            _dbName = Guid.NewGuid().ToString();
        }

        public AppDbContext getDbContext()
        {

            var builder = new DbContextOptionsBuilder<AppDbContext>();
            builder.UseInMemoryDatabase(_dbName);
            var _adminDbContext = new AppDbContext(builder.Options);

            return _adminDbContext;
        }
    }
}
