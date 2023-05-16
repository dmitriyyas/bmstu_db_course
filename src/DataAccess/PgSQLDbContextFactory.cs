using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace DataAccess
{
    public class PgSQLDbContextFactory : IDbContextFactory
    {

        private readonly IConfiguration _configuration;

        public PgSQLDbContextFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public AppDbContext getDbContext()
        {
            string curPerms = _configuration["DbConnection"];

            var builder = new DbContextOptionsBuilder<AppDbContext>();
            builder.UseNpgsql(_configuration[$"Connections:postgres:{curPerms}"]);
            var _adminDbContext = new AppDbContext(builder.Options);

            return _adminDbContext;
        }
    }
}
