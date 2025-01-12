using System;
using System.Collections.Generic;
using System.Linq;
using Labo.API.Contracts.Models;
using Labo.API.Database.Context;

namespace Labo.API.Database.DbSeeder
{
    public class DbSeeder
    {
        public static void SeedDummyData(BooksDbContext dbContext)
        {
            List<Genre> literaryGenres;
            List<Writers> writerList;

            if (!dbContext.Genre.Any())
            {
                literaryGenres = new List<Genre>
                {
                    new Genre { GenreName = "Fantasy" },
                    new Genre { GenreName = "Science Fiction" },
                    new Genre { GenreName = "Mystery" },
                    new Genre { GenreName = "Thriller" },
                    new Genre { GenreName = "Romance" },
                    new Genre { GenreName = "Horror" },
                    new Genre { GenreName = "Historical Fiction" },
                    new Genre { GenreName = "Dystopian" },
                    new Genre { GenreName = "Adventure" },
                    new Genre { GenreName = "Memoir" },
                    new Genre { GenreName = "Biography" },
                    new Genre { GenreName = "Classic" },
                    new Genre { GenreName = "Contemporary" },
                    new Genre { GenreName = "Literary Fiction" },
                    new Genre { GenreName = "Magical Realism" },
                    new Genre { GenreName = "Graphic Novel" },
                    new Genre { GenreName = "Young Adult" },
                    new Genre { GenreName = "Children's Literature" }
                };

                dbContext.Genre.AddRange(literaryGenres);
                dbContext.SaveChanges();
            }
            else
            {
                literaryGenres = dbContext.Genre.ToList();
            }

            if (!dbContext.Writers.Any())
            {
                writerList = new List<Writers>
                {
                    new Writers { FirstName = "J.R.R.", LastName = "Tolkien" },
                    new Writers { FirstName = "J.K.", LastName = "Rowling" },
                    new Writers { FirstName = "George", LastName = "Orwell" },
                    new Writers { FirstName = "Agatha", LastName = "Christie" },
                    new Writers { FirstName = "Stephen", LastName = "King" },
                    new Writers { FirstName = "Jane", LastName = "Austen" },
                    new Writers { FirstName = "F. Scott", LastName = "Fitzgerald" },
                    new Writers { FirstName = "Mark", LastName = "Twain" },
                    new Writers { FirstName = "Charles", LastName = "Dickens" },
                    new Writers { FirstName = "Leo", LastName = "Tolstoy" },
                    new Writers { FirstName = "Ernest", LastName = "Hemingway" },
                    new Writers { FirstName = "William", LastName = "Shakespeare" },
                    new Writers { FirstName = "Isaac", LastName = "Asimov" },
                    new Writers { FirstName = "Arthur", LastName = "Conan Doyle" },
                    new Writers { FirstName = "H.G.", LastName = "Wells" },
                    new Writers { FirstName = "Edgar Allan", LastName = "Poe" },
                    new Writers { FirstName = "Gabriel García", LastName = "Márquez" },
                    new Writers { FirstName = "J.D.", LastName = "Salinger" },
                    new Writers { FirstName = "Virginia", LastName = "Woolf" },
                    new Writers { FirstName = "Herman", LastName = "Melville" }
                };

                dbContext.Writers.AddRange(writerList);
                dbContext.SaveChanges();
            }
            else
            {
                writerList = dbContext.Writers.ToList();
            }

            if (!dbContext.Books.Any())
            {
                var random = new Random();
                var books = new List<Books>();

                for (int i = 1; i <= 30; i++)
                {
                    var genre = literaryGenres[random.Next(literaryGenres.Count)];
                    var writer = writerList[random.Next(writerList.Count)];
                    var bookTitle = $"Book Title {i}";
                    var pageCount = random.Next(100, 1000);

                    books.Add(new Books
                    {
                        BookTitle = bookTitle,
                        PageCount = pageCount,
                        Genre = genre,
                        Writer = writer
                    });
                }

                dbContext.Books.AddRange(books);
                dbContext.SaveChanges();
            }
        }
    }
}
