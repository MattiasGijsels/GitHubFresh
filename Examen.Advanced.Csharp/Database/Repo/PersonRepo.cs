using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Examen.Advanced.Csharp.Contracts.Models;
using Examen.Advanced.Csharp.Database.Context;
using Microsoft.EntityFrameworkCore;

namespace Examen.Advanced.Csharp.Database.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly PersonsDbContext _dbContext;

        public PersonRepository(PersonsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Person>> GetAllPersonsAsync()
        {
            // Get all persons that are not marked as deleted
            return await _dbContext.Person
                .Include(p => p.Address)
                .Where(p => !p.IsDeleted)
                .ToListAsync();//add to learnings
        }
        public static async Task AddPersonAsync(IPersonRepository repository)
        {
            Console.Write("Enter first name: ");
            string? firstName = Console.ReadLine();

            Console.Write("Enter last name: ");
            string? lastName = Console.ReadLine();

            Console.Write("Enter date of birth (yyyy-mm-dd): ");
            DateTime dateOfBirth;
            while (!DateTime.TryParse(Console.ReadLine(), out dateOfBirth)) //add to learnings
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

            await repository.AddPersonToDbAsync(newPerson);
            Console.WriteLine("Person added successfully!");
        }
        public async Task AddPersonToDbAsync(Person person)
        {
            _dbContext.Person.Add(person);
            await _dbContext.SaveChangesAsync(); // Save the new person to the database - add to learnings
        }

        public async Task DeletePersonAsync(string id)
        {
            // Find the person by ID and mark them as deleted
            var person = await _dbContext.Person.FindAsync(id);//- add to learnings
            if (person != null)
            {
                person.IsDeleted = true; // Soft delete
                await _dbContext.SaveChangesAsync(); // Save changes
            }
        }
        public async Task ModifyPersonAsync()
        {
            Console.Write("Enter the first name or last name of the person to modify: ");
            string name = Console.ReadLine() ?? string.Empty;

            // Find the person by first name or last name
            var person = await _dbContext.Person
                .Include(p => p.Address)
                .FirstOrDefaultAsync(p => (p.FirstName == name || p.LastName == name) && !p.IsDeleted);

            if (person == null)
            {
                Console.WriteLine("Person not found.");
                return;
            }

            // Get new details from the user
            Console.Write("Enter new first name (leave empty to keep current): ");
            string? newFirstName = Console.ReadLine();
            if (!string.IsNullOrEmpty(newFirstName))
            {
                person.FirstName = newFirstName;
            }

            Console.Write("Enter new last name (leave empty to keep current): ");
            string? newLastName = Console.ReadLine();
            if (!string.IsNullOrEmpty(newLastName))
            {
                person.LastName = newLastName;
            }

            Console.Write("Enter new street address (leave empty to keep current): ");
            string? newStreet = Console.ReadLine();
            if (!string.IsNullOrEmpty(newStreet))
            {
                person.Address.Street = newStreet;
            }

            Console.Write("Enter new country (leave empty to keep current): ");
            string? newCountry = Console.ReadLine();
            if (!string.IsNullOrEmpty(newCountry))
            {
                person.Address.Country = newCountry;
            }

            Console.Write("Enter new city (leave empty to keep current): ");
            string? newCityName = Console.ReadLine();
            if (!string.IsNullOrEmpty(newCityName))
            {
                person.Address.ZipCode.CityName = newCityName;
            }

            Console.Write("Enter a new postalcode, only 4 numbers! (leave empty to keep current): ");
            string? newPostalCode = Console.ReadLine();
            if (!string.IsNullOrEmpty(newPostalCode))
            {
                person.Address.ZipCode.PostalCode = newPostalCode;
            }

            Console.Write("Enter a new NISCODE, only 5 numbers! (leave empty to keep current): ");
            string? newNisCode = Console.ReadLine();
            if (!string.IsNullOrEmpty(newNisCode))
            {
                person.Address.ZipCode.NisCode = newNisCode;
            }

            Console.Write("Enter a new province (leave empty to keep current): ");
            string? newProvince = Console.ReadLine();
            if (!string.IsNullOrEmpty(newProvince))
            {
                person.Address.ZipCode.NisCode = newProvince;
            }
            Console.Write("Enter a new main (true/false, leave empty to keep current): ");
            string? mainInput = Console.ReadLine();
            if (bool.TryParse(mainInput, out bool newMain))
            {
                person.Address.ZipCode.Main = newMain;
            }

            // Save the updated person to the database
            await _dbContext.SaveChangesAsync();
            Console.WriteLine("Person modified successfully!");
        }

    }
}
