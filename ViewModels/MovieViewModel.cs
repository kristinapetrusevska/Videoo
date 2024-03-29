﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Videoo.Models;

namespace Videoo.ViewModels
{
    public class MovieViewModel
    {
        public List<Movie> movies;
        public Movie movie { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
    }
}