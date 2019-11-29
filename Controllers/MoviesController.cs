using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Videoo.Models;
using Videoo.ViewModels;
using System.Data.Entity;

namespace Videoo.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }

        //movies
        public ActionResult Index()
        {
            var movie = _context.Movies.Include(c=>c.Genre).ToList();
            
            return View(movie);
        }
        public ActionResult Details (int id)
        {
            var movie = _context.Movies.Include(c => c.Genre).SingleOrDefault(d => d.Id == id);
            if (movie == null) return HttpNotFound();
            else return View(movie);
        }
        public ActionResult ByReleaseDate(int year,int month)
        {

            return Content(year+"/"+month);

        }
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
    }
}