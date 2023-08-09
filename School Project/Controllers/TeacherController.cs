using School_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace School_Project.Controllers
{
    public class TeacherController : Controller
    {
        SchoolEntities tch=new SchoolEntities();
        public ActionResult Teacher()
        {
            var data=tch.Teacher.Select(X=>new TeacherViewModel()
            {
                Id = X.Id,
                Name = X.Name,
                Contact=X.Contact,
                Subject=X.Subject,
                Address=X.Address,
            }).ToList();
            
            return View(data);
        }
        [HttpGet]
        public ActionResult AddTeacher()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddTeacher(TeacherViewModel model)
        {
            Teacher tech = new Teacher()
            {
                Id = model.Id,
                Address = model.Address,
                Name = model.Name,
                Contact = model.Contact,
                Subject = model.Subject,
            };
            tch.Teacher.Add(tech);
            tch.SaveChanges();
            return RedirectToAction("Teacher");

        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var tech = tch.Teacher.Where(x => x.Id == id).Select(x => new TeacherViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                Contact = x.Contact,
                Subject = x.Subject,
                Address = x.Address,
            }).FirstOrDefault();
            return View(tech);

        }
        [HttpPost]
        public ActionResult Edit(TeacherViewModel model)
        {
            var tech=tch.Teacher.Where(x=>x.Id==model.Id).FirstOrDefault();
            tech.Subject = model.Subject;
            tech.Address = model.Address;
            tech.Name=model.Name; 
            tech.Contact = model.Contact;
            tch.Entry(tech).State=System.Data.Entity.EntityState.Modified;
            tch.SaveChanges();
            return RedirectToAction("Teacher");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var tech = tch.Teacher.Where(x => x.Id == id).Select(x => new TeacherViewModel()
            {
                Name = x.Name,
                Contact = x.Contact,
                Subject = x.Subject,
                Address = x.Address,

            }).FirstOrDefault();
            return View(tech);
        }
        [HttpPost,ActionName("Delete")]
        public ActionResult DeleteConfirm(TeacherViewModel model)
        {
            var tech = tch.Teacher.Where(x => x.Id == model.Id).FirstOrDefault();
            tch.Teacher.Remove(tech);
            tch.SaveChanges();
            return RedirectToAction("Teacher");
        }
    }
}