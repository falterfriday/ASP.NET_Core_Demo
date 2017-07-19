using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AspNetCoreDemo.Entities
{
    public class AspNetCoreDemoDbContext : IdentityDbContext<User>
    {
        public AspNetCoreDemoDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
