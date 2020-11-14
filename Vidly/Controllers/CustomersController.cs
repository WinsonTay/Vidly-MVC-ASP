using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

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
     
        public ActionResult Details(int id)
        {
            Customer customer = _context.Customers.Include(c=> c.MembershipType).FirstOrDefault(x => x.id == id);
            if(customer != null)
            {
                return View(customer);
            }

            return HttpNotFound();
        }

        public ActionResult New()
        {
           var membershipTypes = _context.MembershipTypes.ToList();
            CustomerFormViewModel viewModel = new CustomerFormViewModel
            {
                MembershipTypes = membershipTypes,

            };   
            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)

        {
            //if form is invalid
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {   Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };

                //Go to Customer form View
                return View("CustomerForm", viewModel);

            }


            if(customer.id  == 0)
            {
                var newCustomer = _context.Customers.Add(customer);

            }
            else
            {
                var existingCustomer = _context.Customers.Single(c => c.id == customer.id);
                existingCustomer.name = customer.name;
                existingCustomer.MemberShipTypeId = customer.MemberShipTypeId;
                existingCustomer.BirthDate = customer.BirthDate;
                existingCustomer.IsSubcribedToNewsLetter = customer.IsSubcribedToNewsLetter;

            }
                //Saving Data
                _context.SaveChanges();
                return RedirectToAction("Index", "Customers");

                
          
        }
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.id == id);
            //Saving Data
            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

              return View("CustomerForm" , viewModel);


        }



    }
}