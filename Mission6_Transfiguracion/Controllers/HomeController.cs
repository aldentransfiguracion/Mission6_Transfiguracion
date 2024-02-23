using Microsoft.AspNetCore.Mvc;
using Mission6_Transfiguracion.Models;
using System.Diagnostics;

namespace Mission6_Transfiguracion.Controllers
{
    public class HomeController : Controller
    {
        private AddMovieContext _context;
        public HomeController(AddMovieContext temp)
        {
            _context = temp;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddMovie()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddMovie(AddMovie response)
        {
            _context.AddMovie.Add(response); //Add record to database
            _context.SaveChanges();
            return View("Confirmation", response);
        }
    }
}