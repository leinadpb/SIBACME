using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SIBACME.Models;

namespace SIBACME.Controllers
{
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
        public IActionResult Devuelta(Book book)
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
