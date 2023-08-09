using School_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace School_Project.Controllers
{
    public class StaffController : Controller
    {
        SchoolEntities stf=new SchoolEntities();
        public ActionResult Staff()
        {
            var data = stf.Staff.Select(x => new StaffViewModel()
            {
                Id= x.Id,
                Name= x.Name,
                Phone= x.Phone,
                Faculty= x.Faculty,
                Position= x.Position,
            }).ToList();
            return View(data);
        }
        [HttpGet]
        public ActionResult AddStaff()
        {
            return View();
        }
        public ActionResult Addstaff(StaffViewModel model)
        {
            Staff stff = new Staff()
            {
                Id = model.Id,
                Name = model.Name,
                Phone = model.Phone,
                Position = model.Position,
                Faculty = model.Faculty,
            };
            stf.Staff.Add(stff);
            stf.SaveChanges();
            return RedirectToAction("Staff");
        }
        [HttpGet]
        public ActionResult Edit(int id) 
        {
            var data = stf.Staff.Where(x => x.Id == id).Select(x => new StaffViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                Phone = x.Phone,
                Position = x.Position,
                Faculty = x.Faculty,
            }).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(StaffViewModel model)
        {
            var data=stf.Staff.Where(x=>x.Id==model.Id).FirstOrDefault();
            data.Position = model.Position;
            data.Id = model.Id;
            data.Name = model.Name;
            data.Faculty = model.Faculty;
            data.Phone= model.Phone;
            stf.Entry(data).State=System.Data.Entity.EntityState.Modified;
            stf.SaveChanges();
            return RedirectToAction("Staff");
        }
        [HttpGet]
        public ActionResult Delete(int id) 
        {
            var data = stf.Staff.Where(x => x.Id == id).Select(x => new StaffViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                Phone = x.Phone,
                Position = x.Position,
                Faculty = x.Faculty,
            }).FirstOrDefault(); 
            return View(data);
        }
        [HttpPost,ActionName("Delete")]
        public ActionResult DeleteConfirm(StaffViewModel model)
        {
            var data = stf.Staff.Where(x => x.Id == model.Id).FirstOrDefault();
            stf.Staff.Remove(data);
            stf.SaveChanges();
            return RedirectToAction("Staff");
        }
    }
}