using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace School_Project.Models
{
    public class CourseViewModel
    {

        public int Id { get; set; }
        [DisplayName("Course Id")]
        public int C_Id { get; set; }
        [DisplayName("Course Name")]
        public string C_NAme { get; set; }

        [DisplayName("Credit Hour")]
        public Nullable<int> Credit_Hour { get; set; }

    }
}