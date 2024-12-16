using Examen.Advanced.Csharp.Database.Context;
using Microsoft.EntityFrameworkCore;

namespace Examen.Advanced.Csharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<PersonenDbContext>();
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=ExamenAdvancedCsharp;Integrated Security=True");

            // Instantiate the DbContext
            var _dbContext = new PersonenDbContext(optionsBuilder.Options);

            // Optionally, test connection or migrations
            _dbContext.Database.EnsureCreated();
        }
    }
}
