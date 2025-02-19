using Labo.API.Contracts.Models;

namespace Labo.API.Wasm.Shared
{
    public interface IManagerService
    {
        Task<IEnumerable<Books>> GetAllAsync();
        Task<IEnumerable<Books>> FilterAsync(string? id = null, string? BookTitle = null, string? GenreName = null, string? FirstName = null, string? LastName = null);
        Task<IEnumerable<Books>> FindAsync(string data);
        Task<Books?> GetByIdAsync(string bookId);
        Task UpdateAsync(Books book);
    }
}
