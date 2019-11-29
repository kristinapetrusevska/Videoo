using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Videoo.Models;
using Videoo.ViewModels;

namespace Videoo.Controllers
{
    public class CustomersController : Controller
    {
        List<Customer> Customers = new List<Customer>() {
                new Customer{Name="Customer 1",Id=1},
                new Customer{Name="Customer 2",Id=2},
                new Customer{Name="Customer 3",Id=3}
            };
        // GET: Customers
        public ActionResult Index()
        {
            
            
            var custModel = new RandomMovieViewModel() {
                customers = Customers };
            return View(custModel);
        }
        public ActionResult Details(int id)
        {
            var customer = Customers.Find(d => d.Id == id);
            if (customer != null) return View(customer);
            else return HttpNotFound();
        }
    }
}