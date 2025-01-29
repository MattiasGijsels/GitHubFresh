using Labo.API.Wasm.Shared;
using Labo.API.Contracts.Models;
using System.Net.Http.Json;

namespace Labo.API.Wasm.Client.Services
{
    public class BookClientService: IManagerService
    {
        HttpClient Http { get; init; } = default!;
        public BookClientService(HttpClient http)
        {
            Http = http;
        }
        async Task<IEnumerable<Books>> IManagerService.GetAllAsync()
        {
            return await Http.GetFromJsonAsync<IEnumerable<Books>>("api/Book")??[];
        }
        async Task<IEnumerable<Books>> IManagerService.FilterAsync(string? id, string? BookTitle, string? GenreName, string? FirstName, string? LastName)
        {
            return await Http.GetFromJsonAsync<IEnumerable<Books>>(id, BookTitle, GenreName, FirstName, LastName) ?? [];
        }//how tf do I get this to work
    }
}
