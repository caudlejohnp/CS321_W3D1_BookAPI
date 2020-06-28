using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS321_W3D1_BookAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CS321_W3D1_BookAPI.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Publisher> Publishers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder myBuilder)
        {
            myBuilder.UseSqlite("Data Source = Books.db");
        }

        protected override void OnModelCreating(ModelBuilder myModelBuilder)
        {
            base.OnModelCreating(myModelBuilder);

            myModelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Title = "The Hobbit", AuthorId = 1, Category = "Fantasy", PublisherId = 1},
                new Book { Id = 2, Title = "The Fellowship of the Ring", AuthorId = 1, Category = "Fantasy", PublisherId = 1},
                new Book { Id = 3, Title = "The Two Towers", AuthorId = 1, Category = "Fantasy", PublisherId = 1},
                new Book { Id = 4, Title = "The Broken Mirror", AuthorId = 2, Category = "Fantasy", PublisherId = 2});

            myModelBuilder.Entity<Author>().HasData(
                new Author { Id = 1, FirstName = "J.R.R.", LastName = "Tolkein", Birthday = new DateTime(1892, 1, 3) },
                new Author { Id = 2, FirstName = "Brent", LastName = "Weeks", Birthday = new DateTime(1977, 3, 7) });

            myModelBuilder.Entity<Publisher>().HasData(
                new Publisher { Id = 1, Name = "Viking Press", CountryofOrigin = "USA", FoundedYear = 1925, HeadQuartersLocation = "NY, NY" },
                new Publisher { Id = 2, Name = "Doubleday", CountryofOrigin = "USA", FoundedYear = 1897, HeadQuartersLocation = "NY, NY" }
                );
        }

    }
}
