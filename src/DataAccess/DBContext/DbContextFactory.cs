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

        private AppDbContext _adminDbContext;
        private string? lastPerms;

        public DbContextFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public AppDbContext getDbContext()
        {
            string curPerms = _configuration["DbConnection"];
            if (lastPerms == null || lastPerms != curPerms)
            {
                lastPerms = curPerms;
                var builder = new DbContextOptionsBuilder<AppDbContext>();
                builder.UseNpgsql(_configuration.GetConnectionString(curPerms));
                _adminDbContext = new AppDbContext(builder.Options);
            }

            return _adminDbContext;
        }
    }
}
