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

        public async Task AddPersonAsync(Person person)
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
