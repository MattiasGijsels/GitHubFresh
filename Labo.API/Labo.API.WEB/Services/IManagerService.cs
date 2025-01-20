using Labo.API.Contracts.Models;

namespace Labo.API.WEB.Services
{
    public interface IManagerService
    {
        Task<bool> AddBookAsync(Books book);
        Task<bool> UpdateAsync(Books book);
        Task<bool> UpsertAsync(Books book);
        Task<bool> DeleteAsync(string id);
        Task<Books?> GetByIdAsync(string id);
        Task<IEnumerable<Books>> GetAllAsync();
        Task<IEnumerable<Books>> FindBookAsync(string BookTitle);
        Task<IEnumerable<Books>> FilterAsync(string? id = null, string? BookTitle = null, string? GenreName = null, string? FirstName = null, string? LastName = null);

    }
}
