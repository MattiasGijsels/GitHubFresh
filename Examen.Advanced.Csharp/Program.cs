using Examen.Advanced.Csharp.CsvReader;
using Examen.Advanced.Csharp.Contracts.Models;
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
            // in cli tool look for db and ask user if its the "first time" if so use install command to build db
            // make if statement if db exists yadayada so the old db is deleted
           
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

            // Seed ZipCode data from CSV
            string csvFilePath = @"C:\Users\matti\Source\Repos\GitHubFresh\Examen.Advanced.Csharp\Src\postcodes.csv"; // Path to your CSV file, check discord
            List<ZipCode> zipCodes = DataSeeder.SeedFromCsv(_dbContext, csvFilePath);

            DataSeeder.SeedDummyData(_dbContext, zipCodes);

        }
    }
}
