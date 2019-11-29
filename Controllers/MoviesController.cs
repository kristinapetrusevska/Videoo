using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Videoo.Models;
using Videoo.ViewModels;

namespace Videoo.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/random
        //public ActionResult Random()
        //{
        //    var movie = new Movie() { Name="Shrek!"};
        //    var customers = new List<Customer> {
        //        new Customer{Name="Customer 1"},
        //        new Customer{Name="Customer 2"},
        //        new Customer{Name="Customer 3"}
        //    };
        //    var viewModel = new RandomMovieViewModel() {
        //        Movie = movie,
        //        Customers=customers
        //    };
        //    return View(viewModel);
        //}
        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }

        //movies
        public ActionResult Index()
        {
            var movie = new List<Movie>() {
                new Movie{Name="movie 1"},
                new Movie{Name="movie 2"},
                new Movie{Name="movie 3"}

            };
            var movieModel = new RandomMovieViewModel() {
                movies = movie
            };
            return View(movieModel);
        }
        public ActionResult ByReleaseDate(int year,int month)
        {

            return Content(year+"/"+month);

        }
    }
}