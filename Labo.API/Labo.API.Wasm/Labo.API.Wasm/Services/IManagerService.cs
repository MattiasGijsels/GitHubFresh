using Labo.API.Contracts.Models;

namespace Labo.API.Wasm.Services
{
    public interface IManagerService
    {
        Task<IEnumerable<Books>> GetAllAsync();
    }
}
