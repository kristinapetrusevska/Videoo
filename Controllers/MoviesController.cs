﻿using System;
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
        
        //movies
        public ActionResult Index()
        {
            var movie = _context.Movies.Include(c => c.Genre).ToList();

            return View(movie);
        }
        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(c => c.Genre).SingleOrDefault(d => d.Id == id);
            if (movie == null) return HttpNotFound();
            else return View(movie);
        }
        
        public ActionResult New()
        {
            var genres = _context.Genres.ToList();
            var newModel = new MovieViewModel()
            {
                Genres = genres
            };
            return View("MovieForm", newModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieViewModel()
                {
                    movie = movie,
                   Genres = _context.Genres.ToList()
                };
                return View("MovieForm", viewModel);
            }
            if (movie.Id == 0)
                _context.Movies.Add(movie);
            else
            {
                var movieInDb = _context.Movies.Single(c => c.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.AddedToDatabase =DateTime.Today;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");

        }
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (movie == null) return HttpNotFound();
            var viewModel = new MovieViewModel()
            {
                Genres = _context.Genres.ToList(),
                movie=movie
            };
            return View("MovieForm", viewModel);
        }
        public ActionResult Delete(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);
            _context.Movies.Remove(movie);
            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }
    }
}