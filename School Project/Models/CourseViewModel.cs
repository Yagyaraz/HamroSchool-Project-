using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace School_Project.Models
{
    public class CourseViewModel
    {

        public int Id { get; set; }
        public int C_Id { get; set; }
        public string C_NAme { get; set; }
        public Nullable<int> Credit_Hour { get; set; }

    }
}