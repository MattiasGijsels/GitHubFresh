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
            var optionsBuilder = new DbContextOptionsBuilder<PersonsDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            // Instantiate the DbContext
            var _dbContext = new PersonsDbContext(optionsBuilder.Options);

            // Ask the user if they want to delete the existing database or keep the old one
            Console.WriteLine("Hello Dear User");
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

            DataSeeder.SeedDummyData(_dbContext, zipCodes);

            Console.WriteLine("Data seeding completed. All systems are go. Let's get started!");

            var personService = new PersonService(_dbContext);

            while (true)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Search for a person by name");
                Console.WriteLine("2. Display all persons");
                Console.WriteLine("3. Exit");
                Console.Write("Enter your choice with a number: ");

                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":


                        Console.Write("Enter the firstname or lastname to search: ");//how did I fuck up?
                        string? name = Console.ReadLine();
                        var results = personService.SearchPersons(name);

                        if (results.Count > 0)
                        {
                            Console.WriteLine("Search Results:");
                            foreach (var person in results)
                            {
                                Console.WriteLine($"Name: {person.FirstName} {person.LastName}");
                                Console.WriteLine($"Date of birth: {person.DateOfBirth}");
                                Console.WriteLine($"Adress: {person.Address.Street}");
                                Console.WriteLine($"CityName: {person.Address.Zipcode.CityName}");
                                Console.WriteLine($"PostalCode: {person.Address.Zipcode.PostalCode}");
                                Console.WriteLine($"NisCode: {person.Address.Zipcode.NisCode}");
                                Console.WriteLine($"Province: {person.Address.Zipcode.Province}");
                                Console.WriteLine($"MainCity: {person.Address.Zipcode.Main}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No persons found with that name.");
                        }
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
                        Console.WriteLine("Exiting program...");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
            //public List<Person> SearchName()
            //{
            //Console.Write("Enter the firstname or lastname to search: ");//how did I fuck up?
            //string? name = Console.ReadLine();
            //var results = personService.SearchPersons(name);

            //if (results.Count > 0)
            //{
            //    Console.WriteLine("Search Results:");
            //    foreach (var person in results)
            //    {
            //        Console.WriteLine($"Name: {person.FirstName} {person.LastName}");
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("No persons found with that name.");
            //}
        

        }
    }
}
