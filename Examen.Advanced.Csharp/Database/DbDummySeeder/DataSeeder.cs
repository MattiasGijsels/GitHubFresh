using Examen.Advanced.Csharp.Contracts.Models;
using Examen.Advanced.Csharp.Database.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Examen.Advanced.Csharp
{
    public static class DataSeeder
    {
        public static void SeedDummyData(PersonenDbContext dbContext)
        {
            if (!dbContext.Person.Any()) // Check if data already exists
            {
                var persons = new List<Person>
                {
                    new Person
                    {
                        FirstName = "John",
                        LastName = "Doe",
                        DateOfBirth = new DateTime(1990, 5, 20),
                        Address = new Address {Street = "123 Main Street",Country = "Belgium"}
                    },
                    new Person
                    {
                        FirstName = "Jane",
                        LastName = "Smith",
                        DateOfBirth = new DateTime(1985, 3, 10),
                        Address = new Address
                        {Street = "456 Elm Street",Country = "Belgium"}
                    },
                    new Person
                    {
                        FirstName = "Alice",
                        LastName = "Johnson",
                        DateOfBirth = new DateTime(2000, 12, 15),
                        Address = new Address
                        {Street = "789 Oak Avenue",Country = "Belgium"
                        }
                    },
                    new Person
                    {
                        FirstName = "Al",
                        LastName = "Beback",
                        DateOfBirth = new DateTime(1992, 8, 22),
                        Address = new Address { Street = "456 Elm St.", Country = "Austria" }
                    },
                    new Person
                    {
                        FirstName = "Anita",
                        LastName = "Bath",
                        DateOfBirth = new DateTime(1978, 3, 10),
                        Address = new Address { Street = "789 Willow Rd.", Country = "Canada" }
                    },
                    new Person
                    {
                        FirstName = "Barb",
                        LastName = "Dwyer",
                        DateOfBirth = new DateTime(1990, 12, 5),
                        Address = new Address { Street = "321 Pine Ave.", Country = "Australia" }
                    },
                    new Person
                    {
                        FirstName = "Chris",
                        LastName = "P. Bacon",
                        DateOfBirth = new DateTime(2002, 7, 30),
                        Address = new Address { Street = "654 Maple Dr.", Country = "Ireland" }
                    },
                    new Person
                    {
                        FirstName = "Doug",
                        LastName = "Graves",
                        DateOfBirth = new DateTime(1965, 11, 1),
                        Address = new Address { Street = "987 Cedar Ln.", Country = "UK" }
                    },
                    new Person
                    {
                        FirstName = "Ella",
                        LastName = "Vator",
                        DateOfBirth = new DateTime(1995, 9, 17),
                        Address = new Address { Street = "159 Spruce Blvd.", Country = "Germany" }
                    },
                    new Person
                    {
                        FirstName = "Frank",
                        LastName = "N. Stein",
                        DateOfBirth = new DateTime(1980, 10, 31),
                        Address = new Address { Street = "753 Birch Way", Country = "USA" }
                    },
                    new Person
                    {
                        FirstName = "Gail",
                        LastName = "Forcewind",
                        DateOfBirth = new DateTime(1999, 6, 21),
                        Address = new Address { Street = "147 Aspen Rd.", Country = "Canada" }
                    },
                    new Person
                    {
                        FirstName = "Harry",
                        LastName = "Azcrack",
                        DateOfBirth = new DateTime(2001, 4, 9),
                        Address = new Address { Street = "369 Fir Ln.", Country = "New Zealand" }
                    },
                    new Person
                    {
                        FirstName = "Ima",
                        LastName = "Pigg",
                        DateOfBirth = new DateTime(1974, 1, 15),
                        Address = new Address { Street = "951 Oak Grove", Country = "South Africa" }
                    },
                    new Person
                    {
                        FirstName = "Justin",
                        LastName = "Time",
                        DateOfBirth = new DateTime(1987, 2, 28),
                        Address = new Address { Street = "753 Palm Blvd.", Country = "USA" }
                    },
                    new Person
                    {
                        FirstName = "Lois",
                        LastName = "Price",
                        DateOfBirth = new DateTime(1993, 3, 12),
                        Address = new Address { Street = "852 Cypress St.", Country = "Ireland" }
                    },
                    new Person
                    {
                        FirstName = "Paige",
                        LastName = "Turner",
                        DateOfBirth = new DateTime(1996, 7, 8),
                        Address = new Address { Street = "654 Redwood Ave.", Country = "Germany" }
                    },
                    new Person
                    {
                        FirstName = "Will",
                        LastName = "Power",
                        DateOfBirth = new DateTime(1988, 5, 19),
                        Address = new Address { Street = "456 Walnut Rd.", Country = "USA" }
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
