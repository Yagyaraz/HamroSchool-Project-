using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace School_Project.Models
{
    public class StudentViewModel
    {
        public int Id { get; set; }
        [DisplayName("Roll No")]
        public int Roll_No { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Grade { get; set; }
        public string Course { get; set; }
    }
}