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
        private DummyData _data;

        public HomeController()
        {
            _data = new DummyData();
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
            var users = _data.Users;
            var loginSuccedd = false;
            foreach (var usuario in _data.Users)
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
                foreach (var book in _data.Books)
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
        public IActionResult Reserva(int BookId, int UserId)
        //Nota: Esta función está implementada con malas prácticas con motivo de enseñanza.
        {
            var books = _data.Books;
            Book book = null;
            foreach (Book b in books)
            {
                if (b.BookId == BookId)
                {
                    book = _data.Books.Where(bk => bk.BookId == BookId).FirstOrDefault();
                    if (b.IsAvailable)
                    {
                        if (!b.IsOnReserveCollection && book != null)
                        {
                            User user = _data.Users.Where(u => u.Id == UserId).FirstOrDefault();

                            book.IsAvailable = false;

                            book.ReservedDate = DateTime.Now;
                            book.LimitDate = DateTime.Now.AddDays(15);


                            user.ReservedBooks.Add(book);
                        }
                    }
                }
            }
            return View();
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
            foreach (Book b in _data.Books)
            {
                if (b.BookId == BookId)
                {
                    book = _data.Books.Where(bk => bk.BookId == BookId).FirstOrDefault();
                    User user = _data.Users.Where(u => u.Id == UserId).FirstOrDefault();
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
