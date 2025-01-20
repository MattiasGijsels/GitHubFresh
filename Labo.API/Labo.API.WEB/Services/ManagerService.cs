using Labo.API.Database;
using Labo.API.Contracts.Models;
using Labo.API.Database.Context;
using Labo.API.WEB.Services;
using Examen.Advanced.Csharp.Database.Repositories;

namespace Labo.API.WEB.Services
{
    public class ManagerService : IManagerService
       
    {
        IRepoBooks Repo { get; init; } = default!;
        public ManagerService(IRepoBooks repo)
        {
            Repo = repo;
        }
        async Task<bool> IManagerService.AddBookAsync(Books book)
        {
            await Repo.AddBookAsync(book);
            return true;
        }
        async Task<bool> IManagerService.DeleteAsync(string id)
        {
            await Repo.DeleteBooksAsync(id);
            return true;
        }

        async Task<IEnumerable<Books>> IManagerService.FilterAsync(string? id, string? BookTitle, string? GenreName, string? FirstName, string? LastName)
        {
            return await Repo.FilterAsync(id,BookTitle,GenreName,FirstName,LastName);
        }

        async Task<IEnumerable<Books>> IManagerService.FindBookAsync(string BookTitle)
        {
             return await Repo.FindBookAsync(BookTitle);
        }

        async Task<IEnumerable<Books>> IManagerService.GetAllAsync()
        {
            return await Repo.GetAllAsync();
        }

        Task<Books?> IManagerService.GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        async Task<bool> IManagerService.UpdateAsync(Books book)
        {
            return await Repo.UpdateAsync(book);
        }

        async Task<bool> IManagerService.UpsertAsync(Books book)
        {
            return await Repo.UpsertAsync(book);
        }
    }
}
