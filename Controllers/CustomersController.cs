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
        public ViewResult Index(string id)
        {
            var customers= new List<Customer>();
            if (!String.IsNullOrEmpty(id))
            {
                customers = _context.Customers.Where(s => s.Name.Contains(id)).Include(c => c.MembershipType).ToList();
            }
            else
            {
                customers = _context.Customers.Include(c => c.MembershipType).ToList();
            }
            return View(customers);
        }
        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(d => d.Id == id);
            if (customer != null) return View(customer);
            else return HttpNotFound();
        }
        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var newModel = new CustomerViewModel()
            {
                customer = new Customer(),
                MembershipTypes = membershipTypes
            };
            return View("CustomerForm",newModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerViewModel()
                {
                    customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("CustomerForm",viewModel);
            }
            if (customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.Birthday = customer.Birthday;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            }
                _context.SaveChanges();
                return RedirectToAction("Index", "Customers");
            
        }
        
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null) return HttpNotFound();
            var viewModel = new CustomerViewModel()
            {
                MembershipTypes = _context.MembershipTypes.ToList(),
                customer = customer
            };
            return View("CustomerForm",viewModel);
        }
        public ActionResult Delete(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            _context.Customers.Remove(customer);
            _context.SaveChanges();            
            return RedirectToAction("Index", "Customers");
        }

        
    }
}