using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SIBACME.Models;

namespace SIBACME.Models
{
    public static class DummyData
    {
        public static List<Category> Categories
        {
            get { return Categories; }
            set
            {
                Categories.Add(new Category{Id=1,Name = "Terror"});
                Categories.Add(new Category { Id = 2, Name = "Comedia" });
                Categories.Add(new Category { Id = 3, Name = "Novela" });
                Categories.Add(new Category { Id = 4, Name = "Accion" });
                Categories.Add(new Category { Id = 5, Name = "Romantico" });
                Categories.Add(new Category { Id = 6, Name = "Historia" });
                Categories.Add(new Category { Id = 6, Name = "Tecnologia" });
                Categories.Add(new Category { Id = 7, Name = "Ciencias" });
                Categories.Add(new Category { Id = 8, Name = "Cultura" });
            }
        }

        public static List<User> Users
        {
            get { return Users; }
            set
            {
                Users.Add(new User{Id = 1,Email = "dionisjosue@gmail.com",Password = "Admin",CategoriaLibrosPreferidos = "Terror"});
                Users.Add(new User { Id = 1, Email = "dionisjosue@gmail.com", Password = "Admin", CategoriaLibrosPreferidos = "Terror" });
                Users.Add(new User { Id = 1, Email = "dionisjosue@gmail.com", Password = "Admin", CategoriaLibrosPreferidos = "Terror" });
                Users.Add(new User { Id = 1, Email = "dionisjosue@gmail.com", Password = "Admin", CategoriaLibrosPreferidos = "Terror" });
                Users.Add(new User { Id = 1, Email = "dionisjosue@gmail.com", Password = "Admin", CategoriaLibrosPreferidos = "Terror" });

            }
        }
        public static ICollection<Book> Books {

            get { return Books; }

            set {
                Books.Add(new Book { BookId = 1, BookTitle = "La casa viviente", BookAuthor = "Marco Polo",Cantidad = 7,CantidadDisponible = 3});
                Books.Add(new Book { BookId = 2, BookTitle = "Los mejores cuentos", BookAuthor = "Anton Chejov", Cantidad = 8, CantidadDisponible = 4 });
                Books.Add(new Book { BookId = 1, BookTitle = "La casa viviente", BookAuthor = "Marco Polo", Cantidad = 7, CantidadDisponible = 4 });
                Books.Add(new Book { BookId = 3, BookTitle = "La casa viviente", BookAuthor = "Marco Polo", Cantidad = 6 , CantidadDisponible = 2 });
                Books.Add(new Book { BookId = 4, BookTitle = "La casa viviente", BookAuthor = "Marco Polo", Cantidad = 4, CantidadDisponible = 1 });
                Books.Add(new Book { BookId = 5, BookTitle = "La casa viviente", BookAuthor = "Marco Polo", Cantidad = 6, CantidadDisponible = 2 });
                Books.Add(new Book { BookId = 6, BookTitle = "La casa viviente", BookAuthor = "Marco Polo", Cantidad = 2, CantidadDisponible = 1 });
                Books.Add(new Book { BookId = 7, BookTitle = "La casa viviente", BookAuthor = "Marco Polo", Cantidad = 4, CantidadDisponible = 2 });
                Books.Add(new Book { BookId = 8, BookTitle = "La casa viviente", BookAuthor = "Marco Polo", Cantidad = 2, CantidadDisponible = 1 });
                Books.Add(new Book { BookId = 9, BookTitle = "La casa viviente", BookAuthor = "Marco Polo", Cantidad = 4, CantidadDisponible = 2 });
                Books.Add(new Book { BookId = 10, BookTitle = "Una hormiga gigante", BookAuthor = "Daniel Peña", Cantidad = 3, CantidadDisponible = 1 });
                Books.Add(new Book { BookId = 11, BookTitle = "La casa viviente", BookAuthor = "Marco Polo", Cantidad = 2, CantidadDisponible = 1 });
                Books.Add(new Book { BookId = 12, BookTitle = "La casa viviente", BookAuthor = "Marco Polo", Cantidad = 3, CantidadDisponible = 2 });
                Books.Add(new Book { BookId = 13, BookTitle = "La casa viviente", BookAuthor = "Marco Polo", Cantidad = 4, CantidadDisponible = 1 });
                Books.Add(new Book { BookId = 14, BookTitle = "La casa viviente", BookAuthor = "Marco Polo", Cantidad = 2, CantidadDisponible = 2 });
                Books.Add(new Book { BookId = 15, BookTitle = "La casa viviente", BookAuthor = "Marco Polo", Cantidad = 4, CantidadDisponible = 4 });
                Books.Add(new Book { BookId = 16, BookTitle = "La casa viviente", BookAuthor = "Marco Polo", Cantidad = 3, CantidadDisponible = 1 });
                Books.Add(new Book { BookId = 17, BookTitle = "La casa viviente", BookAuthor = "Marco Polo", Cantidad = 4, CantidadDisponible = 2 });
            }
        }
       
    }
}
