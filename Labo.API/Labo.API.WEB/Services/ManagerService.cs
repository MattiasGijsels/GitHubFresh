using Labo.API.Database;
using Labo.API.Contracts.Models;
using Labo.API.Database.Context;
using Labo.API.WEB.Services;
using Examen.Advanced.Csharp.Database.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Labo.API.WEB.Services
{
    public class ManagerService : IManagerService
    {
        private readonly IRepoBooks _repo;
        private readonly BooksDbContext _context;

        public ManagerService(IRepoBooks repo, BooksDbContext context)
        {
            _repo = repo;
            _context = context;
        }

        public async Task<Books?> AddBookAsync(Books book)
        {
            #region
            //var existingBook = await _context.Books
            //    .Where(b => b.Id == book.Id).AsNoTracking().SingleOrDefaultAsync();

            //if (existingBook != null)
            //{
            //    return false;
            //}

            //if (string.IsNullOrWhiteSpace(book.Id))
            //{
            //    book.Id = Guid.NewGuid().ToString();
            //}

            //if (string.IsNullOrEmpty(book.BookTitle))
            //{
            //    throw new ArgumentException("BookTitle cannot be null or empty.");
            //}

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
            //bool StateBook = await BookExists(book);
            if (!await BookExists(book))//! means book doesn't exist
            {
                await _repo.AddBookAsync(book);
                return book;
            }
            return null;
        }

        async Task<IEnumerable<Books>> IManagerService.FilterAsync(string? id, string? BookTitle, string? GenreName, string? FirstName, string? LastName)
        {
            return await _repo.FilterAsync(id, BookTitle, GenreName, FirstName, LastName);
        }

        async Task<IEnumerable<Books>> IManagerService.FindBookAsync(string BookTitle)
        {
            return await _repo.FindBookAsync(BookTitle);
        }

        async Task<IEnumerable<Books>> IManagerService.GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }

        Task<Books?> IManagerService.GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        async Task<Books> IManagerService.UpdateAsync(Books book)
        {
            await _repo.UpdateAsync(book);//returntypes nullable and if statement for returned values 
            return book;
        }

        async Task<Books> IManagerService.UpsertAsync(Books book)
        {
            //await AddBookAsync(book);// How do I get this one into AddBookAsync from the service
            //return await _repo.UpsertAsync(book);
            if (await BookExists(book))
            {
                await _repo.UpdateAsync(book);
                return book;
            }
            else
            {
                await _repo.AddBookAsync(book);
                return book;
            }
            
        }
        async Task<bool> IManagerService.DeleteAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentException("Book ID cannot be null or empty.");
            }

            var success = await _repo.DeleteBooksAsync(id);

            if (!success)
            {
                // Return false if the book was not found or couldn't be soft-deleted
                return false;
            }

            // Return true if the deletion was successful
            return true;
        }

        async Task<bool> BookExists(Books book)
        {
            var existingBook = await _context.Books
               .Where(b => b.Id == book.Id).AsNoTracking().SingleOrDefaultAsync();

            if (existingBook != null)
            {
                return true;
            }

            if (string.IsNullOrWhiteSpace(book.Id))
            {
                book.Id = Guid.NewGuid().ToString();
            }

            if (string.IsNullOrEmpty(book.BookTitle))
            {
                throw new ArgumentException("BookTitle cannot be null or empty.");
            }

            if (!string.IsNullOrEmpty(book.Genre.GenreName))
            {
                var existingGenre = await _context.Genre
                    .FirstOrDefaultAsync(g => g.GenreName == book.Genre.GenreName);

                if (existingGenre != null)
                {
                    book.Genre = existingGenre;
                }
                else
                {
                    await _context.Genre.AddAsync(book.Genre);
                }
            }
            else
            {
                book.Genre.GenreName = "Unknown";
            }

            if (!string.IsNullOrEmpty(book.Writer.FirstName) && !string.IsNullOrEmpty(book.Writer.LastName))
            {
                var existingWriter = await _context.Writers
                    .FirstOrDefaultAsync(w => w.FirstName == book.Writer.FirstName && w.LastName == book.Writer.LastName);

                if (existingWriter != null)
                {
                    book.Writer = existingWriter;
                }
                else
                {
                    await _context.Writers.AddAsync(book.Writer);
                }
            }
            else
            {
                book.Writer.FirstName = "Unknown";
                book.Writer.LastName = "Unknown";
            }
            return false;
        }
    }
}
//using Labo.API.Database;
//using Labo.API.Contracts.Models;
//using Labo.API.Database.Context;
//using Labo.API.WEB.Services;
//using Examen.Advanced.Csharp.Database.Repositories;
//using Microsoft.EntityFrameworkCore;

//namespace Labo.API.WEB.Services
//{
//    public class ManagerService : IManagerService
//    {
//        private readonly IRepoBooks _repo;
//        private readonly BooksDbContext _context;

//        public ManagerService(IRepoBooks repo, BooksDbContext context)
//        {
//            _repo = repo;
//            _context = context;
//        }

//        public async Task<bool> AddBookAsync(Books book)
//        {
//            var existingBook = await _context.Books
//                .Where(b => b.Id == book.Id).AsNoTracking().SingleOrDefaultAsync();

//            if (existingBook != null)
//            {
//                return false;
//            }

//            if (string.IsNullOrWhiteSpace(book.Id))
//            {
//                book.Id = Guid.NewGuid().ToString();
//            }

//            if (string.IsNullOrEmpty(book.BookTitle))
//            {
//                throw new ArgumentException("BookTitle cannot be null or empty.");
//            }

//            if (!string.IsNullOrEmpty(book.Genre.GenreName))
//            {
//                var existingGenre = await _context.Genre
//                    .FirstOrDefaultAsync(g => g.GenreName == book.Genre.GenreName);

//                if (existingGenre != null)
//                {
//                    book.Genre = existingGenre;
//                }
//                else
//                {
//                    await _context.Genre.AddAsync(book.Genre);
//                }
//            }
//            else
//            {
//                book.Genre.GenreName = "Unknown";
//            }

//            if (!string.IsNullOrEmpty(book.Writer.FirstName) && !string.IsNullOrEmpty(book.Writer.LastName))
//            {
//                var existingWriter = await _context.Writers
//                    .FirstOrDefaultAsync(w => w.FirstName == book.Writer.FirstName && w.LastName == book.Writer.LastName);

//                if (existingWriter != null)
//                {
//                    book.Writer = existingWriter;
//                }
//                else
//                {
//                    await _context.Writers.AddAsync(book.Writer);
//                }
//            }
//            else
//            {
//                book.Writer.FirstName = "Unknown";
//                book.Writer.LastName = "Unknown";
//            }

//            await _repo.AddBookAsync(book);
//            return true;
//        }

//        public Task<bool> DeleteAsync(string id) => _repo.DeleteBooksAsync(id);

//        public Task<IEnumerable<Books>> FilterAsync(string? id, string? BookTitle, string? GenreName, string? FirstName, string? LastName)
//            => _repo.FilterAsync(id, BookTitle, GenreName, FirstName, LastName);

//        public Task<IEnumerable<Books>> FindBookAsync(string BookTitle)
//            => _repo.FindBookAsync(BookTitle);

//        public Task<IEnumerable<Books>> GetAllAsync()
//            => _repo.GetAllAsync();

//        public Task<Books?> GetByIdAsync(string id)
//            => throw new NotImplementedException();

//        public Task<bool> UpdateAsync(Books book)
//            => _repo.UpdateAsync(book);

//        public Task<bool> UpsertAsync(Books book)
//            => _repo.UpsertAsync(book);
//    }
//}
