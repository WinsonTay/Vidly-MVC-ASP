using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
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

        
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();

            return View(customers);
        }
        // GET: Customers
        public ActionResult Details(int id)
        {
            Customer customer = _context.Customers.Include(c=> c.MembershipType).FirstOrDefault(x => x.id == id);
            if(customer != null)
            {
                return View(customer);
            }

            return HttpNotFound();
        }


    }
}