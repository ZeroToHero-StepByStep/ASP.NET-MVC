
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;


namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;


        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        //Get: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };
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
            if (User.IsInRole(RoleName.CanManageMovie))
            {
                return View("List");
            }
            return View("ReadOnlyList");
        }

        public ActionResult Detail(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }


        [Authorize(Roles = RoleName.CanManageMovie)]
        public ActionResult New()
        {
//            var dateTime = Convert.ToDateTime("2017");
//            Movie movie = new Movie();
      
//            var viewModel = new MovieFormViewModel()
//            {
//                Genres = _context.Genres.ToList()
//            };
            var movieFormViewModel = new MovieFormViewModel()
            {
                Genres = _context.Genres.ToList()

            };
            return View("MovieForm" , movieFormViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save( Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var movieFormViewModel = new MovieFormViewModel(movie)
                {
                    Genres = _context.Genres.ToList() 
                };
                return View("MovieForm" , movieFormViewModel);
            }

            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(x => x.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;

            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(x => x.Id == id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            var movieFormViewModel = new MovieFormViewModel (movie) 
            {
                Genres = _context.Genres
            };
            return View("MovieForm", movieFormViewModel);
            //throw new NotImplementedException();
        }
    }
}