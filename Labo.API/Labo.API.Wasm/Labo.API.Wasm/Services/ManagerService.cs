using Examen.Advanced.Csharp.Database.Repositories;
using Labo.API.Database.Context;
using Labo.API.Contracts.Models;
using Labo.API.Wasm.Shared;

namespace Labo.API.Wasm.Services
{
    public class ManagerService: IManagerService
    {
        private readonly IRepoBooks _repo;

        public ManagerService(IRepoBooks repo, BooksDbContext context)
        {
            _repo = repo;
        }

        async Task<IEnumerable<Books>> IManagerService.GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }
        async Task<IEnumerable<Books>> IManagerService.FilterAsync(string? id, string? BookTitle, string? GenreName, string? FirstName, string? LastName)
        {
            return await _repo.FilterAsync(id, BookTitle, GenreName, FirstName, LastName);
        }

    }
}
