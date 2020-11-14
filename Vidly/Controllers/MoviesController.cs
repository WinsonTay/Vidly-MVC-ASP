using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;
        public List<Movie> movies = new List<Movie>()
        {
            new Movie {id = 1 , Name = "The Queens Of Gambit"},
            new Movie {id = 2, Name = "Ford Vs Ferarri"}
        };
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }



        public ActionResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();
            return View(movies);
        }
        // GET: Movies
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek !" };
            var customers = new List<Customer>
            {
                new Customer { name = "David" },
                new Customer { name = "John"},
                new Customer { name = "Lollipop"},
                //new Customer { name = "Freikenstein"}

            };
            var viewModel = new RandomViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }

   
        public ViewResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.id == id);
            return View(movie);
        }

        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel
                {
                    Genres = _context.Genres.ToList(),
                    Movie = movie
                };

                return View("MovieForm", viewModel);
               
            }
            if(movie.id == 0)
            {
                var newMovie = _context.Movies.Add(movie);
            }
            else
            {
                var existingMovie = _context.Movies.SingleOrDefault(m => m.id == movie.id);
                existingMovie.Name = movie.Name;
                existingMovie.GenreId = movie.GenreId;
                existingMovie.ReleasedDate = movie.ReleasedDate;
                existingMovie.NumberInStock = movie.NumberInStock;
            }
            
            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
           
        }
        
        public ActionResult New()
        {
            var viewModel = new MovieFormViewModel
            {
                Genres = _context.Genres.ToList()

            };
            return View("MovieForm", viewModel);
        }
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.FirstOrDefault(m => m.id == id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            else
            {

                var viewModel = new MovieFormViewModel
                {
                    Genres = _context.Genres.ToList(),
                    Movie = movie
                };
                return View("MovieForm", viewModel);
            }
        
        }
        [Route("movies/release/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content($"{year} / {month}");
        }


    }
}