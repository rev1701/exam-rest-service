using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMS1701.EA.Models
{
    public class Answer
    {
        public int PKID { get; set; }
        public LanguageType ProgrammingLanguage { get; set; }
        public string DisplayedAnswer { get; set; }
        public bool IsCorrect { get; set; }
    }
}