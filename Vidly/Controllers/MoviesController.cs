using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;


namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        
        //Get: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() {Name = "Shrek!"};
            //One way to pass data to the view is ViewData dictionary 
            var customers = new List<Customer>
            {
                new Customer {Name = "Customer1"},
                new Customer {Name = "Customer2"}
            };
            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };
            return View(viewModel);
          
        }


        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate( int year , int month )
        {
            return Content(year +"/" + month);
        }


        public ActionResult Index()
        {
            MovieViewModel movies = new MovieViewModel()
            {
                Movies = GetMovies()
            };
            return View(movies);
        }

        public ActionResult Detail(int id)
        {
            var movie = GetMovies().SingleOrDefault(c => c.Id == id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }


 

        private List<Movie> GetMovies()
        {
            var movies = new List<Movie>
            {
                new Movie {Name = "Shrek", Id = 1},
                new Movie {Name = "Wall-e", Id = 2}

            };
        
            return movies;

        }
        
    }
}