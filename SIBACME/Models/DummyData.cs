using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SIBACME.Models;

namespace SIBACME.Models
{
    public class DummyData
    {
        public ICollection<Book> Books {

            get { return Books; }

            set {
                Books.Add(new Book { BookId = 1, BookTitle = "La casa viviente", BookAuthor = "Marco Polo" });
                Books.Add(new Book { BookId = 1, BookTitle = "Los mejores cuentos", BookAuthor = "Anton Chejov" });
                Books.Add(new Book { BookId = 1, BookTitle = "La casa viviente", BookAuthor = "Marco Polo" });
                Books.Add(new Book { BookId = 1, BookTitle = "La casa viviente", BookAuthor = "Marco Polo" });
                Books.Add(new Book { BookId = 1, BookTitle = "La casa viviente", BookAuthor = "Marco Polo" });
                Books.Add(new Book { BookId = 1, BookTitle = "La casa viviente", BookAuthor = "Marco Polo" });
                Books.Add(new Book { BookId = 1, BookTitle = "La casa viviente", BookAuthor = "Marco Polo" });
                Books.Add(new Book { BookId = 1, BookTitle = "La casa viviente", BookAuthor = "Marco Polo" });
                Books.Add(new Book { BookId = 1, BookTitle = "La casa viviente", BookAuthor = "Marco Polo" });
                Books.Add(new Book { BookId = 1, BookTitle = "La casa viviente", BookAuthor = "Marco Polo" });
                Books.Add(new Book { BookId = 1, BookTitle = "Una hormiga gigante", BookAuthor = "Daniel Peña" });
                Books.Add(new Book { BookId = 1, BookTitle = "La casa viviente", BookAuthor = "Marco Polo" });
                Books.Add(new Book { BookId = 1, BookTitle = "La casa viviente", BookAuthor = "Marco Polo" });
                Books.Add(new Book { BookId = 1, BookTitle = "La casa viviente", BookAuthor = "Marco Polo" });
                Books.Add(new Book { BookId = 1, BookTitle = "La casa viviente", BookAuthor = "Marco Polo" });
                Books.Add(new Book { BookId = 1, BookTitle = "La casa viviente", BookAuthor = "Marco Polo" });
                Books.Add(new Book { BookId = 1, BookTitle = "La casa viviente", BookAuthor = "Marco Polo" });
                Books.Add(new Book { BookId = 1, BookTitle = "La casa viviente", BookAuthor = "Marco Polo" });
            }
        }
    }
}
