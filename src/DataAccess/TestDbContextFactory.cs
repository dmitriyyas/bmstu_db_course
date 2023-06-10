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
    public class TestDbContextFactory : IDbContextFactory
    {

        private readonly IConfiguration _configuration;

        public TestDbContextFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public AppDbContext getDbContext()
        {
            string curPerms = _configuration["DbConnection"];

            var builder = new DbContextOptionsBuilder<AppDbContext>();
            builder.UseNpgsql("Server=localhost;Port=5432;Database=dbcoursetest;User Id=postgres;Password=1234;");
            var _adminDbContext = new AppDbContext(builder.Options);

            return _adminDbContext;
        }
    }
}
