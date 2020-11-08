using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {

        public List<Customer> customers = new List<Customer>()
        {
            new Customer {id=1 , name = "John Cena"},
            new Customer {id=2 , name = "Lewis Hamilton"}
        };
        // GET: Customers
        public ActionResult Index()
        {
           
            return View(customers);
        }
        // GET: Customers
        public ActionResult Details(int id)
        {
            Customer customer = customers.FirstOrDefault(x => x.id == id);
            if(customer != null)
            {
                return View(customer);
            }

            return HttpNotFound();
        }


    }
}