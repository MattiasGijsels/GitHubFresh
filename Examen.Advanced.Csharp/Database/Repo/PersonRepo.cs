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
                .ToListAsync();
        }
        public static async Task AddPersonAsync(IPersonRepository repository)
        {
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
    }
}
