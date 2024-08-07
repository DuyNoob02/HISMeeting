using Microsoft.EntityFrameworkCore;
using server.Models.Users;

namespace server.Models.Context
{
    public class HisMeetingContext : DbContext
    {
        public HisMeetingContext(DbContextOptions<HisMeetingContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }

}

// create users table