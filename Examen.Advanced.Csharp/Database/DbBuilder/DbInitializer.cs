using Examen.Advanced.Csharp.Contracts.Models;
using Examen.Advanced.Csharp.Database.Context;
using Examen.Advanced.Csharp.Database.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.Advanced.Csharp.Database.DbInitializer
{
    public class DbInitializer
    {
        public static async Task<PersonsDbContext> Initialize()
        {
            // Build the configuration
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            // Retrieve the connection string
            string? connectionString = configuration.GetConnectionString("DefaultConnection");

            // Configure DbContext options
            var optionsBuilder = new DbContextOptionsBuilder<PersonsDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            // Instantiate the DbContext
            using var _dbContext = new PersonsDbContext(optionsBuilder.Options);
            string? userInput = "";

            while (!(userInput == "yes" || userInput == "no"))
            {
                Console.WriteLine("Hello Dear user");
                Console.WriteLine("Do you want to reset the database? (yes/no)");
                userInput = Console.ReadLine()?.Trim().ToLower();

                if (userInput == "yes")
                {
                    Console.WriteLine("Deleting existing database...");
                    _dbContext.Database.EnsureDeleted();
                    Console.WriteLine("Database deleted.");
                    Console.WriteLine("Creating a new database...");
                    _dbContext.Database.EnsureCreated();
                    Console.WriteLine("Database created.");

                    // Seed ZipCode data from CSV
                    string csvFilePath = @"C:\Users\matti\Source\Repos\GitHubFresh\Examen.Advanced.Csharp\Src\postcodes.csv"; // Path to your CSV file
                    List<ZipCode>? zipCodes = DataSeeder.SeedFromCsv(_dbContext, csvFilePath);

                    DataSeeder.SeedDummyData(_dbContext, zipCodes);

                    Console.WriteLine("Data seeding completed. All systems are go. Let's get started!");
                }
                else if (userInput == "no")
                {
                    Console.WriteLine("Checking if a database currently exists...");
                    _dbContext.Database.EnsureCreated();
                    Console.WriteLine("All systems are go, Let's blow up the deathstar.");
                }
                else
                {
                    Console.WriteLine("Your input was invalid. Please enter 'yes' or 'no'.");
                }
            }
            //await MenuHandler.HandleAsync(_dbContext);
            return _dbContext;
        }
    }
}
