using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [HttpPost]
        public IHttpActionResult CreateNewRentals(RentalDto NewRentaldto)
        {
            var customer = db.Customers.SingleOrDefault(c => c.id == NewRentaldto.CustomerId);
            if (customer == null)
            {
                return NotFound();
            }

            var movies = db.Movies.Where(m => NewRentaldto.MoviesId.Contains(m.id)).ToList();
            var newRentals = new List<Rental>();

            foreach (var movie in movies)
            {
                var movieAvailability = db.Movies.SingleOrDefault(m => m.id == movie.id);
                if(movieAvailability.NumberAvailable != 0)
                {
                   movieAvailability.NumberAvailable = movieAvailability.NumberAvailable - 1;

                    newRentals.Add(new Rental
                    {
                        Customer = customer,
                        Movie = movie,
                        DateRented = DateTime.Now
                    });


                }
                db.SaveChanges();
            }
          
            
        
            return Ok(new { message = "success"});
        }

    }
}
