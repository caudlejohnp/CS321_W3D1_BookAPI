using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS321_W3D1_BookAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CS321_W3D1_BookAPI.Data
{
    public class BookContext : DbContext
    {
        DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder myBuilder)
        {
            myBuilder.UseSqlite("Data Source = Books.db");
        }

        protected override void OnModelCreating(ModelBuilder myModelBuilder)
        {
            base.OnModelCreating(myModelBuilder);

            myModelBuilder.Entity<Book>().HasData(
                new Book { Title = "The Hobbit", Author = "J.R.R. Tolkein", Category = "Fantasy" },
                new Book { Title = "The Fellowship of the Ring", Author = "J.R.R. Tolkein", Category = "Fantasy" },
                new Book { Title = "The Two Towers", Author = "J.R.R. Tolkein", Category = "Fantasy" });
        }

    }
}
