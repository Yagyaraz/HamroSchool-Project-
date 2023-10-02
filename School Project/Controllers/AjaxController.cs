using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace School_Project.Controllers
{
    public class AjaxController : Controller
    {
       
        SchoolEntities _context = new SchoolEntities();
        public class AjaxViewModel
        {
            public int studentcount { get; set; }
            public int coursecount { get; set; }
            public int teachercount { get; set; } 

            public int staffcount { get; set; }
            public int departmentcount {  get; set; }
        }
        public JsonResult GetReport()
        {
            AjaxViewModel result = new AjaxViewModel()
            {
                staffcount = _context.Staff.Count(),
                coursecount= _context.Course.Count(),   
                teachercount= _context.Teacher.Count(), 
                studentcount= _context.Student.Count(),
                departmentcount= _context.Department.Count(),
            };
            return Json(result,JsonRequestBehavior.AllowGet);
        }
    }
}