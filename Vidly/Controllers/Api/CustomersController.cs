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
        public CustomerDto GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(x => x.Id == id);
            if (customer == null)
            {
                throw new HttpRequestException(HttpStatusCode.NotFound.ToString());
            }
            return Mapper.Map<Customer, CustomerDto>(customer);
        }

        //Post /api/customers 
        [HttpPost]
        public CustomerDto CreateCustomer(CustomerDto customerDto)
        {
            
            if (!ModelState.IsValid)
            {
                throw new HttpRequestException(HttpStatusCode.BadRequest.ToString());
            }
            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();
            customerDto.Id = customer.Id;
            return customerDto;
        }


        //Put /api/customers/1 
        [HttpPut] 
        public void UpdateCustomer(int id, CustomerDto customerDto)
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
