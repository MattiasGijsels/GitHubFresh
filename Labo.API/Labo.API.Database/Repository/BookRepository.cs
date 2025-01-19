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
        // BooksDbContext injected through constructor
        private readonly BooksDbContext _context;

        public RepoBooks(BooksDbContext context)
        {
            _context = context;
        }

        // Get all non-deleted books
        public async Task<List<Books>> GetAllBooksAsync() =>
            await _context.Books.Where(book => !book.IsDeleted).ToListAsync();

        // Add a new book
        public async Task AddBookToDbAsync(Books book)
        {
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
        }

        // Soft delete a book
        public async Task DeleteBooksAsync(string titleBook)
        {
            var book = await _context.Books
                .FirstOrDefaultAsync(b => b.BookTitle.Equals(titleBook, StringComparison.OrdinalIgnoreCase));
            if (book != null)
            {
                book.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        // Modify a book
        public async Task ModifyBookAsync(string title)
        {
            var book = await _context.Books
                .FirstOrDefaultAsync(b => b.BookTitle.Equals(title, StringComparison.OrdinalIgnoreCase));
            if (book != null)
            {
                // Modify the book as needed
                book.BookTitle = title + " (Modified)";
                // Other modifications can be added here

                await _context.SaveChangesAsync();
            }
        }
        public async Task<List<Books>> FindBookAsync(string BookTitle)
        {
            var query = _context.Books.AsQueryable();
            if (!string.IsNullOrEmpty(BookTitle))
            {
                query = query.Where(o => o.BookTitle.ToLower().Contains(BookTitle.ToLower()));
            }

           return await query.ToListAsync();

        }
        public async Task<IEnumerable<Books>> FilterAsync(string? id, string? BookTitle, string? GenreName, string? FirstName, string? LastName) 
        {
            var query = _context.Books.AsQueryable();
            if (!string.IsNullOrEmpty(id))
            {
                query = query.Where(o => o.Id.ToLower().Contains(id.ToLower()));
            }
            if (!string.IsNullOrEmpty(BookTitle))
            {
                query = query.Where(o => o.BookTitle.ToLower().Contains(BookTitle.ToLower()));
            }
            if (!string.IsNullOrEmpty(GenreName)) 
            {
                query = query.Where(o => o.Genre.GenreName.ToLower().Contains(GenreName.ToLower()));
            }
            if (!string.IsNullOrEmpty(FirstName)) 
            {
                query = query.Where(o => o.Writer.FirstName.ToLower().Contains(FirstName.ToLower()));
            }
            if (!string.IsNullOrEmpty(LastName)) 
            {
                query = query.Where(o => o.Writer.LastName.ToLower().Contains(LastName.ToLower()));
            }

            return await query.ToListAsync();
        }
    }
}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using Microsoft.EntityFrameworkCore;
//using System.Threading.Tasks;
//using Labo.API.Contracts.Models;
//using Labo.API.Database.Context;


//namespace Examen.Advanced.Csharp.Database.Repositories
//{
//    public class RepoBooks : IRepoBooks
//    {
//        //private List<Books> _books;
//        BooksDbContext _context;

//        public RepoBooks(BooksDbContext books)
//        {
//            _context = books;
//        }

//        // Get all non-deleted books
//        public async Task<List<Books>> GetAllBooksAsync()=> await _context.Books.Where(book => !book.IsDeleted).ToListAsync();

//                // Add a new book
//        public Task AddBookToDbAsync(Books book)
//        {
//            _context.Add(book);
//            return Task.CompletedTask;
//        }

//        // Soft delete a book
//        public Task DeleteBooksAsync(string titleBook)
//        {
//            var book = _context.FirstOrDefault(b => b.BookTitle.Equals(titleBook, StringComparison.OrdinalIgnoreCase));
//            if (book != null)
//            {
//                book.IsDeleted = true;
//            }
//            return Task.CompletedTask;
//        }

//        // Modify a book
//        public Task ModifyBookAsync(string title)
//        {
//            var book = _context.FirstOrDefault(b => b.BookTitle.Equals(title, StringComparison.OrdinalIgnoreCase));
//            if (book != null)
//            {
//                // Modify the book as needed, for example:
//                book.BookTitle = title + " (Modified)";
//                // Other modifications can be added here
//            }
//            return Task.CompletedTask;
//        }
//    }
//}
