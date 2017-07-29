using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Vidly.Dtos;
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
        public IEnumerable<CustomerDto> GetCustomers()
        {
            return _context.Customers.ToList().Select(Mapper.Map<Customer,CustomerDto>);
        }

        //Get/api/customers/1
        [HttpGet] 
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(x => x.Id == id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(Mapper.Map<Customer, CustomerDto>(customer));
        }

        //Post /api/customers 
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            
            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();
            customerDto.Id = customer.Id;
            return Created(new Uri(Request.RequestUri +"/" + customer.Id), customerDto);
        }


        //Put /api/customers/1 
        [HttpPut] 
        public IHttpActionResult UpdateCustomer(int id, CustomerDto customerDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
            {
                return NotFound();
            }
            //for the previous example , we didn't pass the second arguement in Map method ,
            //but if we have an existing instance in db , we can map it directly without assigning values
            //one by one 
            var customer = Mapper.Map<CustomerDto, Customer>(customerDto, customerInDb); 
            //can use auto mapper in the future 
//            customerInDb.Name = customerDto.Name;
//            customerInDb.BirthDate = customerDto.BirthDate;
//            customerInDb.IsSubscribedToNewsLetter = customerDto.IsSubscribedToNewsLetter;
//            customerInDb.MembershipTypeId = customerDto.MembershipTypeId;
            _context.SaveChanges();
            return Ok();
        }

        //Delete /api/customers/1 
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
            {
                return NotFound();
            }   
            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
            return Ok();
        }
    }
}
