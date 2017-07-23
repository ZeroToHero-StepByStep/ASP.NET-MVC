using System.Web.Mvc;
using System.Linq ;
using System.Data.Entity ;
using Vidly.Models;

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

            return View();
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
            
            //when the following line is executed , EF is not going to query the database
            //this is called deffered execution , the query will execute when it iterates 
            //the customers object 
            var customers = _context.Customers.Include(c => c.MembershipType);  

            return View(customers);
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
        
    }
}