using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMS1701.EA.Models
{
    public class ExamQuestion
    {
        public int PKID { get; set; }
        public int Weight { get; set; }
        public string ExamQuestionName { get; set; }
        public string ExamQuestionID { get; set; }
        public QuestionType Type { get; set; }
        public List<SubQuestion> QuestionList { get; set; }
        public List<Category> QuestionCategories { get; set; }
    }
}