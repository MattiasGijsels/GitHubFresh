using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Labo.API.Contracts.Models;
using Labo.API.Contracts.Shared;
using Labo.API.Database.Context;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
        public async Task<List<Books>> GetAllAsync() =>
            await _context.Books
            .Include(book => book.Genre)
            .Include(book => book.Writer)
            .Where(book => !book.IsDeleted).ToListAsync();

        public async Task<bool> AddBookAsync(Books book)
        {
            #region
            //if (book == null)
            //{
            //    return false; // Or throw an exception
            //}

            //var existingBook = await _context.Books
            //    .Where(b => b.Id == book.Id).AsNoTracking().SingleOrDefaultAsync();//move to services

            //if (existingBook != null)
            //{
            //    // Book with the same GUID already exists
            //    return false;
            //}

            //// If the book's GUID is not set, generate a new one
            //if (string.IsNullOrWhiteSpace(book.Id))
            //{
            //    book.Id = Guid.NewGuid().ToString();
            //}

            //// Data Validation 
            //if (string.IsNullOrEmpty(book.BookTitle))
            //{
            //    // Handle missing BookTitle 
            //    throw new ArgumentException("BookTitle cannot be null or empty.");
            //}

            //// Ensure Genre data is set
            //if (!string.IsNullOrEmpty(book.Genre.GenreName))
            //{
            //    var existingGenre = await _context.Genre
            //        .FirstOrDefaultAsync(g => g.GenreName == book.Genre.GenreName);

            //    if (existingGenre != null)
            //    {
            //        book.Genre = existingGenre;
            //    }
            //    else
            //    {
            //        await _context.Genre.AddAsync(book.Genre);
            //    }
            //}
            //else
            //{
            //    book.Genre.GenreName = "Unknown";
            //}

            //// Checking Writer data is set
            //if (!string.IsNullOrEmpty(book.Writer.FirstName) && !string.IsNullOrEmpty(book.Writer.LastName))
            //{
            //    var existingWriter = await _context.Writers
            //        .FirstOrDefaultAsync(w => w.FirstName == book.Writer.FirstName && w.LastName == book.Writer.LastName);

            //    if (existingWriter != null)
            //    {
            //        book.Writer = existingWriter;
            //    }
            //    else
            //    {
            //        await _context.Writers.AddAsync(book.Writer);
            //    }
            //}
            //else
            //{
            //    book.Writer.FirstName = "Unknown";
            //    book.Writer.LastName = "Unknown";
            //}
            #endregion
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();

            return true;
        }

        //public async Task<bool> AddBookAsync(Books book)
        //{
        //    if (book == null)
        //    {
        //        return false; // Or throw an exception
        //    }

        //    // Data Validation 
        //    if (string.IsNullOrEmpty(book.BookTitle))
        //    {
        //        // Handle missing BookTitle (e.g., throw an exception)
        //        throw new ArgumentException("BookTitle cannot be null or empty.");
        //    }

        //    // Ensure Genre data is set
        //    if (string.IsNullOrEmpty(book.Genre.GenreName))
        //    {
        //        book.Genre.GenreName = "Unknown"; // Or handle appropriately
        //    }

        //    // Ensure Writer data is set
        //    if (string.IsNullOrEmpty(book.Writer.FirstName) || string.IsNullOrEmpty(book.Writer.LastName))
        //    {
        //        book.Writer.FirstName = "Unknown";
        //        book.Writer.LastName = "Unknown"; // Or handle appropriately
        //    }

        //    await _context.Books.AddAsync(book);
        //    await _context.SaveChangesAsync();

        //    return true;
        //}
        //public async Task<bool> AddBookAsync(Books book)
        //{
        //    if (book != null)
        //    {
        //        await _context.Books.AddAsync(book);
        //        await _context.SaveChangesAsync();
        //    }
        //    return true;
        //}

        // Soft delete a book
        public async Task<bool> DeleteBooksAsync(string id)
        {
            // Find the book by ID
            var book = await _context.Books.FindAsync(id);

            if (book == null || book.IsDeleted)
            {
                // Book not found or already soft-deleted
                return false;
            }

            // Mark the book as deleted
            book.IsDeleted = true;

            // Update the book in the database
            _context.Books.Update(book);
            return await _context.SaveChangesAsync() > 0;
        }

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
        //public async Task<List<Books>> FindBookAsync(string BookTitle)
        //{
        //    var query = _context.Books.AsQueryable();
        //    if (!string.IsNullOrEmpty(BookTitle))
        //    {
        //        query = query.Where(o => o.BookTitle.ToLower().Contains(BookTitle.ToLower()));
        //    }

        //    return await query.ToListAsync();

        //}
        public async Task<IEnumerable<Books>> FilterAsync(string? id, string? BookTitle, string? GenreName, string? FirstName, string? LastName)
        {
            var query = _context.Books
            .Include(book => book.Genre)
            .Include(book => book.Writer)
            .AsQueryable();

            if (!string.IsNullOrEmpty(id))
            {
                query = query.Where(o => o.Id == id);// takes into account local ex doppeltes S
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
        //public async Task<bool> UpsertAsync(Books book)//re-insert this one in the manager service
        //{
        //    //if (await AddBookAsync(book) == false)
        //    //{
        //    //    return await UpdateAsync(book);
        //    //}
        //    //return true;
        //}
        public async Task<bool> UpdateAsync(Books book)
        {
            if (await _context.Books.Where(d=>d.Id == book.Id).AsNoTracking().FirstOrDefaultAsync() != null)
            { 

                _context.Books.Update(book);
                return await _context.SaveChangesAsync()>0;
            }
            return false;
        }

        public async Task<IEnumerable<Books>> FindBookAsync(string data)
        {
            {
               var invariant = data.ToLower();
                var query = _context.Books
                    .Include(b => b.Genre)
                    .Include(b => b.Writer)
                    .AsQueryable();
                if (!string.IsNullOrEmpty(data))
                {
                    query = query.Where(o => o.BookTitle.ToLower().Contains(invariant)
                        ||o.Genre.GenreName.ToLower().Contains(invariant)
                        ||o.Writer.FirstName.ToLower().Contains(invariant)
                        ||o.Writer.LastName.ToLower().Contains(invariant)
                        ||o.Writer.LastName.ToLower().Contains(invariant)
                        ||o.Id.ToString() == data//add include for writer and genres
                    );
                }

                return await query.ToListAsync();

            }
        }

        public async Task<Books> GetByIdAsync(string bookId)
        {
            var book = 
             await _context.Books
                .Where(b => b.Id == bookId)
                .Include(b => b.Genre)
                .Include(b => b.Writer)
                .FirstOrDefaultAsync(b => b.Id == bookId);

            return book;
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
