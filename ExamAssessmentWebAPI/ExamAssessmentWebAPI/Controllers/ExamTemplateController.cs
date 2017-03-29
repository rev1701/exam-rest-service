using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using LMS1701.EA.Models;

namespace LMS1701.EA.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ExamTemplateController : ApiController
    { 

        // GET: api/ExamTemplate/5
        [HttpGet]
        [ActionName("GetExam")]
        public ExamTemplate Get(int id)
        {
            //Mock Data Exam Template
            ExamTemplate ex = new ExamTemplate();
            ex.ExamTemplateID = "Training_1";
            ex.ExamTemplateName = "Training Test";
            ex.PKID = 1;
            ex.Type = new ExamType();
            ex.Type.PKID = 1;
            ex.Type.ExamTypeName = "Training";
            ExamQuestion q1 = new ExamQuestion();
            QuestionType qt = new QuestionType();
            SubQuestion sq = new SubQuestion();
            Category ct = new Category();
            Subtopic st = new Subtopic();
            Answer ans = new Answer();
            LanguageType ltype = new LanguageType();
            Category cat = new Category();
            Subtopic sub = new Subtopic();
            qt.QuestionTypeName = "MultipleChoice";
            q1.Weight = 1;
                for (int i = 0; i < 10; i++)
                {
                    q1.ExamQuestionName = "Train" + Convert.ToString(i);
                    q1.ExamQuestionID = "T" + Convert.ToString(i);
                    q1.PKID = i;
                    qt.PKID = i;
                    q1.Type = qt;
                    sq.PKID = i;
                    sq.Description = "This is Question " + Convert.ToString(i);
                    for (int k = 0; k < 4; k++) {
                        ans.PKID = k;
                        ltype.Language = "Normal";
                        ltype.PKID = k;
                        ans.ProgrammingLanguage = ltype;
                        if (i == 0)
                            ans.DisplayedAnswer = "This is Answer A";
                        if (i == 1)
                            ans.DisplayedAnswer = "This is Answer B";
                        if (i == 2)
                            ans.DisplayedAnswer = "This is Answer C";
                        if (i == 3)
                            ans.DisplayedAnswer = "This is Answer D";
                        sq.Answers = new List<Answer>();
                        sq.Answers.Add(ans); 
                    }
                q1.QuestionList = new List<SubQuestion>();
                q1.QuestionList.Add(sq);
                cat.Categoryname = "C#";
                cat.PKID = i;
                sub.PKID = i;
                sub.SubtopicName = "ADO.NET";
                cat.SubTopics = new List<Subtopic>();
                cat.SubTopics.Add(sub);
                q1.QuestionCategories = new List<Category>();
                q1.QuestionCategories.Add(cat);
                ex.ExamQuestions = new List<ExamQuestion>();
                ex.ExamQuestions.Add(q1);
                }
            return ex;
        }

        //     // GETapi/ExamTemplate/GetExamSubjects/id
        [ActionName("GetExamSubjects")]
        public List<Subject> GetExamSubjects(int id)
        {
            return new List<Subject>();
        }


        // POST: api/ExamTemplate
        public void Post([FromBody]ExamTemplate exam)
        {
        }

        // PUT: api/ExamTemplate/5
        public void Put(int id, [FromBody] ExamQuestion question)
        {

        }

        // DELETE: api/ExamTemplate/5
        public void Delete(int id)
        {

        }
    }
}
