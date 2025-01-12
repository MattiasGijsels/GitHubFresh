using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Labo.API.Contracts.Models;

namespace Examen.Advanced.Csharp.Database.Repositories
{
    public class RepoBooks : IRepoBooks
    {
        private List<Books> _books;

        public RepoBooks()
        {
            _books = new List<Books>();
        }

        // Get all non-deleted books
        public Task<List<Books>> GetAllBooksAsync()
        {
            var nonDeletedBooks = _books.Where(book => !book.IsDeleted).ToList();
            return Task.FromResult(nonDeletedBooks);
        }

        // Add a new book
        public Task AddBookToDbAsync(Books book)
        {
            _books.Add(book);
            return Task.CompletedTask;
        }

        // Soft delete a book
        public Task DeleteBooksAsync(string titleBook)
        {
            var book = _books.FirstOrDefault(b => b.BookTitle.Equals(titleBook, StringComparison.OrdinalIgnoreCase));
            if (book != null)
            {
                book.IsDeleted = true;
            }
            return Task.CompletedTask;
        }

        // Modify a book
        public Task ModifyBookAsync(string title)
        {
            var book = _books.FirstOrDefault(b => b.BookTitle.Equals(title, StringComparison.OrdinalIgnoreCase));
            if (book != null)
            {
                // Modify the book as needed, for example:
                book.BookTitle = title + " (Modified)";
                // Other modifications can be added here
            }
            return Task.CompletedTask;
        }
    }
}
