using Microsoft.EntityFrameworkCore;

namespace AspNetCoreDemo.Entities
{
    public class AspNetCoreDemoDbContext : DbContext
    {
        public AspNetCoreDemoDbContext(DbContextOptions options) : base(options)
        {

        }



        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
