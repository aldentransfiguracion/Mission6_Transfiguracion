using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Mission6_Transfiguracion.Models
{
    public class AddMovieContext : DbContext //Liaison from models in the app to the sqlite database
    {
        public AddMovieContext(DbContextOptions<AddMovieContext>options) : base(options) //Constructor
        {
        }

        public DbSet<AddMovie> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder) //Seed data
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId=1, CategoryName= "Miscellaneous" },
                new Category { CategoryId = 2, CategoryName = "Drama" },
                new Category { CategoryId = 3, CategoryName = "Television" },
                new Category { CategoryId = 4, CategoryName = "Horror / Suspense" },
                new Category { CategoryId = 5, CategoryName = "Comedy" },
                new Category { CategoryId = 6, CategoryName = "Family" },
                new Category { CategoryId = 7, CategoryName = "Action / Adventure" },
                new Category { CategoryId = 8, CategoryName = "VHS" }
                );
        }
    }
}
