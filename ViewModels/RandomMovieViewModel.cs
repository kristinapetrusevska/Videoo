using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Videoo.Models;

namespace Videoo.ViewModels
{
    public class RandomMovieViewModel
    {
        public List<Movie>movies { get; set; }
        public List<Customer> customers { get; set; }
    }
}