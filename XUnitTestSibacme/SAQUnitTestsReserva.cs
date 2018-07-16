using System;
using Xunit;
using SIBACME.Models;
using SIBACME.Controllers;
using System.Collections.Generic;
using System.Linq;

namespace XUnitTestSibacme
{
    public class SAQUnitTestsReserva
    {
        public static List<Book> Books
        {

            get { return Books; }

            set
            {
                Books.Add(new Book { BookId = 1, BookTitle = "La casa viviente", BookAuthor = "Marco Polo", Cantidad = 7, CantidadDisponible = 3, IsAvailable = true, IsOnReserveCollection = false });
                Books.Add(new Book { BookId = 2, BookTitle = "Los mejores cuentos", BookAuthor = "Anton Chejov", Cantidad = 8, CantidadDisponible = 4, IsAvailable = true, IsOnReserveCollection = false });
                Books.Add(new Book { BookId = 1, BookTitle = "La casa viviente", BookAuthor = "Marco Polo", Cantidad = 7, CantidadDisponible = 4, IsAvailable = true, IsOnReserveCollection = false });
                Books.Add(new Book { BookId = 3, BookTitle = "La casa viviente", BookAuthor = "Marco Polo", Cantidad = 6, CantidadDisponible = 2, IsAvailable = true, IsOnReserveCollection = false });
                Books.Add(new Book { BookId = 4, BookTitle = "La casa viviente", BookAuthor = "Marco Polo", Cantidad = 4, CantidadDisponible = 1, IsAvailable = true, IsOnReserveCollection = false });
                Books.Add(new Book { BookId = 5, BookTitle = "La casa viviente", BookAuthor = "Marco Polo", Cantidad = 6, CantidadDisponible = 2, IsAvailable = true, IsOnReserveCollection = false });
                Books.Add(new Book { BookId = 6, BookTitle = "La casa viviente", BookAuthor = "Marco Polo", Cantidad = 2, CantidadDisponible = 1, IsAvailable = false, IsOnReserveCollection = true, LimitDate = datetime.now().addDays(-7) });
                Books.Add(new Book { BookId = 7, BookTitle = "La casa viviente", BookAuthor = "Marco Polo", Cantidad = 4, CantidadDisponible = 2, IsAvailable = false, IsOnReserveCollection = true, LimitData = datetime.now().addDays(-8) });
                Books.Add(new Book { BookId = 8, BookTitle = "La casa viviente", BookAuthor = "Marco Polo", Cantidad = 2, CantidadDisponible = 1, IsAvailable = false, IsOnReserveCollection = true, LimitData = datetime.now().addDays(15) });
                Books.Add(new Book { BookId = 9, BookTitle = "La casa viviente", BookAuthor = "Marco Polo", Cantidad = 4, CantidadDisponible = 2, IsAvailable = false, IsOnReserveCollection = true });
                Books.Add(new Book { BookId = 10, BookTitle = "Una hormiga gigante", BookAuthor = "Daniel Peña", Cantidad = 3, CantidadDisponible = 1, IsAvailable = false, IsOnReserveCollection = true });
                Books.Add(new Book { BookId = 11, BookTitle = "La casa viviente", BookAuthor = "Marco Polo", Cantidad = 2, CantidadDisponible = 1, IsAvailable = true, IsOnReserveCollection = false });
                Books.Add(new Book { BookId = 12, BookTitle = "La casa viviente", BookAuthor = "Marco Polo", Cantidad = 3, CantidadDisponible = 2, IsAvailable = false, IsOnReserveCollection = true });
                Books.Add(new Book { BookId = 13, BookTitle = "La casa viviente", BookAuthor = "Marco Polo", Cantidad = 4, CantidadDisponible = 1, IsAvailable = true, IsOnReserveCollection = false });
                Books.Add(new Book { BookId = 14, BookTitle = "La casa viviente", BookAuthor = "Marco Polo", Cantidad = 2, CantidadDisponible = 2, IsAvailable = false, IsOnReserveCollection = true });
                Books.Add(new Book { BookId = 15, BookTitle = "La casa viviente", BookAuthor = "Marco Polo", Cantidad = 4, CantidadDisponible = 4, IsAvailable = true, IsOnReserveCollection = false });
                Books.Add(new Book { BookId = 16, BookTitle = "La casa viviente", BookAuthor = "Marco Polo", Cantidad = 3, CantidadDisponible = 1, IsAvailable = true, IsOnReserveCollection = false });
                Books.Add(new Book { BookId = 17, BookTitle = "La casa viviente", BookAuthor = "Marco Polo", Cantidad = 4, CantidadDisponible = 2, IsAvailable = false, IsOnReserveCollection = true });
            }
        }

        [Fact]
        public void ReservaTestCase1()
        {
            //Setup
            int userId = 3; // User: Dionis
            int bookId = 16;  // Book:: Is available and is NOT in reserve list
            //List<Book> books = this.Books; // books: Regular
            //Assert
            Assert.True(HomeController.ReservaMethod(Books, bookId, userId));
        }

        [Fact]
        public void ReservaTestCase2()
        {
            //Setup
            int userId = 0; // User: null
            int bookId = 0;  // Book:: null
            //List<Book> books = this.Books; // Books: regular
            //Assert
            Assert.False(HomeController.ReservaMethod(Books, bookId, userId));
        }

        [Fact]
        public void ReservaTestCase3()
        {
            //Setup
            int userId = 3; // User: Dionis
            int bookId = 0;  // Book:: null
            //List<Book> books = this.Books; // Books: Regular
            //Assert
            Assert.False(HomeController.ReservaMethod(Books, bookId, userId));
        }

        [Fact]
        public void ReservaTestCase4()
        {
            //Setup
            int userId = 3; // User: Dionis
            int bookId = 16;  // Book:: Is available and is NOT in reserve list
            List<Book> books = new List<Book>(); // Books: null
            //Assert
            Assert.False(HomeController.ReservaMethod(books, bookId, userId));
        }

        [Fact]
        public void DevolucionTestCase1()
        {
            //Setup
            int userId = 3; //User: Dionis
            int bookId = 7; // Book: Is not available 
            // Days = 8
            // Time: Not in time
            //Assert
            Assert.True(HomeController.Devuelta(bookId, userId));
        }

        [Fact]
        public void DevolucionTestCase2()
        {
            //Setup
            int userId = 3; //User: Dionis
            int bookId = 8; //Book: Is not available 
            //Days = 0
            //Time: On time
            //Assert
            Assert.True(HomeController.Devuelta(bookId, userId));
        }

        [Fact]
        public void DevolucionTestCase3()
        {
            //Setup
            int userId = 3; //User: Dionis
            int bookId = 6; //Book: Is not avaible
            //Days = 7
            //Time: Not in time
            //Assert
            Assert.True(HomeController.Devuelta(bookId, userId));
        }

    }
}
