using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace DataAccess.DBContext
{
    public class DbContextFactory
    {
        
        private readonly IConfiguration _configuration;

        public DbContextFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public AppDbContext getDbContext()
        {
            string curPerms = _configuration["DbConnection"];

            var builder = new DbContextOptionsBuilder<AppDbContext>();
            builder.UseNpgsql(_configuration.GetConnectionString(curPerms));
            var _adminDbContext = new AppDbContext(builder.Options);

            return _adminDbContext;
        }
    }
}
