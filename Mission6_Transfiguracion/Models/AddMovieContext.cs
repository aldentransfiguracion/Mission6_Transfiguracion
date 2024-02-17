using Microsoft.EntityFrameworkCore;

namespace Mission6_Transfiguracion.Models
{
    public class AddMovieContext : DbContext
    {
        public AddMovieContext(DbContextOptions<AddMovieContext> options) : base(options)
        {
        }

        public DbSet<AddMovie> AddMovies { get; set; }
    }
}
