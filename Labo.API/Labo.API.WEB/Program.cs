
using Examen.Advanced.Csharp.Database.Repositories;
using Labo.API.Database.Context;
using Labo.API.WEB.Services;
using Microsoft.EntityFrameworkCore;

namespace Labo.API.WEB
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<BooksDbContext>(options =>
                options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=BooksDb;Trusted_Connection=True;MultipleActiveResultSets=true"));

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IRepoBooks,RepoBooks>();
            builder.Services.AddScoped<IManagerService,ManagerService>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
