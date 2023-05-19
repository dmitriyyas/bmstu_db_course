using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsSqlDataAccess
{
    public class MsSqlDbContextFactory : IDbContextFactory
    {
        private readonly IConfiguration _configuration;

        public MsSqlDbContextFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public AppDbContext getDbContext()
        {
            string curPerms = _configuration["DbConnection"];

            var builder = new DbContextOptionsBuilder<AppDbContext>();
            builder.UseSqlServer(_configuration[$"Connections:mssql:{curPerms}"]);
            //builder.UseNpgsql(_configuration[$"Connections:mssql:{curPerms}"]);
            var _adminDbContext = new AppDbContext(builder.Options);

            return _adminDbContext;
        }
    }
}
