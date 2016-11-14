using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Vidly.BusinessLogic;
using Vidly.BusinessLogic.BusinessLogic.Api;
using Vidly.BusinessLogic.BusinessLogic.Factory.Cstomers;
using Vidly.BusinessLogic.Entities;
using Vidly.Context;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private IDataApi _dataApi;
        private ICustomerFactory _customerFactory;

        public CustomersController(IDataApi dataApi, ICustomerFactory customerFactory)
        {
            this._customerFactory = customerFactory;
            this._dataApi = dataApi;
        }
        // GET: Customer
        public async Task<ActionResult> Index(bool sortByName = false)
        {
            IEnumerable<Customer> retrivedData = await _dataApi.getCustomers();

            if (sortByName)
                return View(retrivedData.OrderBy(c => c.FirstName));

            return View(retrivedData);

        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(string FirstName, string LastName)
        {
            Customer customer = _customerFactory.createCustomer(FirstName, LastName);
            bool status = await _dataApi.addCustomer(customer);
            if (status)
                return RedirectToAction("Index", "Customers");

            ModelState.AddModelError("Error", "Error adding customer");
            return View();

        }

        public async Task<ActionResult> Details(int id)
        {
            IEnumerable<Customer> customers = await _dataApi.getCustomers();
            if (id >= customers.ToList().Count || id < 0)
                return HttpNotFound();
            var customer = customers.ElementAt(id);

            if (customer == null)
                return HttpNotFound();

            ;
            return View(customer);
        }
    }
}