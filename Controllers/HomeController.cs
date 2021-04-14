using SchoolManagementSystem.Data;
using SchoolManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolManagementSystem.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        StudentService _StudentService;

        public HomeController()
        {
            _StudentService = new StudentService();
        }
        public ActionResult Index()
        {
            /*
            List<Student> students = _StudentService.GetStudents();


            return View(students);
            */

            return View();

        }
        [HttpGet]
        
        public ActionResult Student(int id)
        {
            Student student = _StudentService.GetStudent(id);
            return View("Details",student);
        }

        [Route("~/Home/Student/Qualification/")]
        public ActionResult Qualifications(int Studentid)
        {
            

            return View();
        }


        
        public ActionResult Create(Student student)
        {


            return View(student);
        }

        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Student(Student student)
        {
            if (ModelState.IsValid)
            {
                _StudentService.InsertStudent(student);
            }
            else
            {
                return View(student);
            }

            return RedirectToAction("Index");

            
        }

        




    }
}