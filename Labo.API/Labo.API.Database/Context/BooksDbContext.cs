using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Labo.API.Contracts.Models;

namespace Labo.API.Database.Context
{
    public class BooksDbContext : DbContext
    {
        public DbSet<Books> Books { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<Writers> Writers { get; set; }

        public BooksDbContext(DbContextOptions<BooksDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // You can use this in production or remove if using the factory.
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=BooksDb;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }
    }
}

