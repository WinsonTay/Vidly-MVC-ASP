using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int id { get; set; }
        public string Name { get; set; }
        public Genre Genre { get; set; }
        public byte GenreId { get; set; }
        public DateTime? ReleasedDate { get; set; }
        public DateTime? DatedAdded { get; set; }
        public int NumberInStock { get; set; }




    }
}