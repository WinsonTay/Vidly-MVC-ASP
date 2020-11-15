using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI;
using System.Web;
using System.Collections.Specialized;
using Vidly.Models;
using Vidly.Dtos;
using AutoMapper;
using System.Data.Entity;
using System.Web.Http.ModelBinding;


namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }


        //GET all customers
        [HttpGet]
        public IHttpActionResult GetCustomer()
        {
            var length = HttpContext.Current.Request.QueryString["length"];
                var customers = _context.Customers
                            .Include(c => c.MembershipType)
                            .ToList()
                            .Select(Mapper.Map<Customer , CustomerDto>);
            return Ok(customers);
        }

        //Get Specific Customer
        [Route("api/customers/{id}")]
        public CustomerDto GetSpecificCustomer(int id)
        {
         

            var customer = _context.Customers.SingleOrDefault(c => c.id == id);
            if(customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Mapper.Map<Customer, CustomerDto>(customer);
        }

        //POST Customer
        [HttpPost]
        public CustomerDto CreateCustomer([FromBody] CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.id = customer.id;
            return customerDto;


        }

        //Update Customer
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, CustomerDto customerDto)
        {
           
            var existingCustomer = _context.Customers.SingleOrDefault(c => c.id == id);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
               // return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, errors[0]));

            }
            if (existingCustomer == null)
            {
                ModelState.AddModelError("message", "Customer ID not found");
                return BadRequest(ModelState);

            }
           
            Mapper.Map(customerDto, existingCustomer);
            existingCustomer.id = id;

            _context.SaveChanges();
            return Ok( new { message = "Success"});
            
        }

        [HttpDelete]

        public void DeleteCustomer(int id)
        {
            var existingCustomer = _context.Customers.SingleOrDefault(c => c.id == id);
            if (existingCustomer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            //var customer = Mapper.Map<Customer, CustomerDto>(existingCustomer);

            _context.Customers.Remove(existingCustomer);
            _context.SaveChanges();

        }
    }
}
