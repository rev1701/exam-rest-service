using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMS1701.EA.Models
{
    public class Category
    {
        public int PKID { get; set; }
        public string Categoryname { get; set; }
        public List<Subtopic> SubTopics { get; set; }
    }
}