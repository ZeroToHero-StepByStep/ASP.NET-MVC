using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context; 
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        //Get/api/customers
        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customers;
        }

        //Get/api/customers/1 
        public Customer GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(x => x.Id == id);
            if (customer == null)
            {
                throw new HttpRequestException(HttpStatusCode.NotFound.ToString());
            }
            return customer;
        }

        //Post /api/customers 
        [HttpPost]
        public Customer CreateCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpRequestException(HttpStatusCode.BadRequest.ToString());
            }
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return customer;
        }


        //Put /api/customers/1 
        [HttpPut] 
        public void UpdateCustomer(int id, Customer customer)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpRequestException(HttpStatusCode.BadRequest.ToString());
            }
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
            {
                throw new HttpRequestException(HttpStatusCode.NotFound.ToString());
            }

            //can use auto mapper in the future 
            customerInDb.Name = customer.Name;
            customerInDb.BirthDate = customer.BirthDate;
            customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
            customerInDb.MembershipTypeId = customer.MembershipTypeId;
            _context.SaveChanges();
        }

        //Delete /api/customers/1 
        public void DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
            {
                throw new HttpRequestException(HttpStatusCode.NotFound.ToString());
            }
            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();

        }
    }
}
