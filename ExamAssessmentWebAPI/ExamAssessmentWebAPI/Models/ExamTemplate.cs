using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMS1701.EA.Models
{
    public class ExamTemplate
    {
        public int PKID { get; set; }
        public string ExamTemplateName { get; set; }
        public string ExamTemplateID { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<ExamQuestion> ExamQuestions { get; set; }
        public ExamType Type { get; set; }
    }
}