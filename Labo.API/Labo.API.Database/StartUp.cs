using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Labo.API.Database.Context;
using System;

namespace Labo.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Set up the dependency injection container
            var serviceProvider = new ServiceCollection()
                .AddDbContext<BooksDbContext>(options =>
                    options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=BooksDb;Trusted_Connection=True;MultipleActiveResultSets=true"))
                .BuildServiceProvider();

            // Get an instance of the DbContext from the service provider
            using (var scope = serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<BooksDbContext>();

                // Perform any operations with the DbContext here
                // For example, adding a new book:
                // dbContext.Books.Add(new Book { Title = "New Book" });
                // dbContext.SaveChanges();

                Console.WriteLine("DbContext initialized successfully!");
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
