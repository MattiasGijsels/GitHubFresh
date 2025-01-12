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
                    new Books { BookTitle = "The Lord of the Rings", PageCount = 1178, Genre = new Genre { GenreName = "High Fantasy" }, Writer = new Writers { FirstName = "J.R.R", LastName = "Tolkien" } },
                    new Books { BookTitle = "The Hobbit", PageCount = 310, Genre = new Genre { GenreName = "Fantasy" }, Writer = new Writers { FirstName = "J.R.R", LastName = "Tolkien" } },
                    new Books { BookTitle = "Harry Potter and the Sorcerer's Stone", PageCount = 309, Genre = new Genre { GenreName = "Fantasy" }, Writer = new Writers { FirstName = "J.K", LastName = "Rowling" } },
                    new Books { BookTitle = "The Great Gatsby", PageCount = 180, Genre = new Genre { GenreName = "Classic" }, Writer = new Writers { FirstName = "F. Scott", LastName = "Fitzgerald" } },
                    new Books { BookTitle = "1984", PageCount = 328, Genre = new Genre { GenreName = "Dystopian" }, Writer = new Writers { FirstName = "George", LastName = "Orwell" } },
                    new Books { BookTitle = "Pride and Prejudice", PageCount = 279, Genre = new Genre { GenreName = "Romance" }, Writer = new Writers { FirstName = "Jane", LastName = "Austen" } },
                    new Books { BookTitle = "To Kill a Mockingbird", PageCount = 281, Genre = new Genre { GenreName = "Classic" }, Writer = new Writers { FirstName = "Harper", LastName = "Lee" } },
                    new Books { BookTitle = "Moby-Dick", PageCount = 635, Genre = new Genre { GenreName = "Adventure" }, Writer = new Writers { FirstName = "Herman", LastName = "Melville" } },
                    new Books { BookTitle = "The Catcher in the Rye", PageCount = 277, Genre = new Genre { GenreName = "Classic" }, Writer = new Writers { FirstName = "J.D.", LastName = "Salinger" } },
                    new Books { BookTitle = "The Chronicles of Narnia", PageCount = 767, Genre = new Genre { GenreName = "Fantasy" }, Writer = new Writers { FirstName = "C.S.", LastName = "Lewis" } },
                    new Books { BookTitle = "War and Peace", PageCount = 1225, Genre = new Genre { GenreName = "Historical" }, Writer = new Writers { FirstName = "Leo", LastName = "Tolstoy" } },
                    new Books { BookTitle = "The Odyssey", PageCount = 541, Genre = new Genre { GenreName = "Epic" }, Writer = new Writers { FirstName = "Homer", LastName = "" } },
                    new Books { BookTitle = "The Iliad", PageCount = 683, Genre = new Genre { GenreName = "Epic" }, Writer = new Writers { FirstName = "Homer", LastName = "" } },
                    new Books { BookTitle = "Crime and Punishment", PageCount = 671, Genre = new Genre { GenreName = "Psychological" }, Writer = new Writers { FirstName = "Fyodor", LastName = "Dostoevsky" } },
                    new Books { BookTitle = "The Brothers Karamazov", PageCount = 824, Genre = new Genre { GenreName = "Philosophical" }, Writer = new Writers { FirstName = "Fyodor", LastName = "Dostoevsky" } },
                    new Books { BookTitle = "Anna Karenina", PageCount = 864, Genre = new Genre { GenreName = "Drama" }, Writer = new Writers { FirstName = "Leo", LastName = "Tolstoy" } },
                    new Books { BookTitle = "Jane Eyre", PageCount = 507, Genre = new Genre { GenreName = "Romance" }, Writer = new Writers { FirstName = "Charlotte", LastName = "Brontë" } },
                    new Books { BookTitle = "Wuthering Heights", PageCount = 416, Genre = new Genre { GenreName = "Gothic" }, Writer = new Writers { FirstName = "Emily", LastName = "Brontë" } },
                    new Books { BookTitle = "The Picture of Dorian Gray", PageCount = 254, Genre = new Genre { GenreName = "Philosophical" }, Writer = new Writers { FirstName = "Oscar", LastName = "Wilde" } },
                    new Books { BookTitle = "Brave New World", PageCount = 311, Genre = new Genre { GenreName = "Dystopian" }, Writer = new Writers { FirstName = "Aldous", LastName = "Huxley" } },
                    new Books { BookTitle = "Fahrenheit 451", PageCount = 194, Genre = new Genre { GenreName = "Dystopian" }, Writer = new Writers { FirstName = "Ray", LastName = "Bradbury" } },
                    new Books { BookTitle = "Don Quixote", PageCount = 992, Genre = new Genre { GenreName = "Classic" }, Writer = new Writers { FirstName = "Miguel", LastName = "de Cervantes" } },
                    new Books { BookTitle = "The Divine Comedy", PageCount = 798, Genre = new Genre { GenreName = "Epic" }, Writer = new Writers { FirstName = "Dante", LastName = "Alighieri" } },
                    new Books { BookTitle = "The Canterbury Tales", PageCount = 704, Genre = new Genre { GenreName = "Classic" }, Writer = new Writers { FirstName = "Geoffrey", LastName = "Chaucer" } },
                    new Books { BookTitle = "Les Misérables", PageCount = 1232, Genre = new Genre { GenreName = "Historical" }, Writer = new Writers { FirstName = "Victor", LastName = "Hugo" } },
                    new Books { BookTitle = "The Count of Monte Cristo", PageCount = 1276, Genre = new Genre { GenreName = "Adventure" }, Writer = new Writers { FirstName = "Alexandre", LastName = "Dumas" } },
                    new Books { BookTitle = "The Three Musketeers", PageCount = 700, Genre = new Genre { GenreName = "Adventure" }, Writer = new Writers { FirstName = "Alexandre", LastName = "Dumas" } },
                    new Books { BookTitle = "Dracula", PageCount = 418, Genre = new Genre { GenreName = "Gothic" }, Writer = new Writers { FirstName = "Bram", LastName = "Stoker" } },
                    new Books { BookTitle = "Frankenstein", PageCount = 280, Genre = new Genre { GenreName = "Gothic" }, Writer = new Writers { FirstName = "Mary", LastName = "Shelley" } },
                    new Books { BookTitle = "A Tale of Two Cities", PageCount = 448, Genre = new Genre { GenreName = "Historical" }, Writer = new Writers { FirstName = "Charles", LastName = "Dickens" } },
                    new Books { BookTitle = "Great Expectations", PageCount = 505, Genre = new Genre { GenreName = "Classic" }, Writer = new Writers { FirstName = "Charles", LastName = "Dickens" } },
                    new Books { BookTitle = "Oliver Twist", PageCount = 363, Genre = new Genre { GenreName = "Classic" }, Writer = new Writers { FirstName = "Charles", LastName = "Dickens" } },
                    new Books { BookTitle = "David Copperfield", PageCount = 624, Genre = new Genre { GenreName = "Classic" }, Writer = new Writers { FirstName = "Charles", LastName = "Dickens" } },
                    new Books { BookTitle = "Bleak House", PageCount = 928, Genre = new Genre { GenreName = "Classic" }, Writer = new Writers { FirstName = "Charles", LastName = "Dickens" } },
                    new Books { BookTitle = "Middlemarch", PageCount = 880, Genre = new Genre { GenreName = "Classic" }, Writer = new Writers { FirstName = "George", LastName = "Eliot" } },
                    new Books { BookTitle = "Silas Marner", PageCount = 240, Genre = new Genre { GenreName = "Classic" }, Writer = new Writers { FirstName = "George", LastName = "Eliot" } },
                    new Books { BookTitle = "Madame Bovary", PageCount = 329, Genre = new Genre { GenreName = "Classic" }, Writer = new Writers { FirstName = "Gustave", LastName = "Flaubert" } },
                    new Books { BookTitle = "The Stranger", PageCount = 123, Genre = new Genre { GenreName = "Philosophical" }, Writer = new Writers { FirstName = "Albert", LastName = "Camus" } },
                    new Books { BookTitle = "The Plague", PageCount = 308, Genre = new Genre { GenreName = "Philosophical" }, Writer = new Writers { FirstName = "Albert", LastName = "Camus" } },
                    new Books { BookTitle = "One Hundred Years of Solitude", PageCount = 417, Genre = new Genre { GenreName = "Magical Realism" }, Writer = new Writers { FirstName = "Gabriel", LastName = "García Márquez" } },
                    new Books { BookTitle = "Love in the Time of Cholera", PageCount = 348, Genre = new Genre { GenreName = "Romance" }, Writer = new Writers { FirstName = "Gabriel", LastName = "García Márquez" } },
                    new Books { BookTitle = "The Sound and the Fury", PageCount = 326, Genre = new Genre { GenreName = "Classic" }, Writer = new Writers { FirstName = "William", LastName = "Faulkner" } },
                    new Books { BookTitle = "As I Lay Dying", PageCount = 267, Genre = new Genre { GenreName = "Classic" }, Writer = new Writers { FirstName = "William", LastName = "Faulkner" } },
                    new Books { BookTitle = "The Sun Also Rises", PageCount = 251, Genre = new Genre { GenreName = "Classic" }, Writer = new Writers { FirstName = "Ernest", LastName = "Hemingway" } },
                    new Books { BookTitle = "For Whom the Bell Tolls", PageCount = 471, Genre = new Genre { GenreName = "Classic" }, Writer = new Writers { FirstName = "Ernest", LastName = "Hemingway" } }
                };

                dbContext.Books.AddRange(books);
                dbContext.SaveChanges();
            }
        }
    }
}
