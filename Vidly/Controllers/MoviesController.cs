using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        public List<Movie> movies = new List<Movie>
        {
            new Movie {id =1 , Name = "The Queens Of Gambit"}
        };

        public ActionResult Index()
        {
            return View();
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

        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }
                                    // '?' for nullable pageIndex
        public ActionResult Index(int? pageIndex , string sortBy)
        {
            if (!pageIndex.HasValue)
            {
                pageIndex = 1;
            }
            if (String.IsNullOrWhiteSpace(sortBy))
            {
                sortBy = "Name";
            }
            return Content($"pageIndex={pageIndex}&sortBy={sortBy}");
        }

        [Route("movies/release/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content($"{year} / {month}");
        }


    }
}