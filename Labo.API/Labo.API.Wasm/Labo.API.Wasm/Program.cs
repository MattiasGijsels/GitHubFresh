using Labo.API.Wasm.Client.Pages;
using Labo.API.Wasm.Components;
using Microsoft.EntityFrameworkCore.Design;
using Examen.Advanced.Csharp.Database.Repositories;
using Labo.API.Database.Context;
using Labo.API.Database.DbSeeder;
using Labo.API.WEB.Services;
using Microsoft.EntityFrameworkCore;

namespace Labo.API.Wasm
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<BooksDbContext>(options =>
            options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=BooksDb;Trusted_Connection=True;MultipleActiveResultSets=true"));
            //gebruik config file
            builder.Services.AddControllers();
            builder.Services.AddScoped<IRepoBooks, RepoBooks>();
            builder.Services.AddScoped<IManagerService, ManagerService>();

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveWebAssemblyComponents();

            var app = builder.Build();
            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<BooksDbContext>();
                DbSeeder.SeedDummyData(context);
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();
            app.MapControllers();
            app.MapRazorComponents<App>()
                .AddInteractiveWebAssemblyRenderMode()
                .AddAdditionalAssemblies(typeof(Client._Imports).Assembly);

            app.Run();
        }
    }
}
