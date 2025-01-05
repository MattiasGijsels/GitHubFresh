using System.Collections.Generic;
using System.Threading.Tasks;
using Examen.Advanced.Csharp.Contracts.Models;

namespace Examen.Advanced.Csharp.Database.Repositories
{
    public interface IPersonRepository
    {
        Task<List<Person>> GetAllPersonsAsync(); // Get all non-deleted persons
        Task AddPersonToDbAsync(Person person);     // Add a new person
        Task DeletePersonAsync();      // Soft delete a person
        Task ModifyPersonAsync();       //modify a person
    }
}
