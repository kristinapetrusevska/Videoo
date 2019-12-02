using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Videoo.Models
{
    public class Movie
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public DateTime? ReleaseDate { get; set; }
        public DateTime? AddedToDatabase { get; set; }

        [Required(ErrorMessage = "The No. in stock must be between 1 and 20. ")]
        [Range(1,20)]
        public int NumberInStock { get; set; }
        public Genre Genre { get; set; }

        public int GenreId { get; set; }
    }
}