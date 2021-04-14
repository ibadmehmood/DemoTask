using SchoolManagementSystem.Data;
using SchoolManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

using SchoolManagementSystem.Helpers;
namespace SchoolManagementSystem.Controllers
{
    [Authorize]
    public class StudentController : Controller
    {
        StudentService _studentService;
        public StudentController()
        {
            _studentService = new StudentService();
        }
        // GET: Student

        [Route("Student")]
        public JsonResult Index()
        {
            var students = _studentService.GetStudents();

            return new JsonResultWithStatusCode(students,HttpStatusCode.OK);
        }

        [HttpPost]
        [Route("Student")]
        public JsonResult CreateStudent(Student student)
        {
           
            if (ModelState.IsValid)
            {
                Student s=_studentService.InsertStudent(student);
                
                return new JsonResultWithStatusCode(s,HttpStatusCode.Created);
            }

            var errorList = (from item in ModelState.Values
                             from error in item.Errors
                             select error.ErrorMessage).ToList();

            return new JsonResultWithStatusCode(errorList,HttpStatusCode.BadRequest);
         
            
        }

        [HttpGet]
        [Route("Student/{studentid}")]
        public JsonResult GetStudentById(int studentid)
        {

            Student student = _studentService.GetStudent(studentid);
            if (student != null)
            {
                return new JsonResultWithStatusCode(student, HttpStatusCode.OK);
            }
            else
            {
                return new JsonResultWithStatusCode(student, HttpStatusCode.NotFound);
            }
       
        }

        [HttpGet]
        [Route("Student/Details/{studentid}")]
        public ActionResult GetStudentByIdView(int studentid)
        {

            ViewBag.studentid = studentid;

            return View("Details");

        }


        [HttpPost]
        [Route("Student/Edit/{studentid}")]
        public JsonResult EditStudentById(int studentid,Student student)
        {

            if (ModelState.IsValid)
            {
                Student s = _studentService.InsertStudent(student);

                return new JsonResultWithStatusCode(s, HttpStatusCode.Created);
            }

            var errorList = (from item in ModelState.Values
                             from error in item.Errors
                             select error.ErrorMessage).ToList();

            return new JsonResultWithStatusCode(errorList, HttpStatusCode.BadRequest);

        }

        //student/studentid/qualification

        [HttpGet]
        [Route("Student/{studentid}/Qualification")]
        public JsonResult GetStudentQualification(int studentid)
        {

            List<Qualification> qualifications = _studentService.GetQualifications(studentid);
            if (qualifications.Count>0)
            {
                return new JsonResultWithStatusCode(qualifications, HttpStatusCode.OK);
            }
            else
            {
                return new JsonResultWithStatusCode(qualifications, HttpStatusCode.NotFound);
            }

        }

        [HttpPost]
        [Route("Student/{studentid}/Qualification")]
        public  JsonResult AddStudentQualification(int studentid,Qualification qualification)
        {

            if (ModelState.IsValid)
            {
                _studentService.InsertQualification(qualification);
               
                return new JsonResultWithStatusCode(qualification, HttpStatusCode.Created);
            }
            var errorList = (from item in ModelState.Values
                             from error in item.Errors
                             select error.ErrorMessage).ToList();

            return new JsonResultWithStatusCode(errorList, HttpStatusCode.BadRequest);

        }

        [HttpPost]
        [Route("Student/{studentid}/Qualification/{qualificationid}")]
        public JsonResult DeleteQualificationById(int studentid,int qualificationid)
        {

            bool isDeleted=_studentService.DeleteQualification(qualificationid);

            if (isDeleted)
            {
                var message = new { Data = "Deleted Successfully " };
               return  new JsonResultWithStatusCode(message, HttpStatusCode.OK);
            }
            else
            {
                var message = new {
                    data="Coult not be delete "
                    };
             return    new JsonResultWithStatusCode(message, HttpStatusCode.BadRequest);
            }

        }

        [HttpGet]
        [Route("Student/{studentid}/Qualification/{qualificationid}")]
        public string EditStudentQualificationById(int studentid, int qualifcationid)
        {
            return "";
        }








    }




    }
