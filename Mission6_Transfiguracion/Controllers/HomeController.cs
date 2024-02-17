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
            if (response.LentTo == null)
            {
                response.LentTo = "";
            }

            if (response.Notes == null)
            {
                response.Notes = "";
            }

            if (response.Category == null)
            {
                response.Category = "";
            }

            //Ask Hilton
            //_context.AddMovie.Add(response);
            //_context.SaveChanges();
            return View("Confirmation");
        }
    }
}
