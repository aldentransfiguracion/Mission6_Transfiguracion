using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission6_Transfiguracion.Models;
using System;
using System.Diagnostics;

namespace Mission6_Transfiguracion.Controllers
{
    public class HomeController : Controller
    {
        private AddMovieContext _context;
        public HomeController(AddMovieContext temp) //Constructor: when homecontroller is built, bring an instance of add movie application
        {
            _context = temp;
        }
        public IActionResult Index() //View Index page
        {
            return View();
        }
        public IActionResult MovieList() //View Movie List
        {
            var movies = _context.Movies.Include(x => x.Category).ToList();

            return View(movies);
        }
        public IActionResult About() //View About page
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddMovie() //View AddMovie page
        {
            ViewBag.Categories = _context.Categories.ToList();
            return View("AddMovie", new AddMovie());
        }

        [HttpPost]  //Takes instance from form and adds it to the context file which in turn sends it to database
        public IActionResult AddMovie(AddMovie response)
        {
            if (ModelState.IsValid) //If Data in form is valid
            {
                _context.Movies.Add(response); //Sends record to database
                _context.SaveChanges(); //Saves record to database 
                return View("Confirmation", response); //Sends person to confirmation page
            }
            else //If Data in form is invalid, bring them back to form
            {
                ViewBag.Categories = _context.Categories.ToList();
                return View(response);
            }
        }

        [HttpGet]
        public IActionResult Edit(int id) //Recieve specific movie record onto in addmovie view
        {
            var recordToEdit = _context.Movies.Single(x => x.MovieId == id);
            ViewBag.Categories = _context.Categories.ToList();
            return View("AddMovie", recordToEdit);
        }
        [HttpPost]
        public IActionResult Edit(AddMovie updatedInfo) //Save edits then return to movie list view
        {
            if (ModelState.IsValid)
            {
                _context.Update(updatedInfo);
                _context.SaveChanges();
                return RedirectToAction("MovieList");
            }
            else
            {
                ViewBag.Categories = _context.Categories.ToList();
                return View("AddMovie", updatedInfo);
            }

        }
        [HttpGet]
        public IActionResult Delete(int id) //Recieve movie record to delete
        {
            var recordToDelete = _context.Movies.Single(x => x.MovieId == id);
            return View(recordToDelete);
        }
        [HttpPost]
        public IActionResult Delete(AddMovie deletingMovie)  //Delete or cancel deletion of record
        {
            _context.Movies.Remove(deletingMovie);
            _context.SaveChanges();

            return RedirectToAction("MovieList");
        }
    }
}