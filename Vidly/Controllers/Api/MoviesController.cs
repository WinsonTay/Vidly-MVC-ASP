using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Vidly.Dtos;
using Vidly.Models;
using AutoMapper;

namespace Vidly.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Movies
        public IEnumerable<MovieDto> GetMovies()
        {
            var movies = db.Movies.ToList().Select(m =>
                new MovieDto
                {
                    id = m.id,
                    Name = m.Name,
                    GenreId = m.GenreId,
                    ReleasedDate = m.ReleasedDate

                }
            );
            return movies;
        }

        // GET: api/Movies/5
        [ResponseType(typeof(MovieDto))]
        public IHttpActionResult GetMovie(int id)
        {
            var movieDto = new MovieDto();
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return NotFound();
            }

            Mapper.Map<Movie, MovieDto>(movie, movieDto);

            //movieDto.id = movie.id;
            //movieDto.Name = movie.Name;
            //movieDto.NumberInStock = movie.NumberInStock;
            //movieDto.ReleasedDate = movie.ReleasedDate;

         

            return Ok(movieDto);
        }

        // PUT: api/Movies/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMovie(int id, Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != movie.id)
            {
                return BadRequest();
            }

            db.Entry(movie).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Movies
        [ResponseType(typeof(MovieDto))]
        public IHttpActionResult PostMovie(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Movies.Add(movie);
            db.SaveChanges();
            var movieDto = Mapper.Map<Movie, MovieDto>(movie);

            return CreatedAtRoute("DefaultApi", new { id = movieDto.id }, movieDto);
        }

        // DELETE: api/Movies/5
        
        public IHttpActionResult DeleteMovie(int id)
        {
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return NotFound();
            }

            db.Movies.Remove(movie);
            db.SaveChanges();

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MovieExists(int id)
        {
            return db.Movies.Count(e => e.id == id) > 0;
        }
    }
}