using Examen.Advanced.Csharp.CsvReader;
using Examen.Advanced.Csharp.Contracts.Models;
using Examen.Advanced.Csharp.Database.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

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
            string? connectionString = configuration.GetConnectionString("DefaultConnection");

            // Configure DbContext options
            var optionsBuilder = new DbContextOptionsBuilder<PersonenDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            // Instantiate the DbContext
            var _dbContext = new PersonenDbContext(optionsBuilder.Options);

            // Ask the user if they want to delete the existing database
            Console.WriteLine("Do you want to delete the existing database and start fresh? (yes/no):");
            string? userInput = Console.ReadLine()?.Trim().ToLower();

            if (userInput == "yes")
            {
                Console.WriteLine("Deleting existing database...");
                _dbContext.Database.EnsureDeleted();
                Console.WriteLine("Database deleted.");
            }

            // Ensure the database is created
            Console.WriteLine("Creating a new database...");
            _dbContext.Database.EnsureCreated();
            Console.WriteLine("Database created.");

            // Seed ZipCode data from CSV
            string csvFilePath = @"C:\Users\matti\Source\Repos\GitHubFresh\Examen.Advanced.Csharp\Src\postcodes.csv"; // Path to your CSV file
            List<ZipCode>? zipCodes = DataSeeder.SeedFromCsv(_dbContext, csvFilePath);
            //can zipcodes be allowed to be null?

            DataSeeder.SeedDummyData(_dbContext, zipCodes);

            Console.WriteLine("Data seeding completed.All systems are go. Lets get started!");
        }
    }
}
