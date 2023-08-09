using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace School_Project.Models
{
    public class TeacherViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }
        public string Address { get; set; }
        public long Contact { get; set; }
    }
}