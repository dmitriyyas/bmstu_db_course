using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DBContext
{
    public class DbContextFactory
    {
        private readonly AdminDbContext _adminDbContext;
        private readonly UserDbContext _userDbContext;
        private readonly GuestDbContext _guestDbContext;
        private readonly IConfiguration _configuration;

        public DbContextFactory(AdminDbContext adminDbContext, UserDbContext userDbContext, GuestDbContext guestDbContext, IConfiguration configuration)
        {
            _adminDbContext = adminDbContext;
            _userDbContext = userDbContext;
            _guestDbContext = guestDbContext;
            _configuration = configuration;
        }

        public IAppDbContext getDbContext()
        {
            switch (_configuration["DbConnection"])
            {
                case "admin":
                    return _adminDbContext;
                case "user":
                    return _userDbContext;
            }

            return _guestDbContext;
        }
    }
}
