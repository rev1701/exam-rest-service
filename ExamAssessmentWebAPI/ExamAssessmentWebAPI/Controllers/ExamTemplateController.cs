using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using LMS1701.EA.Models;
using WCF = ExamAssessmentWebAPI.ExamWCF;

namespace LMS1701.EA.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ExamTemplateController : ApiController
    {
        WCF.Service1Client client = new WCF.Service1Client();
        
        
        // GET: api/ExamTemplate/Training_1
        [HttpGet]
        [ActionName("GetExam")]
        public ExamTemplate Get()
        {
            #region newMap
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
                sub.Subtopic_ID = i;
                sub.Subtopic_Name = "ADO.NET";
                cat.SubTopics = new List<Subtopic>();
                cat.SubTopics.Add(sub);
                q1.QuestionCategories = new List<Category>();
                q1.QuestionCategories.Add(cat);
                ex.ExamQuestions = new List<ExamQuestion>();
                ex.ExamQuestions.Add(q1);
                }
            return ex;
            
            #endregion
            
        }


        /*
        [HttpGet]
        [ActionName("GetExam")]
        public WCF.ExamTemplate Get(string id)
        {
            var result = client.getExamTemplate(id);
            WCF.ExamTemplate template = client.getExamTemplate(id);
            return template;
        }
        */

          // GETapi/ExamTemplate/GetExamSubjects/id
        [ActionName("GetExamSubjects")]
        public List<WCF.Subject> GetExamSubjects(String id)
        {

            //var results = client.GetAllSubject();

            List<WCF.Subject> sub = new List<WCF.Subject>();
            List<WCF.Subject> result = new List<WCF.Subject>();
            sub = client.GetAllSubject().ToList();
            WCF.ExamTemplate template = client.getExamTemplate(id);
            for (int i =0; i < template.ExamQuestions.Count(); i++ )
            {
                for(int j =0; j < template.ExamQuestions.ElementAt(i).ExamQuestion_Categories.Count(); j++)
                {
                    for(int k =0; k < sub.Count(); k++)
                    {
                        if(sub.ElementAt(k).listCat.Contains(template.ExamQuestions.ElementAt(i).ExamQuestion_Categories.ElementAt(j)))
                        {
                            if(!result.Contains(sub.ElementAt(k)))
                            {
                                result.Add(sub.ElementAt(k));
                            }
                        }
                    }
                }
            }
            return result;
            
        }


        // POST: api/ExamTemplate
        public void Post([FromBody]WCF.ExamTemplate exam)
        {
            //client.AddNewExam(exam.ExamTemplateName, exam.ExamTemplateID, exam.ExamType.ExamTypeName);
        }

        // PUT: api/ExamTemplate/5
        public void Put(string extid, int weight, [FromBody] WCF.ExamQuestion exques)
        {
            client.spAddQuestionToExam(extid, exques.ExamQuestionID, weight);
        }
        
        // DELETE: api/ExamTemplate/5
        public void Delete(string ETID)
        {
            //client.DeleteExam(ETID);
        }
    }
}
