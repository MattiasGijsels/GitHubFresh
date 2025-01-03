using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Examen.Advanced.Csharp.Contracts.Models;
using Examen.Advanced.Csharp.Database.Context;

public class PersonService
{
    private readonly PersonsDbContext _context;

    public PersonService(PersonsDbContext context)
    {
        _context = context;
    }

    public List<Person> SearchPersons(string? name)
    {
        // If no firstname or lastname is provided, just return all persons please
        if (string.IsNullOrWhiteSpace(name))
        {
            return _context.Person.ToList(); // Return all persons if no name is provided//just give error not all the data
        }
        else
        {
            // Apply filters for both firstName and lastName if provided
            return _context.Person
                .Where(p => p.FirstName.ToLower().Contains(name.ToLower())||p.LastName.ToLower().Contains(name.ToLower())).ToList(); // Filter by last name or first name
        }
    }
}
