using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace School_Project.Models
{
    public class StaffViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public long Phone { get; set; }
        public string Faculty { get; set; }
        public string Position { get; set; }
    }
}