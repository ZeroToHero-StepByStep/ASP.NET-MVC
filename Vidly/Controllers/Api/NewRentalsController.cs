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
          
            var customer = _context.Customers.Single(c => c.Id == newRentalDto.CustomerId);
            var movies = _context.Movies.Where(m => newRentalDto.MovieIds.Contains(m.Id)).ToList();
            foreach (var movie in movies)
            {
                //to prevent malicious user
                if (movie.NumberAvailable == 0)
                {
                    return BadRequest("There is no available movie");
                }
                movie.NumberAvailable--;
                var rental = new Rental
                {
                    MovieId = movie.Id,
                    CustomerId = customer.Id ,
                    DateRented = DateTime.Now
                };
                _context.Rentals.Add(rental);
//                _context.Movies.
            }
            //the reason there we don't use the Create method becuase we don't create a single newly 
            //object, we created multiple objects. When we use the Create method, we need to create a 
            //Uri for the newly create objects , but here we have multiple objects
            _context.SaveChanges();
            return Ok();

        }



    }
}
