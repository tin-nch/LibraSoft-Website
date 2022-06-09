using Microsoft.EntityFrameworkCore;


namespace LibraSoftWeb.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }
        public DbSet<Piranha_Pages> Piranha_Pages { get; set; }
        public DbSet<Piranha_CFIndustry> Piranha_CFIndustries { get; set; }
        public DbSet<Piranha_CFCountry> Piranha_CFCountries { get; set; }
        public DbSet<Piranha_CFReasonReaching> Piranha_CFReasonReachings { get; set; }
        public DbSet<Piranha_ContactForm> Piranha_ContactForms { get; set; }

    }
}
