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

                        PrintPersonData(_dbContext);

                        break;

                    case "2":
                        var allPersons = personService.SearchPersons(null);
                        Console.WriteLine("Your name was not found, I will provide you with a list of all Persons:");
                        foreach (var person in allPersons)
                        {
                            Console.WriteLine($"Name: {person.FirstName} {person.LastName}");
                        }
                        break;
                    case "3":

                        PersonRepository.AddPersonAsync(personRepository).Wait();

                        break;

                    case "4":

                        break;

                    case "5":

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
        private static void PrintPersonData(PersonsDbContext context)
        {
            var personService = new PersonService(context);
            Console.Write("Enter the firstname,lastname or adress info searchterm: ");//how did I fuck up?
            string? name = Console.ReadLine();
            var results = personService.SearchPersons(name);
            PrintResults(results);
        }
        private static void PrintResults(List<Person> results)
        {
            if (results.Count > 0)
            {
                Console.WriteLine("Search Results:");
                Console.WriteLine("----------------------------------------------------");
                foreach (var person in results)
                {
                    Console.WriteLine($"Name: {person.FirstName} {person.LastName}");
                    Console.WriteLine($"Date of birth: {person.DateOfBirth}");
                    Console.WriteLine($"Adress: {person.Address.Street}");
                    Console.WriteLine($"CityName: {person.Address.ZipCode.CityName}");
                    Console.WriteLine($"PostalCode: {person.Address.ZipCode.PostalCode}");
                    Console.WriteLine($"NisCode: {person.Address.ZipCode.NisCode}");
                    Console.WriteLine($"Province: {person.Address.ZipCode.Province}");
                    Console.WriteLine($"MainCity: {person.Address.ZipCode.Main}");
                    Console.WriteLine("----------------------------------------------------");
                }
            }
            else
            {
                Console.WriteLine("No persons found with that name.");
            }
        }
    }
}
