using System.Web.Mvc;
using System.Linq ;
using System.Data.Entity ;
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
            var viewModel = new CustomerFormViewModel
            {
                MembershipTypes = membershipTypes
            };

            return View("CustomerForm",viewModel);
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


        //if we change the type from ViewCustomreModel to Customer, MVC Framewrok is 
        //smater enough to bind  this object to form data because all the keys in the 
        //form data have prefixs with customer, that's how model binding works 
        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            _context.Customers.Add(customer);
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
            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            }; 
            return View("CustomerForm" , viewModel);
        }
    }
}