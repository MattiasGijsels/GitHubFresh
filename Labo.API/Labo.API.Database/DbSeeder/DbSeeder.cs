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
            if (!dbContext.Books.Any()) // Checks if data already exists
            {
                var books = new List<Books>
                {
                    new Books { BookTitle = "The Lord of the Rings", NumberPages = 1178, Genre = new Genre { GenreName = "High Fantasy" }, Writer = new Writers { FirstName = "J.R.R", LastName = "Tolkien" } },
                    new Books { BookTitle = "The Hobbit", NumberPages = 310, Genre = new Genre { GenreName = "Fantasy" }, Writer = new Writers { FirstName = "J.R.R", LastName = "Tolkien" } },
                    new Books { BookTitle = "Harry Potter and the Sorcerer's Stone", NumberPages = 309, Genre = new Genre { GenreName = "Fantasy" }, Writer = new Writers { FirstName = "J.K", LastName = "Rowling" } },
                    new Books { BookTitle = "The Great Gatsby", NumberPages = 180, Genre = new Genre { GenreName = "Classic" }, Writer = new Writers { FirstName = "F. Scott", LastName = "Fitzgerald" } },
                    new Books { BookTitle = "1984", NumberPages = 328, Genre = new Genre { GenreName = "Dystopian" }, Writer = new Writers { FirstName = "George", LastName = "Orwell" } },
                    new Books { BookTitle = "Pride and Prejudice", NumberPages = 279, Genre = new Genre { GenreName = "Romance" }, Writer = new Writers { FirstName = "Jane", LastName = "Austen" } },
                    new Books { BookTitle = "To Kill a Mockingbird", NumberPages = 281, Genre = new Genre { GenreName = "Classic" }, Writer = new Writers { FirstName = "Harper", LastName = "Lee" } },
                    new Books { BookTitle = "Moby-Dick", NumberPages = 635, Genre = new Genre { GenreName = "Adventure" }, Writer = new Writers { FirstName = "Herman", LastName = "Melville" } },
                    new Books { BookTitle = "The Catcher in the Rye", NumberPages = 277, Genre = new Genre { GenreName = "Classic" }, Writer = new Writers { FirstName = "J.D.", LastName = "Salinger" } },
                    new Books { BookTitle = "The Chronicles of Narnia", NumberPages = 767, Genre = new Genre { GenreName = "Fantasy" }, Writer = new Writers { FirstName = "C.S.", LastName = "Lewis" } },
                    new Books { BookTitle = "War and Peace", NumberPages = 1225, Genre = new Genre { GenreName = "Historical" }, Writer = new Writers { FirstName = "Leo", LastName = "Tolstoy" } },
                    new Books { BookTitle = "The Odyssey", NumberPages = 541, Genre = new Genre { GenreName = "Epic" }, Writer = new Writers { FirstName = "Homer", LastName = "" } },
                    new Books { BookTitle = "The Iliad", NumberPages = 683, Genre = new Genre { GenreName = "Epic" }, Writer = new Writers { FirstName = "Homer", LastName = "" } },
                    new Books { BookTitle = "Crime and Punishment", NumberPages = 671, Genre = new Genre { GenreName = "Psychological" }, Writer = new Writers { FirstName = "Fyodor", LastName = "Dostoevsky" } },
                    new Books { BookTitle = "The Brothers Karamazov", NumberPages = 824, Genre = new Genre { GenreName = "Philosophical" }, Writer = new Writers { FirstName = "Fyodor", LastName = "Dostoevsky" } },
                    new Books { BookTitle = "Anna Karenina", NumberPages = 864, Genre = new Genre { GenreName = "Drama" }, Writer = new Writers { FirstName = "Leo", LastName = "Tolstoy" } },
                    new Books { BookTitle = "Jane Eyre", NumberPages = 507, Genre = new Genre { GenreName = "Romance" }, Writer = new Writers { FirstName = "Charlotte", LastName = "Brontë" } },
                    new Books { BookTitle = "Wuthering Heights", NumberPages = 416, Genre = new Genre { GenreName = "Gothic" }, Writer = new Writers { FirstName = "Emily", LastName = "Brontë" } },
                    new Books { BookTitle = "The Picture of Dorian Gray", NumberPages = 254, Genre = new Genre { GenreName = "Philosophical" }, Writer = new Writers { FirstName = "Oscar", LastName = "Wilde" } },
                    new Books { BookTitle = "Brave New World", NumberPages = 311, Genre = new Genre { GenreName = "Dystopian" }, Writer = new Writers { FirstName = "Aldous", LastName = "Huxley" } },
                    new Books { BookTitle = "Fahrenheit 451", NumberPages = 194, Genre = new Genre { GenreName = "Dystopian" }, Writer = new Writers { FirstName = "Ray", LastName = "Bradbury" } },
                    new Books { BookTitle = "Don Quixote", NumberPages = 992, Genre = new Genre { GenreName = "Classic" }, Writer = new Writers { FirstName = "Miguel", LastName = "de Cervantes" } },
                    new Books { BookTitle = "The Divine Comedy", NumberPages = 798, Genre = new Genre { GenreName = "Epic" }, Writer = new Writers { FirstName = "Dante", LastName = "Alighieri" } },
                    new Books { BookTitle = "The Canterbury Tales", NumberPages = 704, Genre = new Genre { GenreName = "Classic" }, Writer = new Writers { FirstName = "Geoffrey", LastName = "Chaucer" } },
                    new Books { BookTitle = "Les Misérables", NumberPages = 1232, Genre = new Genre { GenreName = "Historical" }, Writer = new Writers { FirstName = "Victor", LastName = "Hugo" } },
                    new Books { BookTitle = "The Count of Monte Cristo", NumberPages = 1276, Genre = new Genre { GenreName = "Adventure" }, Writer = new Writers { FirstName = "Alexandre", LastName = "Dumas" } },
                    new Books { BookTitle = "The Three Musketeers", NumberPages = 700, Genre = new Genre { GenreName = "Adventure" }, Writer = new Writers { FirstName = "Alexandre", LastName = "Dumas" } },
                    new Books { BookTitle = "Dracula", NumberPages = 418, Genre = new Genre { GenreName = "Gothic" }, Writer = new Writers { FirstName = "Bram", LastName = "Stoker" } },
                    new Books { BookTitle = "Frankenstein", NumberPages = 280, Genre = new Genre { GenreName = "Gothic" }, Writer = new Writers { FirstName = "Mary", LastName = "Shelley" } },
                    new Books { BookTitle = "A Tale of Two Cities", NumberPages = 448, Genre = new Genre { GenreName = "Historical" }, Writer = new Writers { FirstName = "Charles", LastName = "Dickens" } },
                    new Books { BookTitle = "Great Expectations", NumberPages = 505, Genre = new Genre { GenreName = "Classic" }, Writer = new Writers { FirstName = "Charles", LastName = "Dickens" } },
                    new Books { BookTitle = "Oliver Twist", NumberPages = 363, Genre = new Genre { GenreName = "Classic" }, Writer = new Writers { FirstName = "Charles", LastName = "Dickens" } },
                    new Books { BookTitle = "David Copperfield", NumberPages = 624, Genre = new Genre { GenreName = "Classic" }, Writer = new Writers { FirstName = "Charles", LastName = "Dickens" } },
                    new Books { BookTitle = "Bleak House", NumberPages = 928, Genre = new Genre { GenreName = "Classic" }, Writer = new Writers { FirstName = "Charles", LastName = "Dickens" } },
                    new Books { BookTitle = "Middlemarch", NumberPages = 880, Genre = new Genre { GenreName = "Classic" }, Writer = new Writers { FirstName = "George", LastName = "Eliot" } },
                    new Books { BookTitle = "Silas Marner", NumberPages = 240, Genre = new Genre { GenreName = "Classic" }, Writer = new Writers { FirstName = "George", LastName = "Eliot" } },
                    new Books { BookTitle = "Madame Bovary", NumberPages = 329, Genre = new Genre { GenreName = "Classic" }, Writer = new Writers { FirstName = "Gustave", LastName = "Flaubert" } },
                    new Books { BookTitle = "The Stranger", NumberPages = 123, Genre = new Genre { GenreName = "Philosophical" }, Writer = new Writers { FirstName = "Albert", LastName = "Camus" } },
                    new Books { BookTitle = "The Plague", NumberPages = 308, Genre = new Genre { GenreName = "Philosophical" }, Writer = new Writers { FirstName = "Albert", LastName = "Camus" } },
                    new Books { BookTitle = "One Hundred Years of Solitude", NumberPages = 417, Genre = new Genre { GenreName = "Magical Realism" }, Writer = new Writers { FirstName = "Gabriel", LastName = "García Márquez" } },
                    new Books { BookTitle = "Love in the Time of Cholera", NumberPages = 348, Genre = new Genre { GenreName = "Romance" }, Writer = new Writers { FirstName = "Gabriel", LastName = "García Márquez" } },
                    new Books { BookTitle = "The Sound and the Fury", NumberPages = 326, Genre = new Genre { GenreName = "Classic" }, Writer = new Writers { FirstName = "William", LastName = "Faulkner" } },
                    new Books { BookTitle = "As I Lay Dying", NumberPages = 267, Genre = new Genre { GenreName = "Classic" }, Writer = new Writers { FirstName = "William", LastName = "Faulkner" } },
                    new Books { BookTitle = "The Sun Also Rises", NumberPages = 251, Genre = new Genre { GenreName = "Classic" }, Writer = new Writers { FirstName = "Ernest", LastName = "Hemingway" } },
                    new Books { BookTitle = "For Whom the Bell Tolls", NumberPages = 471, Genre = new Genre { GenreName = "Classic" }, Writer = new Writers { FirstName = "Ernest", LastName = "Hemingway" } }
                };

                dbContext.Books.AddRange(books);
                dbContext.SaveChanges();
            }
        }
    }
}
