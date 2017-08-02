using System.Collections;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq ;
using System.Data.Entity ;
using System.Runtime.Caching;
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

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var customer = new Customer();
            var customerFormViewModel = new CustomerFormViewModel
            {
                MembershipTypes = membershipTypes,
                Customer = customer 
            };
            return View("CustomerForm",customerFormViewModel);
        }


        // Dbcontext is a disposable objet , so we need to dispose it properly
        // the proper way to dispose it is  to override dispose method
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Customers
        public ActionResult Index()
        {
// don't use this apporach blindly
// 1. increate memory consumption of your application 
// 2. lead to unnecessary complexity both in the architectural and code level , specially in ef sometimes 
// use it until u do the performance profiling and use it to display data , not to modify data.
//            if (MemoryCache.Default["Genres"] == null)
//            {
//                MemoryCache.Default["Genres"] = _context.Genres.ToList();
//            }
//
//            var genres = MemoryCache.Default["Genres"] as IEnumerable<Genre>;

            return View();
        }

        public ActionResult Detail(int id)
        {
            var customer = _context.Customers.Include( c => c.MembershipType ).SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }


        //if we change the type from ViewCustomreModel to Customer, MVC Framewrok is 
        //smarter enough to bind  this object to form data because all the keys in the 
        //form data have prefixs with customer, that's how model binding works 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var customerFormViewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return  View("CustomerForm", customerFormViewModel);
            }

            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                /*
                TryUpdateModel(customerInDb);
                this is the official approach in the official documment but this apporach 
                has some issues. First , it opens the seccurity holes , this approach updates 
                all properties in the customer. Sometimes we don't want users to update all 
                propertis. Only users some special pervilage should be able to update all properties
                Another issue is that in the TryUpdateModel , melicious user can modify reuqest data 
                and add addition key value pairs in form data. And this method will successfully update 
                all properties.
                Although there is one method to solve this problem , like this 
                TryUpdateModel(customerInDb, "" , new string[] { "Name" , "Email"}) 
                It introduces magic strings for example "Name" , "Email". If one day some propertis are 
                modfied , we need also need to change these magic strings. 
                The bottom line is that you should not bindly read all the data in the requset data and put 
                that into the objects. 
                */
                customerInDb.Name = customer.Name;
                customerInDb.BirthDate = customer.BirthDate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            var customerFormViewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            }; 
            return View("CustomerForm" , customerFormViewModel);
        }
    }
}