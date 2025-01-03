using Examen.Advanced.Csharp.Contracts.Models;
using Examen.Advanced.Csharp.Database.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;

namespace Examen.Advanced.Csharp
{
    public static class DataSeeder
    {
        public static List<ZipCode>? SeedFromCsv(PersonsDbContext dbContext, string filePath)
        {
            // Check if the table already has data
            if (!dbContext.ZipCode.Any())
            {
                // Use the CsvParser to parse the CSV file
                List<ZipCode> zipCodes = CsvReader.CsvParser.ParseCsvToZipCode(filePath);


                // Add parsed data to the database
                dbContext.ZipCode.AddRange(zipCodes);

                // Save changes to the database
                dbContext.SaveChanges();
                Console.WriteLine("CSV data seeded successfully.");
                return zipCodes;
            }
            else
            {
                Console.WriteLine("Database already contains ZipCode data.");
            }
            return null;
        }
        //add zipCodeId to dummy seed data
        public static void SeedDummyData(PersonsDbContext dbContext, List<ZipCode> zipCodes)
        {
            if (!dbContext.Person.Any()) // Checks if data already exists
            {
                var persons = new List<Person>
                {
                    new Person
                    {
                        FirstName = "John",
                        LastName = "Doe",
                        DateOfBirth = new DateTime(1990, 5, 20),
                        Address = new Address {Street = "123 Main Street",Country = "Belgium", Zipcode = zipCodes[1]}
                    },
                    new Person
                    {
                        FirstName = "Jane",
                        LastName = "Smith",
                        DateOfBirth = new DateTime(1985, 3, 10),
                        Address = new Address
                        {Street = "456 Elm Street",Country = "Belgium", Zipcode = zipCodes[2]}
                    },
                    new Person
                    {
                        FirstName = "Alice",
                        LastName = "Johnson",
                        DateOfBirth = new DateTime(2000, 12, 15),
                        Address = new Address
                        {Street = "789 Oak Avenue",Country = "Belgium", Zipcode = zipCodes[50]}
                    },
                    new Person
                    {
                        FirstName = "Al",
                        LastName = "Beback",
                        DateOfBirth = new DateTime(1992, 8, 22),
                        Address = new Address { Street = "456 Elm St.", Country = "Belgium", Zipcode = zipCodes[27]}
                    },
                    new Person
                    {
                        FirstName = "Anita",
                        LastName = "Bath",
                        DateOfBirth = new DateTime(1978, 3, 10),
                        Address = new Address { Street = "789 Willow Rd.", Country = "Belgium", Zipcode = zipCodes[15]}
                    },
                    new Person
                    {
                        FirstName = "Barb",
                        LastName = "Dwyer",
                        DateOfBirth = new DateTime(1990, 12, 5),
                        Address = new Address { Street = "321 Pine Ave.", Country = "Belgium", Zipcode = zipCodes[47]}
                    },
                    new Person
                    {
                        FirstName = "Chris",
                        LastName = "P. Bacon",
                        DateOfBirth = new DateTime(2002, 7, 30),
                        Address = new Address { Street = "654 Maple Dr.", Country = "Belgium" , Zipcode = zipCodes[85]}
                    },
                    new Person
                    {
                        FirstName = "Doug",
                        LastName = "Graves",
                        DateOfBirth = new DateTime(1965, 11, 1),
                        Address = new Address { Street = "987 Cedar Ln.", Country = "Belgium", Zipcode = zipCodes[41]}
                    },
                    new Person
                    {
                        FirstName = "Ella",
                        LastName = "Vator",
                        DateOfBirth = new DateTime(1995, 9, 17),
                        Address = new Address { Street = "159 Spruce Blvd.", Country = "Belgium", Zipcode = zipCodes[81]}
                    },
                    new Person
                    {
                        FirstName = "Frank",
                        LastName = "N. Stein",
                        DateOfBirth = new DateTime(1980, 10, 31),
                        Address = new Address { Street = "753 Birch Way", Country = "Belgium", Zipcode = zipCodes[181] }
                    },
                    new Person
                    {
                        FirstName = "Gail",
                        LastName = "Forcewind",
                        DateOfBirth = new DateTime(1999, 6, 21),
                        Address = new Address { Street = "147 Aspen Rd.", Country = "Belgium", Zipcode = zipCodes[587]}
                    },
                    new Person
                    {
                        FirstName = "Harry",
                        LastName = "Azcrack",
                        DateOfBirth = new DateTime(2001, 4, 9),
                        Address = new Address { Street = "369 Fir Ln.", Country = "Belgium", Zipcode = zipCodes[20]}
                    },
                    new Person
                    {
                        FirstName = "Ima",
                        LastName = "Pigg",
                        DateOfBirth = new DateTime(1974, 1, 15),
                        Address = new Address { Street = "951 Oak Grove", Country = "Belgium", Zipcode = zipCodes[880]}
                    },
                    new Person
                    {
                        FirstName = "Justin",
                        LastName = "Time",
                        DateOfBirth = new DateTime(1987, 2, 28),
                        Address = new Address { Street = "753 Palm Blvd.", Country = "Belgium", Zipcode = zipCodes[320]}
                    },
                    new Person
                    {
                        FirstName = "Lois",
                        LastName = "Price",
                        DateOfBirth = new DateTime(1993, 3, 12),
                        Address = new Address { Street = "852 Cypress St.", Country = "Belgium", Zipcode = zipCodes[120]}
                    },
                    new Person
                    {
                        FirstName = "Paige",
                        LastName = "Turner",
                        DateOfBirth = new DateTime(1996, 7, 8),
                        Address = new Address { Street = "654 Redwood Ave.", Country = "Belgium", Zipcode = zipCodes[547]}
                    },
                    new Person
                    {
                        FirstName = "Will",
                        LastName = "Power",
                        DateOfBirth = new DateTime(1988, 5, 19),
                        Address = new Address { Street = "456 Walnut Rd.", Country = "Belgium", Zipcode = zipCodes[604]}
                    },
                };

                // Add the dummy data to the DbContext
                dbContext.Person.AddRange(persons);

                // Save changes to the database
                dbContext.SaveChanges();
                Console.WriteLine("Dummy data seeded successfully.");
            }
            else
            {
                Console.WriteLine("Database already contains data.");
            }
        }
    }
}
