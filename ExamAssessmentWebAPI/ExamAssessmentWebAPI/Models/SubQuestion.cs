using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMS1701.EA.Models
{
    public class SubQuestion
    {
        public int PKID { get; set; }
        public string Description { get; set; }
        public List<Answer> Answers { get; set; }
    }
}