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
            Repo= repo;
        }



        Task<bool> IManagerService.CreateAsync(Books book)
        {
            throw new NotImplementedException();
        }

        Task<bool> IManagerService.DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Books>> IManagerService.FilterAsync(string? id, string? BookTitle, string? GenreName, string? FirstName, string? LastName)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Books>> IManagerService.FindBookAsync(string BookTitle)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Books>> IManagerService.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        Task<Books?> IManagerService.GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        Task<bool> IManagerService.UpdateAsync(Books book)
        {
            throw new NotImplementedException();
        }

        Task<bool> IManagerService.UpsertAsync(Books book)
        {
            throw new NotImplementedException();
        }
    }
}
