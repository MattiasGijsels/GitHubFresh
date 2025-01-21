using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Labo.API.Contracts.Models;

namespace Examen.Advanced.Csharp.Database.Repositories
{
    public interface IRepoBooks
    {
        Task<List<Books>> GetAllAsync();        // Get all non-deleted books
        Task<bool> AddBookAsync(Books book);         // Add a new book
        Task<bool> UpdateAsync(Books book);
        //Task<bool> UpsertAsync(Books book);          // Upsert a new book
        Task<List<Books>> FindBookAsync(string BookTitle);
        Task<IEnumerable<Books>> FilterAsync(string? id, string? BookTitle, string? GenreName, string? FirstName, string? LastName);
        Task <bool> DeleteBooksAsync(string id);      // Soft delete a book
        Task ModifyBookAsync(string title);            //modify a book
    }
}