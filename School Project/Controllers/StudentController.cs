using School_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace School_Project.Controllers
{
    public class StudentController : Controller
    {
            SchoolEntities std = new SchoolEntities();
            public ActionResult Student()
            {
                var data = std.Student.Select(x => new StudentViewModel()
                {
                    Id = x.Id,
                    Roll_No = x.Roll_No,
                    Name = x.Name,
                    Age = x.Age,
                    Course = x.Course,
                    Grade = x.Grade,
                }).ToList();
                return View(data);
            }
        [HttpGet]
        public ActionResult AddStudent()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddStudent(StudentViewModel x)
        {
            Student stdnt = new Student()
            {
                Id = x.Id,
                Roll_No = x.Roll_No,
                Name = x.Name,
                Age = x.Age,
                Course = x.Course,
                Grade = x.Grade,
            };
            std.Student.Add(stdnt);
            std.SaveChanges();
            return RedirectToAction("Student");

        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data=std.Student.Where(x=>x.Id==id).Select(x=>new StudentViewModel()
            {
                Id = x.Id,
                Roll_No = x.Roll_No,
                Name = x.Name,
                Age = x.Age,
                Course = x.Course,
                Grade = x.Grade,

            }).FirstOrDefault();
            return View(data);  
        }
        [HttpPost]
        public ActionResult Edit(StudentViewModel model)
        {
            var data=std.Student.Where(x=>x.Id==model.Id).FirstOrDefault();
            data.Id = model.Id;
            data.Age = model.Age;
            data.Course = model.Course;
            data.Grade = model.Grade;   
            data.Name= model.Name;
            data.Roll_No = model.Roll_No;
            std.Entry(data).State = System.Data.Entity.EntityState.Modified;
            std.SaveChanges();
            return RedirectToAction("Student");

        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var data = std.Student.Where(x => x.Id == id).Select(x => new StudentViewModel()
            {
                Id = x.Id,
                Roll_No = x.Roll_No,
                Name = x.Name,
                Age = x.Age,
                Course = x.Course,
                Grade = x.Grade,

            }).FirstOrDefault();
            return View(data);
        }
        [HttpPost,ActionName("Delete")]
        public ActionResult DeleteConfirm(StudentViewModel model)
        {
            var data = std.Student.Where(x => x.Id == model.Id).FirstOrDefault();
            std.Student.Remove(data);
            std.SaveChanges();
            return RedirectToAction("Student");
        }
      
    }
}