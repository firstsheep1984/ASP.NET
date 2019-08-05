using FirstMVCApp.Data;
using FirstMVCApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstMVCApp.Controllers
{
    public class PersonsController : Controller
    {
        // GET: Persons
        public ActionResult Index()
        {
            //   IList<Person> persons = new List<Person>();
            //  persons.Add(new Person(){ Name = "Victor", Age = 24});
            //  persons.Add(new Person() { Name = "Ana", Age = 23 });
            IList<Person> persons = Persons.GetPeople();
            return View(persons);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Person person)
        {
            // return View(person);
            Persons.GetPeople().Add(person);
            return RedirectToAction("Index");
        }

    }
}