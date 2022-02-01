using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission5.Models;

namespace Mission5.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MovieContext movieContext { get; set; }

        // Constructor 
        public HomeController(ILogger<HomeController> logger, MovieContext someName)
        {
            _logger = logger;
            movieContext = someName;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Podcasts()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MovieForm()
        {
            ViewBag.Categories = movieContext.categories.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult MovieForm(MovieModel mm) // I didn't have to name it model -- I could've named it anything
        {
            if (ModelState.IsValid)
            {
                movieContext.Add(mm);
                movieContext.SaveChanges();

                return View("Confirmation", mm);
            }
            else
            {
                ViewBag.Categories = movieContext.categories.ToList();
                return View();
            }

        }

        [HttpGet]
        public IActionResult ViewMovies()
        {
            var applications = movieContext.responses // uses movieContext we set up above and the responses which is the database set we set up in the context file
                .Include(x => x.Category) // I want to include Category object that goes along with that response
                .ToList(); //We used a list so that we can loop through one item at a time
            return View(applications);
        }

        [HttpGet]
        public IActionResult Edit(int movieid) // pass the correct mvoieid in -- we get this name from the asp-route value on ViewMovies.cshtml
        {
            ViewBag.Categories = movieContext.categories.ToList(); // We want the categories part to work since it is from a different table

            var movie = movieContext.responses.Single(x => x.MovieId == movieid);  // application is singular -- we are editing 1
            // applicationid is what we passed into the IActionResult 

            return View("MovieForm", movie); // pass application to this so it is linked to a specific applicant
        }

        [HttpPost]
        public IActionResult Edit(MovieModel blah)
        {
            movieContext.Update(blah);
            movieContext.SaveChanges();

            return RedirectToAction("ViewMovies");
        }

        [HttpGet]
        public IActionResult Delete(int movieid)
        {
            var movie = movieContext.responses.Single(x => x.MovieId == movieid);

            return View(movie);
        }

        [HttpPost]
        public IActionResult Delete(MovieModel blah)
        {
            movieContext.responses.Remove(blah);
            movieContext.SaveChanges();

            return RedirectToAction("ViewMovies"); // redirect user back to view movie page

        }





        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
