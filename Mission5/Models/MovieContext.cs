using System;
using Microsoft.EntityFrameworkCore;

namespace Mission5.Models
{
    public class MovieContext : DbContext
    {
        //Constructor
        //Call DateApplicationContext constructor
        //When you call constructor, receive a DbContextOptions of type MovieContext
        //Then give it a name --> in this case "options"
        //options inherit from base options of DbContextOptions
        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        {
            //Leave blank for now
        }

        public DbSet<MovieModel> responses { get; set; } //Movie Model
        public DbSet<Category> categories { get; set; } //Category Model

        protected override void OnModelCreating(ModelBuilder mb)
        {
            //Create categories for category model
            mb.Entity<Category>().HasData(
                    new Category { CategoryId=1, CategoryName= "Comedy"},
                    new Category { CategoryId = 2, CategoryName = "Romantic Comedy" },
                    new Category { CategoryId = 3, CategoryName = "Drama" },
                    new Category { CategoryId = 4, CategoryName = "Family" },
                    new Category { CategoryId = 5, CategoryName = "Action/Adventure" },
                    new Category { CategoryId = 6, CategoryName = "Horror/Suspense" },
                    new Category { CategoryId = 7, CategoryName = "Television" }
                );

            //Seed data in database
            mb.Entity<MovieModel>().HasData(

                    new MovieModel
                    {
                        MovieId = 1,
                        CategoryId = 2,
                        Title = "The Proposal",
                        Year = "2009",
                        Director = "Anne Fletcher",
                        Rating = "PG-13",
                        Edited = false,
                        Lent = "",
                        Notes = "This movie is very good and always makes me laugh!"
                    },
                    new MovieModel
                    {
                        MovieId = 2,
                        CategoryId = 1,
                        Title = "Just Go With It",
                        Year = "2011",
                        Director = "Dennis Dugan",
                        Rating = "PG-13",
                        Edited = false,
                        Lent = "",
                        Notes = "This movie is a classic feel good!"
                    },
                    new MovieModel
                    {
                        MovieId = 3,
                        CategoryId = 1,
                        Title = "Grownups",
                        Year = "2010",
                        Director = "Dennis Dugan",
                        Rating = "PG-13",
                        Edited = false,
                        Lent = "Teddy Bear",
                        Notes = ""
                    }
            );
        }
    }
}
