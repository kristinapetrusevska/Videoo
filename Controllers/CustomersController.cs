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
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        List<Customer> Customers = new List<Customer>() {
                new Customer{Name="Customer 1",Id=1},
                new Customer{Name="Customer 2",Id=2},
                new Customer{Name="Customer 3",Id=3}
            };
        // GET: Customers
        public ViewResult Index()
        {

            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            //var custModel = new RandomMovieViewModel() {
            //    customers = Customers };
            return View(customers);
        }
        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c=>c.MembershipType).SingleOrDefault(d => d.Id == id);
            if (customer != null) return View(customer);
            else return HttpNotFound();
        }
    }
}