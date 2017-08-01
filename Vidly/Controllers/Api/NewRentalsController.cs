using System;
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
    public class NewRentalsController : ApiController
    {
        private ApplicationDbContext _context;

        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }


        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRentalDto)
        {
            //the reason that we use the Single method becuase that we assume that the client will send 
            //the right customerId, and the staff member will select customerId from a pick list or something 
            //If a melicious user wants to send us invalid customerId , the Single method will get an exception
            //and the melicious user will get a vague internal server error in the response
            //If you are building a public API that can be used by various applications that's a different story
            //then you will use SingleOrDefault
            var customer = _context.Customers.Single(c => c.Id == newRentalDto.CustomerId);
            var movies = _context.Movies.Where(m => newRentalDto.MovieIds.Contains(m.Id));
            foreach (var movie in movies)
            {
                var rental = new Rental
                {
                    MovieId = movie.Id,
                    CustomerId = customer.Id ,
                    DateRented = DateTime.Now
                };
                _context.Rentals.Add(rental);
            }
            //the reason there we don't use the Create method becuase we don't create a single newly 
            //object, we created multiple objects. When we use the Create method, we need to create a 
            //Uri for the newly create objects , but here we have multiple objects
            _context.SaveChanges();
            return Ok();

        }



    }
}
