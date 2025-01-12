using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Labo.API.Database.Context;
using System;
using Labo.API.Database.DbSeeder;
using Microsoft.AspNetCore.Builder;

namespace Labo.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<BooksDbContext>(options =>
                options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=BooksDb;Trusted_Connection=True;MultipleActiveResultSets=true"));
            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<BooksDbContext>();
                dbContext.Database.Migrate();
                Console.WriteLine("DbContext initialized successfully!");

                DbSeeder.SeedDummyData(dbContext); // Corrected line
            }

            app.Run();
        }
    }
}
