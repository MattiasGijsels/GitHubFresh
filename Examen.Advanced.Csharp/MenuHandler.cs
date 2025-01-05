using Examen.Advanced.Csharp.Contracts.Models;
using Examen.Advanced.Csharp.Database.Context;
using Examen.Advanced.Csharp.Database.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.Advanced.Csharp
{
    internal static class MenuHandler
    {
        public static async Task HandleAsync(PersonsDbContext _dbContext)
        {
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
                        Console.Write("Enter first name: ");
                        string? firstName = Console.ReadLine();

                        Console.Write("Enter last name: ");
                        string? lastName = Console.ReadLine();

                        Console.Write("Enter date of birth (yyyy-mm-dd): ");
                        DateTime dateOfBirth;
                        while (!DateTime.TryParse(Console.ReadLine(), out dateOfBirth))
                        {
                            Console.Write("Invalid date. Please enter again (yyyy-mm-dd): ");
                        }

                        Console.Write("Enter street address: ");
                        string? street = Console.ReadLine();

                        Console.Write("Enter Country: ");
                        string? country = Console.ReadLine();

                        Console.Write("Enter City name: ");
                        string? cityname = Console.ReadLine();

                        Console.Write("Enter postalcode: ");
                        string? postalcode = Console.ReadLine();

                        Console.Write("Enter niscode : ");
                        string? niscode = Console.ReadLine();

                        Console.Write("Enter province : ");
                        string? province = Console.ReadLine();

                        Console.Write("Enter main (true/false): ");
                        string? main = Console.ReadLine()?.ToLower();
                        bool isMain = main == "true";


                        var newPerson = new Person
                        {
                            Id = Guid.NewGuid().ToString(),
                            FirstName = firstName,
                            LastName = lastName,
                            DateOfBirth = dateOfBirth,
                            Address = new Address
                            {
                                Street = street,
                                Country = country,
                                ZipCode = new ZipCode
                                {
                                    CityName = cityname,
                                    PostalCode = postalcode,
                                    NisCode = niscode,
                                    Province = province,
                                    Main = isMain
                                }
                            }
                        };

                        await personRepository.AddPersonAsync(newPerson);
                        break;

                    case "4":
                        Console.Write("Enter the first name or last name of the person to modify: ");
                        string name = Console.ReadLine() ?? string.Empty;
                        await personRepository.ModifyPersonAsync(name);
                        break;

                    case "5":
                        Console.Write("Enter first or last name of the person you want to delete: ");
                        string namePerson = Console.ReadLine()?.Trim() ?? string.Empty;
                        await personRepository.DeletePersonAsync(namePerson);
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
