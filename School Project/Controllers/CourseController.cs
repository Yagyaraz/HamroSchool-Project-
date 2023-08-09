using School_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace School_Project.Controllers
{
    public class CourseController : Controller
    {
        SchoolEntities crs = new SchoolEntities();
        public ActionResult Course()
        {
            var data = crs.Course.Select(x => new CourseViewModel()
            {
                Id = x.Id,
                C_NAme=x.C_NAme,
                Credit_Hour=x.Credit_Hour,
                C_Id=x.C_Id,
            }).ToList();
            return View(data);
        }
        [HttpGet]
        public ActionResult AddCourse()
        {
            return View();

        }
        [HttpPost]
        public ActionResult AddCourse(CourseViewModel model)
        {
            Course course = new Course();
            course.Id = model.Id;
            course.C_Id = model.C_Id;
            course.C_NAme= model.C_NAme;
            course.Credit_Hour= model.Credit_Hour;
            crs.Course.Add(course);
            crs.SaveChanges();
            return RedirectToAction("Course");
        }
        [HttpGet]
        public ActionResult Edit(int id) 
        {
            var data=crs.Course.Where(x=>x.Id==id).Select(x => new CourseViewModel()
            {
                Id = x.Id,
                Credit_Hour = x.Credit_Hour,
                C_Id = x.C_Id,
                C_NAme = x.C_NAme,
            }).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(CourseViewModel model)
        {
            var data=crs.Course.Where(x=>x.Id==model.Id).FirstOrDefault();
            data.C_NAme = model.C_NAme;
            data.C_Id=model.C_Id;
            data.Id=model.Id;
            data.Credit_Hour= model.Credit_Hour;
            crs.Entry(data).State=System.Data.Entity.EntityState.Modified;
            crs.SaveChanges();
            return RedirectToAction("Course");

        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var data = crs.Course.Where(x => x.Id == id).Select(x => new CourseViewModel()
            {
                Id = x.Id,
                Credit_Hour = x.Credit_Hour,
                C_Id = x.C_Id,
                C_NAme = x.C_NAme,
            }).FirstOrDefault();
            return View(data);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(StudentViewModel model)
        {
            var data = crs.Course.Where(x => x.Id == model.Id).FirstOrDefault();
            crs.Course.Remove(data);
            crs.SaveChanges();
            return RedirectToAction("Course");
        }
    }
}