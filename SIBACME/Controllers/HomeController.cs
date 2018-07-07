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
        DummyData _data;
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
        [HttpPut]
        public IActionResult Reserva(Book book)
        {
            Random rdn = new Random();
            if(book == null) // Testing purporse
            {
                book = _data.Books.ElementAt(rdn.Next(0, _data.Books.Count));
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
