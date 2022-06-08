using Microsoft.EntityFrameworkCore;


namespace LibraSoftWeb.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }
        public DbSet<Piranha_Pages> Piranha_Pages { get; set; }
    }
}
