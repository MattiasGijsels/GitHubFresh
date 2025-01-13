using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Labo.API.Contracts.Models;
using Labo.API.Database.Context;


namespace Examen.Advanced.Csharp.Database.Repositories
{
    public class RepoBooks : IRepoBooks
    {
        //private List<Books> _books;
        BooksDbContext _context;

        public RepoBooks(BooksDbContext books)
        {
            _context = books;
        }

        // Get all non-deleted books
        public async Task<List<Books>> GetAllBooksAsync()=> await _context.Books.Where(book => !book.IsDeleted).ToListAsync();
            
                // Add a new book
        public Task AddBookToDbAsync(Books book)
        {
            _context.Add(book);
            return Task.CompletedTask;
        }

        // Soft delete a book
        public Task DeleteBooksAsync(string titleBook)
        {
            var book = _context.FirstOrDefault(b => b.BookTitle.Equals(titleBook, StringComparison.OrdinalIgnoreCase));
            if (book != null)
            {
                book.IsDeleted = true;
            }
            return Task.CompletedTask;
        }

        // Modify a book
        public Task ModifyBookAsync(string title)
        {
            var book = _context.FirstOrDefault(b => b.BookTitle.Equals(title, StringComparison.OrdinalIgnoreCase));
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
