using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web.Mvc;
using Microsoft.Win32;
using MvcPartialViewResultDemo.Models;

namespace MvcPartialViewResultDemo.Controllers
{
    public class CustomerController : Controller
    {
        #region ActionMethods

        // GET: Customer
        public ActionResult Index()
        {
            var customerDetails = GetCustomerDetails();
            return View(customerDetails);
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            var customerModel = GetCustomerById(id);
            return View(customerModel);
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                var customerModel = new CustomerModel
                {
                    CustmerId =  5, //Get the max+1 from customer list
                    CustomerName = collection["CustomerName"],
                    PermanantAddress = new CustomerAddress()
                    {
                        DoorNumber = collection["DoorNumber"].Split(',')[0],
                        City = collection["City"].Split(',')[0],
                        State = collection["State"].Split(',')[0],
                        PinNumber = collection["PinNumber"].Split(',')[0]
                    },
                    PresentAddress = new CustomerAddress()
                    {
                        DoorNumber = collection["DoorNumber"].Split(',')[1],
                        City = collection["City"].Split(',')[1],
                        State = collection["State"].Split(',')[1],
                        PinNumber = collection["PinNumber"].Split(',')[1]
                    }
                };
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            var customerModel = GetCustomerById(id);
            return View(customerModel);
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            
            try
            {
                var customerModel = new CustomerModel
                {
                    CustomerName = collection["CustomerName"],
                    PermanantAddress = new CustomerAddress()
                    {
                        DoorNumber = collection["DoorNumber"].Split(',')[0],
                        City = collection["City"].Split(',')[0],
                        State = collection["State"].Split(',')[0],
                        PinNumber = collection["PinNumber"].Split(',')[0]
                    },
                    PresentAddress = new CustomerAddress()
                    {
                        DoorNumber = collection["DoorNumber"].Split(',')[1],
                        City = collection["City"].Split(',')[1],
                        State = collection["State"].Split(',')[1],
                        PinNumber = collection["PinNumber"].Split(',')[1] 
                    }
                };

                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            var customerModel = GetCustomerById(id);
            return View(customerModel);
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                if (id > 0)
                {
                    // TODO: Add delete logic here
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        #endregion

        #region Methods

        public List<CustomerModel> GetCustomerDetails()
        {
            var customerList = new List<CustomerModel>();
            for (int i = 1; i <= 2; i++)
            {
                var customer = new CustomerModel
                {
                    CustmerId = i,
                    CustomerName = string.Concat("Customer", i),
                    PermanantAddress = new CustomerAddress()
                    {
                        DoorNumber = string.Concat("Permanent-D.No:4-xx-", i),
                        City = string.Concat("Permanent-City", i),
                        State = string.Concat("Permanent-State", i),
                        PinNumber = string.Concat("Permanent-Pin", i)
                    },
                    PresentAddress = new CustomerAddress()
                    {
                        DoorNumber = string.Concat("Present-D.No:4-xx-", i),
                        City = string.Concat("Present-City", i),
                        State = string.Concat("Present-State", i),
                        PinNumber = string.Concat("Present-Pin", i)
                    }
                };
                customerList.Add(customer);
            }

            return customerList;
        }


        public CustomerModel GetCustomerById(int customerId)
        {
            var customerDetails = GetCustomerDetails();

            var customer = (from cust in customerDetails
                where cust.CustmerId == customerId
                select cust).FirstOrDefault();
            return customer;
        }

        #endregion
    }
}
