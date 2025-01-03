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
                    new Person
                    {
                        FirstName = "Chris",
                        LastName = "P. Bacon",
                        DateOfBirth = new DateTime(1987, 3, 14),
                        Address = new Address { Street = "123 Pancake Blvd.", Country = "Belgium", Zipcode = zipCodes[145] }
                    },
                    new Person
                    {
                        FirstName = "Barry",
                        LastName = "Cade",
                        DateOfBirth = new DateTime(1991, 6, 23),
                        Address = new Address { Street = "456 Barrier St.", Country = "Belgium", Zipcode = zipCodes[623] }
                    },
                    new Person
                    {
                        FirstName = "Minnie",
                        LastName = "Van",
                        DateOfBirth = new DateTime(1994, 8, 7),
                        Address = new Address { Street = "789 Compact Dr.", Country = "Belgium", Zipcode = zipCodes[999] }
                    },
                    new Person
                    {
                        FirstName = "Anita",
                        LastName = "Bath",
                        DateOfBirth = new DateTime(1985, 11, 20),
                        Address = new Address { Street = "321 Tub Ln.", Country = "Belgium", Zipcode = zipCodes[487] }
                    },
                    new Person
                    {
                        FirstName = "Luke",
                        LastName = "Warm",
                        DateOfBirth = new DateTime(1993, 2, 12),
                        Address = new Address { Street = "654 Tepid Rd.", Country = "Belgium", Zipcode = zipCodes[784] }
                    },
                    new Person
                    {
                        FirstName = "Justin",
                        LastName = "Time",
                        DateOfBirth = new DateTime(1990, 7, 30),
                        Address = new Address { Street = "567 Deadline Blvd.", Country = "Belgium", Zipcode = zipCodes[234] }
                    },
                    new Person
                    {
                        FirstName = "Carrie",
                        LastName = "Oaky",
                        DateOfBirth = new DateTime(1982, 4, 15),
                        Address = new Address { Street = "789 Karaoke Ct.", Country = "Belgium", Zipcode = zipCodes[1234] }
                    },
                    new Person
                    {
                        FirstName = "Sue",
                        LastName = "Permarket",
                        DateOfBirth = new DateTime(1995, 5, 22),
                        Address = new Address { Street = "567 Grocery Blvd.", Country = "Belgium", Zipcode = zipCodes[765] }
                    },
                    new Person
                    {
                        FirstName = "Tim",
                        LastName = "Buktu",
                        DateOfBirth = new DateTime(1989, 10, 5),
                        Address = new Address { Street = "321 Desert Rd.", Country = "Belgium", Zipcode = zipCodes[400] }
                    },
                    new Person
                    {
                        FirstName = "Ima",
                        LastName = "Goner",
                        DateOfBirth = new DateTime(1984, 8, 18),
                        Address = new Address { Street = "456 Danger Ln.", Country = "Belgium", Zipcode = zipCodes[1290] }
                    },
                    new Person
                    {
                        FirstName = "Will",
                        LastName = "Power",
                        DateOfBirth = new DateTime(1992, 11, 3),
                        Address = new Address { Street = "654 Determination Dr.", Country = "Belgium", Zipcode = zipCodes[859] }
                    },
                    new Person
                    {
                        FirstName = "Pat",
                        LastName = "Myback",
                        DateOfBirth = new DateTime(1981, 12, 9),
                        Address = new Address { Street = "789 Reward Blvd.", Country = "Belgium", Zipcode = zipCodes[578] }
                    },
                    new Person
                    {
                        FirstName = "Al",
                        LastName = "Dente",
                        DateOfBirth = new DateTime(1990, 1, 21),
                        Address = new Address { Street = "321 Pasta Ave.", Country = "Belgium", Zipcode = zipCodes[1347] }
                    },
                    new Person
                    {
                        FirstName = "Elle",
                        LastName = "Ementary",
                        DateOfBirth = new DateTime(1994, 2, 14),
                        Address = new Address { Street = "567 Basics Blvd.", Country = "Belgium", Zipcode = zipCodes[622] }
                    },
                    new Person
                    {
                        FirstName = "Mark",
                        LastName = "Mywords",
                        DateOfBirth = new DateTime(1986, 3, 28),
                        Address = new Address { Street = "456 Quotes Ln.", Country = "Belgium", Zipcode = zipCodes[315] }
                    },
                    new Person
                    {
                        FirstName = "Phil",
                        LastName = "Harmonic",
                        DateOfBirth = new DateTime(1991, 9, 7),
                        Address = new Address { Street = "123 Symphony Ct.", Country = "Belgium", Zipcode = zipCodes[982] }
                    },
                    new Person
                    {
                        FirstName = "Bea",
                        LastName = "Positive",
                        DateOfBirth = new DateTime(1988, 6, 12),
                        Address = new Address { Street = "789 Optimism Rd.", Country = "Belgium", Zipcode = zipCodes[1203] }
                    },
                    new Person
                    {
                        FirstName = "Gus",
                        LastName = "Tavo",
                        DateOfBirth = new DateTime(1993, 7, 19),
                        Address = new Address { Street = "321 Flavor Blvd.", Country = "Belgium", Zipcode = zipCodes[432] }
                    },
                    new Person
                    {
                        FirstName = "Holly",
                        LastName = "Wood",
                        DateOfBirth = new DateTime(1987, 4, 25),
                        Address = new Address { Street = "567 Fame Ct.", Country = "Belgium", Zipcode = zipCodes[134] }
                    }
        
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
