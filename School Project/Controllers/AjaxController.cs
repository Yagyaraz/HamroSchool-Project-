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
        // GET: Ajax
        SchoolEntities _context = new SchoolEntities();
        public class AjaxViewModel
        {
            public int stffcount { get; set; }
        }
        public JsonResult GetReport()
        {
            AjaxViewModel result = new AjaxViewModel()
            {
                stffcount = _context.Staff.Count()
            };
            return Json(result,JsonRequestBehavior.AllowGet);
        }
    }
}