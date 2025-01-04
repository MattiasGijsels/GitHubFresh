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
            // Checks if the table already has data
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
                        Address = new Address {Street = "123 Main Street",Country = "Belgium", ZipCode = zipCodes[1]}
                    },
                    new Person
                    {
                        FirstName = "Jane",
                        LastName = "Smith",
                        DateOfBirth = new DateTime(1985, 3, 10),
                        Address = new Address
                        {Street = "456 Elm Street",Country = "Belgium", ZipCode = zipCodes[2]}
                    },
                    new Person
                    {
                        FirstName = "Alice",
                        LastName = "Johnson",
                        DateOfBirth = new DateTime(2000, 12, 15),
                        Address = new Address
                        {Street = "789 Oak Avenue",Country = "Belgium", ZipCode = zipCodes[50]}
                    },
                    new Person
                    {
                        FirstName = "Al",
                        LastName = "Beback",
                        DateOfBirth = new DateTime(1992, 8, 22),
                        Address = new Address { Street = "456 Elm St.", Country = "Belgium", ZipCode = zipCodes[27]}
                    },
                    new Person
                    {
                        FirstName = "Anitas",
                        LastName = "Bath",
                        DateOfBirth = new DateTime(1978, 3, 10),
                        Address = new Address { Street = "789 Willow Rd.", Country = "Belgium", ZipCode = zipCodes[15]}
                    },
                    new Person
                    {
                        FirstName = "Barb",
                        LastName = "Dwyer",
                        DateOfBirth = new DateTime(1990, 12, 5),
                        Address = new Address { Street = "321 Pine Ave.", Country = "Belgium", ZipCode = zipCodes[47]}
                    },
                    new Person
                    {
                        FirstName = "Chris",
                        LastName = "P. Bacon",
                        DateOfBirth = new DateTime(2002, 7, 30),
                        Address = new Address { Street = "654 Maple Dr.", Country = "Belgium" , ZipCode = zipCodes[85]}
                    },
                    new Person
                    {
                        FirstName = "Doug",
                        LastName = "Graves",
                        DateOfBirth = new DateTime(1965, 11, 1),
                        Address = new Address { Street = "987 Cedar Ln.", Country = "Belgium", ZipCode = zipCodes[41]}
                    },
                    new Person
                    {
                        FirstName = "Ella",
                        LastName = "Vator",
                        DateOfBirth = new DateTime(1995, 9, 17),
                        Address = new Address { Street = "159 Spruce Blvd.", Country = "Belgium", ZipCode = zipCodes[81]}
                    },
                    new Person
                    {
                        FirstName = "Frank",
                        LastName = "N. Stein",
                        DateOfBirth = new DateTime(1980, 10, 31),
                        Address = new Address { Street = "753 Birch Way", Country = "Belgium", ZipCode = zipCodes[181] }
                    },
                    new Person
                    {
                        FirstName = "Gail",
                        LastName = "Forcewind",
                        DateOfBirth = new DateTime(1999, 6, 21),
                        Address = new Address { Street = "147 Aspen Rd.", Country = "Belgium", ZipCode = zipCodes[587]}
                    },
                    new Person
                    {
                        FirstName = "Harry",
                        LastName = "Azcrack",
                        DateOfBirth = new DateTime(2001, 4, 9),
                        Address = new Address { Street = "369 Fir Ln.", Country = "Belgium", ZipCode = zipCodes[20]}
                    },
                    new Person
                    {
                        FirstName = "Imma",
                        LastName = "Pigg",
                        DateOfBirth = new DateTime(1974, 1, 15),
                        Address = new Address { Street = "951 Oak Grove", Country = "Belgium", ZipCode = zipCodes[880]}
                    },
                    new Person
                    {
                        FirstName = "Justin",
                        LastName = "Time",
                        DateOfBirth = new DateTime(1987, 2, 28),
                        Address = new Address { Street = "753 Palm Blvd.", Country = "Belgium", ZipCode = zipCodes[320]}
                    },
                    new Person
                    {
                        FirstName = "Lois",
                        LastName = "Price",
                        DateOfBirth = new DateTime(1993, 3, 12),
                        Address = new Address { Street = "852 Cypress St.", Country = "Belgium", ZipCode = zipCodes[120]}
                    },
                    new Person
                    {
                        FirstName = "Paigé",
                        LastName = "Turner",
                        DateOfBirth = new DateTime(1996, 7, 8),
                        Address = new Address { Street = "654 Redwood Ave.", Country = "Belgium", ZipCode = zipCodes[547]}
                    },
                    new Person
                    {
                        FirstName = "Willy",
                        LastName = "Power",
                        DateOfBirth = new DateTime(1988, 5, 19),
                        Address = new Address { Street = "456 Walnut Rd.", Country = "Belgium", ZipCode = zipCodes[604]}
                    },      
                    new Person
                    {
                        FirstName = "Chris",
                        LastName = "Pi. Bacon",
                        DateOfBirth = new DateTime(1987, 3, 14),
                        Address = new Address { Street = "123 Pancake Blvd.", Country = "Belgium", ZipCode = zipCodes[145] }
                    },
                    new Person
                    {
                        FirstName = "Barry",
                        LastName = "Caden",
                        DateOfBirth = new DateTime(1991, 6, 23),
                        Address = new Address { Street = "456 Barrier St.", Country = "Belgium", ZipCode = zipCodes[623] }
                    },
                    new Person
                    {
                        FirstName = "Minnie",
                        LastName = "Van",
                        DateOfBirth = new DateTime(1994, 8, 7),
                        Address = new Address { Street = "789 Compact Dr.", Country = "Belgium", ZipCode = zipCodes[999] }
                    },
                    new Person
                    {
                        FirstName = "Anitta",
                        LastName = "Bath",
                        DateOfBirth = new DateTime(1985, 11, 20),
                        Address = new Address { Street = "321 Tub Ln.", Country = "Belgium", ZipCode = zipCodes[487] }
                    },
                    new Person
                    {
                        FirstName = "Lukas",
                        LastName = "Warm",
                        DateOfBirth = new DateTime(1993, 2, 12),
                        Address = new Address { Street = "654 Tepid Rd.", Country = "Belgium", ZipCode = zipCodes[784] }
                    },
                    new Person
                    {
                        FirstName = "Justin",
                        LastName = "Time",
                        DateOfBirth = new DateTime(1990, 7, 30),
                        Address = new Address { Street = "567 Deadline Blvd.", Country = "Belgium", ZipCode = zipCodes[234] }
                    },
                    new Person
                    {
                        FirstName = "Carrie",
                        LastName = "Oaky",
                        DateOfBirth = new DateTime(1982, 4, 15),
                        Address = new Address { Street = "789 Karaoke Ct.", Country = "Belgium", ZipCode = zipCodes[1234] }
                    },
                    new Person
                    {
                        FirstName = "Sue",
                        LastName = "Permarket",
                        DateOfBirth = new DateTime(1995, 5, 22),
                        Address = new Address { Street = "567 Grocery Blvd.", Country = "Belgium", ZipCode = zipCodes[765] }
                    },
                    new Person
                    {
                        FirstName = "Tim",
                        LastName = "Buktu",
                        DateOfBirth = new DateTime(1989, 10, 5),
                        Address = new Address { Street = "321 Desert Rd.", Country = "Belgium", ZipCode = zipCodes[400] }
                    },
                    new Person
                    {
                        FirstName = "Ima",
                        LastName = "Goner",
                        DateOfBirth = new DateTime(1984, 8, 18),
                        Address = new Address { Street = "456 Danger Ln.", Country = "Belgium", ZipCode = zipCodes[1290] }
                    },
                    new Person
                    {
                        FirstName = "William",
                        LastName = "Power",
                        DateOfBirth = new DateTime(1992, 11, 3),
                        Address = new Address { Street = "654 Determination Dr.", Country = "Belgium", ZipCode = zipCodes[859] }
                    },
                    new Person
                    {
                        FirstName = "Pat",
                        LastName = "Myback",
                        DateOfBirth = new DateTime(1981, 12, 9),
                        Address = new Address { Street = "789 Reward Blvd.", Country = "Belgium", ZipCode = zipCodes[578] }
                    },
                    new Person
                    {
                        FirstName = "Al",
                        LastName = "Dente",
                        DateOfBirth = new DateTime(1990, 1, 21),
                        Address = new Address { Street = "321 Pasta Ave.", Country = "Belgium", ZipCode = zipCodes[1347] }
                    },
                    new Person
                    {
                        FirstName = "Elle",
                        LastName = "Ementary",
                        DateOfBirth = new DateTime(1994, 2, 14),
                        Address = new Address { Street = "567 Basics Blvd.", Country = "Belgium", ZipCode = zipCodes[622] }
                    },
                    new Person
                    {
                        FirstName = "Mark",
                        LastName = "Mywords",
                        DateOfBirth = new DateTime(1986, 3, 28),
                        Address = new Address { Street = "456 Quotes Ln.", Country = "Belgium", ZipCode = zipCodes[315] }
                    },
                    new Person
                    {
                        FirstName = "Phil",
                        LastName = "Harmonic",
                        DateOfBirth = new DateTime(1991, 9, 7),
                        Address = new Address { Street = "123 Symphony Ct.", Country = "Belgium", ZipCode = zipCodes[982] }
                    },
                    new Person
                    {
                        FirstName = "Bea",
                        LastName = "Positive",
                        DateOfBirth = new DateTime(1988, 6, 12),
                        Address = new Address { Street = "789 Optimism Rd.", Country = "Belgium", ZipCode = zipCodes[1203] }
                    },
                    new Person
                    {
                        FirstName = "Gus",
                        LastName = "Tavo",
                        DateOfBirth = new DateTime(1993, 7, 19),
                        Address = new Address { Street = "321 Flavor Blvd.", Country = "Belgium", ZipCode = zipCodes[432] }
                    },
                    new Person
                    {
                        FirstName = "Holly",
                        LastName = "Wood",
                        DateOfBirth = new DateTime(1987, 4, 25),
                        Address = new Address { Street = "567 Fame Ct.", Country = "Belgium", ZipCode = zipCodes[134] }
                    },
                                new Person
                    {
                        FirstName = "Johnny",
                        LastName = "Doe",
                        DateOfBirth = new DateTime(1980, 1, 15),
                        Address = new Address { Street = "123 Main St.", Country = "Belgium", ZipCode = zipCodes[59] }
                    },
                    new Person
                    {
                        FirstName = "Jannine",
                        LastName = "Doe",
                        DateOfBirth = new DateTime(1985, 7, 20),
                        Address = new Address { Street = "456 Oak Ave.", Country = "Belgium", ZipCode = zipCodes[59] }
                    },
                    new Person
                    {
                        FirstName = "David",
                        LastName = "Lee",
                        DateOfBirth = new DateTime(1978, 11, 5),
                        Address = new Address { Street = "789 Pine Rd.", Country = "Belgium", ZipCode = zipCodes[59] }
                    },
                    new Person
                    {
                        FirstName = "Sarah",
                        LastName = "Jones",
                        DateOfBirth = new DateTime(1990, 3, 12),
                        Address = new Address { Street = "101 Maple Dr.", Country = "Belgium", ZipCode = zipCodes[59] }
                    },
                    new Person
                    {
                        FirstName = "Michael",
                        LastName = "Brown",
                        DateOfBirth = new DateTime(1975, 5, 28),
                        Address = new Address { Street = "202 Elm St.", Country = "Belgium", ZipCode = zipCodes[59] }
                    },
                    new Person
                    {
                        FirstName = "Emily",
                        LastName = "Davis",
                        DateOfBirth = new DateTime(1992, 9, 18),
                        Address = new Address { Street = "303 Oak St.", Country = "Belgium", ZipCode = zipCodes[59] }
                    },
                    new Person
                    {
                        FirstName = "James",
                        LastName = "Wilson",
                        DateOfBirth = new DateTime(1982, 1, 2),
                        Address = new Address { Street = "404 Pine St.", Country = "Belgium", ZipCode = zipCodes[59] }
                    },
                    new Person
                    {
                        FirstName = "Olivia",
                        LastName = "Moore",
                        DateOfBirth = new DateTime(1988, 6, 10),
                        Address = new Address { Street = "505 Maple St.", Country = "Belgium", ZipCode = zipCodes[59] }
                    },
                    new Person
                    {
                        FirstName = "Daniel",
                        LastName = "Taylor",
                        DateOfBirth = new DateTime(1977, 12, 24),
                        Address = new Address { Street = "606 Elm St.", Country = "Belgium", ZipCode = zipCodes[59] }
                    },
                    new Person
                    {
                        FirstName = "Sophia",
                        LastName = "Anderson",
                        DateOfBirth = new DateTime(1991, 4, 15),
                        Address = new Address { Street = "707 Oak St.", Country = "Belgium", ZipCode = zipCodes[59] }
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
