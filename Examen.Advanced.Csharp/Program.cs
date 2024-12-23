using Examen.Advanced.Csharp.Database.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace Examen.Advanced.Csharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Build the configuration
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            // Retrieve the connection string
            string connectionString = configuration.GetConnectionString("DefaultConnection");

            // Configure DbContext options
            var optionsBuilder = new DbContextOptionsBuilder<PersonenDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            // Instantiate the DbContext
            var _dbContext = new PersonenDbContext(optionsBuilder.Options);

            // Optionally, test connection or migrations
            _dbContext.Database.EnsureCreated();

            DataSeeder.SeedDummyData(_dbContext);
        }
    }
}
