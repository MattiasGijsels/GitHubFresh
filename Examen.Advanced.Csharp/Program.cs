using CsvParser;
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
            string csvFilePath = "C:\\Users\\matti\\Source\\Repos\\GitHubFresh\\Examen.Advanced.Csharp\\Src\\postcodes.csv"; // Path to your CSV file
            DataSeeder.SeedFromCsv(_dbContext, csvFilePath);

            DataSeeder.SeedDummyData(_dbContext);

            //string filePath = "C:\\Users\\matti\\Source\\Repos\\GitHubFresh\\Examen.Advanced.Csharp\\Src\\postcodes.csv"; // Path to your CSV file

            //try
            //{
            //    // Use the CsvParser to parse the file
            //    List<ZipCode> zipCodes = CsvParser.ParseCsvToZipCode(filePath);

            //    // Print the parsed data
            //    foreach (var zipCode in zipCodes)
            //    {
            //        Console.WriteLine($"City: {zipCode.CityName}, Postal Code: {zipCode.PostalCode}, NIS: {zipCode.NisCode}, Province: {zipCode.Province}, Country: {zipCode.Country}");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"An error occurred: {ex.Message}");
            //}
        }
    }
}
