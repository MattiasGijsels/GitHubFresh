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
        public async Task AddPersonAsync(Person person)
        {
            await AddPersonToDbAsync(person);
            Console.WriteLine("Person added successfully!");
        }
        public async Task AddPersonToDbAsync(Person person)
        {
            _dbContext.Person.Add(person);
            await _dbContext.SaveChangesAsync();
            #region
            // SaveChangesAsync() automatically detects any changes made to entities tracked by the DbContext.
            // These changes can include: New entities: Entities added using Add(), AddRange()
            #endregion
        }

        public async Task DeletePersonAsync(string namePerson)
        {
            // Find the person by first name or last name
            var person = await _dbContext.Person
                .FirstOrDefaultAsync(p => (p.FirstName == namePerson || p.LastName == namePerson) && !p.IsDeleted);

            // If a person is found, delete them (soft delete)
            if (person != null)
            {
                person.IsDeleted = true; // Mark as deleted
                await _dbContext.SaveChangesAsync(); // Save changes
                Console.WriteLine($"{namePerson} has been deleted.");
            }
            else
            {
                Console.WriteLine("Person not found.");
            }
        }

        public async Task ModifyPersonAsync(string name)
        {
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
