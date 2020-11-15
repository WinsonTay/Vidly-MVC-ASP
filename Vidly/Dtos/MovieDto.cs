using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Dtos
{
    public class MovieDto
    {

        public int id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Select A Genre for that movie")]
        public byte GenreId { get; set; }

        [Required]
        public DateTime? ReleasedDate { get; set; }

        [Required]
        [Range(1, 20, ErrorMessage = "Please key in between 1 and 20 ")]
        public int NumberInStock { get; set; }
    }
}