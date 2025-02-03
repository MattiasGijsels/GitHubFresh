﻿using Labo.API.Wasm.Shared;
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
        //async Task<IEnumerable<Books>> IManagerService.FilterAsync(string? id, string? BookTitle, string? GenreName, string? FirstName, string? LastName)
        //{
        //    return await Http.GetFromJsonAsync<IEnumerable<Books>>(id, BookTitle, GenreName, FirstName, LastName) ?? [];
        //}//how tf do I get this to work
        async Task<IEnumerable<Books>> IManagerService.FilterAsync(string? id, string? BookTitle, string? GenreName, string? FirstName, string? LastName)
      {
            var uriBuilder = new UriBuilder("api/Book"); // Replace with your API base URL

            if (!string.IsNullOrEmpty(id))
            {
                uriBuilder.AddQueryParameter("id", id);
            }
            if (!string.IsNullOrEmpty(BookTitle))
            {
                uriBuilder.AddQueryParameter("bookTitle", BookTitle); // Use camelCase or your API's naming convention
            }
            if (!string.IsNullOrEmpty(GenreName))
            {
                uriBuilder.AddQueryParameter("genreName", GenreName); // Use camelCase or your API's naming convention
            }
            if (!string.IsNullOrEmpty(FirstName))
            {
                uriBuilder.AddQueryParameter("firstName", FirstName); // Use camelCase or your API's naming convention
            }
            if (!string.IsNullOrEmpty(LastName))
            {
                uriBuilder.AddQueryParameter("lastName", LastName); // Use camelCase or your API's naming convention
            }

            string url = uriBuilder.ToString();  // Get the constructed URL

            try
            {
                return await Http.GetFromJsonAsync<IEnumerable<Books>>(url) ?? [];
            }
            catch (HttpRequestException ex)
            {
                // Handle exceptions (e.g., log, display error message)
                Console.WriteLine($"Error: {ex.Message}");
                return []; // Or throw the exception if appropriate
            }
        }

        // Helper extension method (add to a suitable class)
    }
    public static class UriExtensions
    {
        public static void AddQueryParameter(this UriBuilder builder, string name, string value)
        {
            if (string.IsNullOrEmpty(value)) return; // Don't add empty parameters

            var query = System.Web.HttpUtility.ParseQueryString(builder.Query);
            query[name] = value;
            builder.Query = query.ToString();
        }
    }
}
