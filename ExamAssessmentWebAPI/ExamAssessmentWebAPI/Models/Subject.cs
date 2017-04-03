using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMS1701.EA.Models
{
    public class Subject
    {
        public int PKID { get; set; }
        public string SubjectName { get; set; }
        public List<Category> CategoryList { get; set; }
    }
}