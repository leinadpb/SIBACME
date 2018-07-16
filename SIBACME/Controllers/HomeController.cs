using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SIBACME.Models;

namespace SIBACME.Controllers
{
    //Nota: Esta función está implementada con malas prácticas con motivo de enseñanza.
    public class HomeController : Controller
    {
        public HomeController()
        {
           
        }
        public IActionResult Index()
        {
            return View();

        }

        public IActionResult Login()
        {
            var user = new User();
            return View(user);

        }

        public IActionResult CheckSign(User user)
        {
            //Nota: Esta función está implementada con malas prácticas con motivo de enseñanza.
            var users = DummyData.Users;
            var loginSuccedd = false;
            foreach (var usuario in DummyData.Users)
            {
                if (usuario.UserName == user.UserName && user.Password == usuario.Password)
                {
                    loginSuccedd = true;
                }
            }
            if (loginSuccedd)
            {
                var categoriaPreferida = user.CategoriaLibrosPreferidos;
                var model = new List<Book>();
                foreach (var book in DummyData.Books)
                {
                    if (book.Category.Name.ToLower() == categoriaPreferida)
                    {
                        model.Add(book);
                    }
                }
                //HACER QUE LOS LIBROS SE MUESTREN POR NOMBRE DE AUTHORES EN ORDEN ALFABETICO
                return RedirectToAction("index", model);
            }
            TempData["ErrorMessage"] = "La clave o contrasena son incorrectos";
            return RedirectToAction("Login");
        }

        /**
         * RESERVA DE RECURSO BIBLIOGRAFICO  - Daniel
         * */
        [HttpGet]
        public IActionResult Reserva()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Reseva(int BookId, int UserId)
        {
            var books = DummyData.Books;
            if (ReservaMethod(books.ToList(), BookId, UserId))
            {
                return View();
            }
            else
            {
                return NotFound();
            }

        }
        public static bool ReservaMethod(List<Book> books, int BookId, int UserId)
        //Nota: Esta función está implementada con malas prácticas con motivo de enseñanza.
        {
            
            Book book = null;
            if(books.Count > 0)
            {
                foreach (Book b in books)
                {
                    if (b.BookId == BookId)
                    {
                        book = DummyData.Books.Where(bk => bk.BookId == BookId).FirstOrDefault();
                        if (b.IsAvailable)
                        {
                            if (!b.IsOnReserveCollection && book != null)
                            {
                                User user = DummyData.Users.Where(u => u.Id == UserId).FirstOrDefault();

                                book.IsAvailable = false;

                                book.ReservedDate = DateTime.Now;
                                book.LimitDate = DateTime.Now.AddDays(15);


                                user.ReservedBooks.Add(book);

                                
                            }
                        }
                    }
                }
                if (book == null)
                {
                    var error = "Ha ocurrido un error: El libro no existe en nuestro almacén.";
                    return false;
                }

            }
            else
            {
                return false;
            }
            
            return true;
        }

        /**
         * PRESTAMO DE RECURSO BIBLIOGRAFICO - Dionis
         * */
        [HttpGet]
        public IActionResult Prestamo()
        {
            return View();
        }
        [HttpPut]
        public IActionResult Prestamo(Book book)
        {
            return View();
        }

        /**
          * DEVUELTA DE RECURSO BIBLIOGRAFICO - Daniel, Dionis, Pedro
          * */
        [HttpGet]
        public IActionResult Devuelta()
        {
            return View();
        }
        [HttpPut]
        public IActionResult Devuelta(int BookId, int UserId)
        {
            Book book = null;
            foreach (Book b in DummyData.Books)
            {
                if (b.BookId == BookId)
                {
                    book = DummyData.Books.Where(bk => bk.BookId == BookId).FirstOrDefault();
                    User user = DummyData.Users.Where(u => u.Id == UserId).FirstOrDefault();
                    if(!book.IsAvailable)
                    {
                        if (DateTime.Now > book.LimitDate)
                        {
                             var datediff = DateTime.Now.Subtract((DateTime)book.LimitDate);
                             int days = datediff.Days;
                           if(days >= 8)
                            {
                                user.ListaNegra = true;
                            }
                           user.Multa = days * 20;
                        }
                        user.ReservedBooks.Remove(book);
                        b.IsAvailable = true;
                     }   
                }
            }
            if(book == null)
            {
                ViewBag.Error = "Ha ocurrido un error: El libro no existe en nuestro almacén.";
            }
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
