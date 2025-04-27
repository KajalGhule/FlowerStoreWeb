using Microsoft.AspNetCore.Mvc;
using CRM;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static Google.Protobuf.Reflection.SourceCodeInfo.Types;
using System.Xml.Linq;


namespace StoreWeb.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(ILogger<CustomerController> logger)
        {
            _logger = logger;
        }
        

        public IActionResult Index()
        {
            List<Customer> customers = CustomerDBManager.GetAll();
            ViewData["allCustomers"] = customers;
            return View();
        }

        [HttpGet]
        public IActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Insert(int Customerid, string name, string email, string contact, string location, int age)
        {
            Customer customer = new Customer
            {
                Id = Customerid,
                Name = name,
                Email = email,
                ContactNumber = contact,
                Location = location,
                Age = age
            };
            bool status = CustomerDBManager.Insert(customer);
            if (status)
            {
                return RedirectToAction("Index", "Customer");
            }
            else
            {
                return RedirectToAction("Insert", "Customer");
            }

        }

    }
    }
