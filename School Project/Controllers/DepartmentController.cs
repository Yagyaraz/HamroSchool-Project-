using School_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace School_Project.Controllers
{
    public class DepartmentController : Controller
    {
        SchoolEntities dpt = new SchoolEntities();
        public ActionResult Departments()
        {
            var data = dpt.Department.Select(x => new DepartmentViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                HOD = x.HOD,
                Contact = (long)x.Contact,
            }).ToList();
            return View(data);
        }
        [HttpGet]
        public ActionResult AddDepartment()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddDepartment(DepartmentViewModel x)
        {
            Department dprt = new Department()
            {
                Name = x.Name,
                HOD = x.HOD,
                Contact = x.Contact,
            };
            dpt.Department.Add(dprt);
            dpt.SaveChanges();
            return RedirectToAction("Departments");
        }
        public ActionResult Edit(int id)
        {
            var data = dpt.Department.Where(x => x.Id == id).Select(x => new DepartmentViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                HOD = x.HOD,
                Contact = (long)x.Contact,
            }).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(DepartmentViewModel model)
        {
            var data=dpt.Department.Where(x=>x.Id==model.Id).FirstOrDefault();

            data.Name = model.Name;
            data.HOD = model.HOD;
            data.Contact = model.Contact;
            dpt.Entry(data).State=System.Data.Entity.EntityState.Modified;
            dpt.SaveChanges();
            return RedirectToAction("Departments");
         
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var data = dpt.Department.Where(x => x.Id == id).Select(x=>new DepartmentViewModel()
            { Id = x.Id, Name = x.Name, HOD = x.HOD, Contact = (long)x.Contact }).FirstOrDefault();
            return View(data);
                

        }
        [HttpPost,ActionName("Delete")]
        public ActionResult DeleteConfirm(DepartmentViewModel model)
        {

            var data = dpt.Department.Where(x => x.Id == model.Id).FirstOrDefault();
            dpt.Department.Remove(data);
            dpt.SaveChanges();
            return RedirectToAction("Departments");
        }

    }
}