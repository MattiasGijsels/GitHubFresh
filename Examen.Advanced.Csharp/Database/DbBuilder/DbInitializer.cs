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
        public static void Initialize()
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
            var personService = new PersonService(_dbContext);
            var personRepository = new PersonRepository(_dbContext);

            while (true)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Search for a person by name or address");
                Console.WriteLine("2. List all persons based on city or postalcode");
                Console.WriteLine("3. Add a person to the database");
                Console.WriteLine("4. Modify a person in the database");
                Console.WriteLine("5. Delete a person from the database");
                Console.WriteLine("6. Exit");
                Console.Write("Enter your choice with the corresponding number: ");

                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":

                        PersonService.FindPersonData(_dbContext);

                        break;

                    case "2":

                        PersonService.FindCityPostcode(_dbContext);

                        break;
                    case "3":

                        PersonRepository.AddPersonAsync(personRepository).Wait();

                        break;

                    case "4":

                        PersonRepository.ModifyPersonAsync(personRepository).Wait();

                        break;

                    case "5":

                        PersonRepository.DeletePersonAsync(personRepository).Wait();

                        break;
                    case "6":
                        Console.WriteLine("Exiting program...");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}
