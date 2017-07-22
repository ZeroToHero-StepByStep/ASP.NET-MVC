using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult Index()
        {
           
//            var customerViewModel = new CustomerViewModel
//            {
//                Customers = GetCustomers() 
//            };
            var customers = GetCustomers();

            return View(customers);
        }

        public ActionResult Detail(int id)
        {
            var customer = GetCustomers().SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
            //return Content("id =" + id);
        }

        private List<Customer> GetCustomers()
        {
            var customers = new List<Customer>
            {
                new Customer {Name = "Jhon Smith", Id = 1},
                new Customer {Name = "Mary Williams", Id = 2}
            };
            return customers;
        }
    }
}