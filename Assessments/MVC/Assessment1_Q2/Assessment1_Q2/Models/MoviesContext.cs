using System.Data.Entity;

namespace Assessment1_Q2.Models  
{
    public class MoviesContext : DbContext
    {
        public MoviesContext() : base("MoviesDB") { }

        public DbSet<Movie> Movies { get; set; }
    }
}
