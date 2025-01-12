using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Labo.API.Contracts.Models;

namespace Examen.Advanced.Csharp.Database.Repositories
{
    public interface IRepoBooks
    {
        Task<List<Books>> GetAllBooksAsync();        // Get all non-deleted books
        Task AddBookToDbAsync(Books book);         // Add a new book
        Task DeleteBooksAsync(string titleBook);      // Soft delete a book
        Task ModifyBookAsync(string title);            //modify a book
    }
}