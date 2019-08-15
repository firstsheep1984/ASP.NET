using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    public class StudentsController : Controller
    {
        private IStudentRepository studentRepository;
        public StudentsController(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        public ActionResult Index()
        {
            var students = studentRepository.GetStudents();
            return View(students);
        }

        public ActionResult Create() {
            ViewBag.Title = "Create";
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Exclude ="StudentId")]Student student)
        {
            if (ModelState.IsValid)
            {
                studentRepository.CreateStudent(student);
                return RedirectToAction("Index");
            }
            return View(student);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.Title = "Edit";
            Student student = studentRepository.GetStudent(id);
            return View("Create", student);
        }

        public ActionResult DeleteConfirmation(int id) {
            Student student = studentRepository.GetStudent(id);
            return PartialView("_DeleteConfirmation",student);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            studentRepository.DeleteStudent(id);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            Student student = studentRepository.GetStudent(id);
            return View(student);
        }

        [HttpPost]
        public ActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                studentRepository.UpdateStudent(student);
                return RedirectToAction("Index");
            }
            return View("Create",student);
        }
    }
}