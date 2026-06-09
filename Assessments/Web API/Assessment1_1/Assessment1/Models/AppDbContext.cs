using CountryAPI.Models;
using System.Collections.Generic;
using System.Data.Entity;

namespace Assessment1.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("DefaultConnection")
        {
        }

        public DbSet<Country> Countries { get; set; }
    }
}
