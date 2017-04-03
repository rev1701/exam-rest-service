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
    public class ExamQuestionController : ApiController
    {
        WCF.Service1Client client = new WCF.Service1Client();

        // GET: api/ExamQuestion/GetQuestionSubjects/id
        [ActionName("GetQuestionCategories")]
        public List <Subject> GetQuestionCategories(string questionID)
        {
           /*var ques = client.GetAllQuestions().ToList(); not the right client call but will be implemented
            List<Subject> sub = new List<Subject>();
            foreach(var item in ques)
            {
                //Subject c = new Subject();
                //c.SubjectName = item.
            }
            */
            return new List<Subject>();
        }
        // GET: api/ExamQuestion
        public IEnumerable<ExamQuestion> Get()
        {
            /* Get all Exam Questions implementations needed var exques = client.().ToList();
            List<ExamQuestion> exqueslist = new List<ExamQuestion>();
            foreach (WCF.ExamQuestion item in exques)
            {
                Answer a = new Models.Answer();
                a.DisplayedAnswer = item.Answer1;
                a.IsCorrect = item.correct.isCorrect;
                a.PKID = item.PKID;
                //a.ProgrammingLanguage = item    to be implemented
                ans.Add(a);
            }

    */

            return new List<ExamQuestion>();
        }

        // GET: api/ExamQuestion/5
        public ExamQuestion Get(string questionID)
        {
            return new ExamQuestion();
        }

        // POST: api/ExamQuestion
        public void Post([FromBody]ExamQuestion question)
        {

        }

        // PUT: api/ExamQuestion/ChangeCorrectAnswer/id
        [ActionName("ChangeCorrectAnswer")]
        public void ChangeCorrectAnswer(string questionID, [FromBody]Answer value)
        {
        }
        //PUT: api/ExamQuestion/AddCategoryToQuestoin/id
        [ActionName("AddCategoryToQuestion")]
        public void AddCategoryToQuestion(string questionID, [FromBody]int categoryID)
        {
        }
        //PUT: api/RemoveCategoryFromQuestion/id
        [ActionName("RemoveCategoryFromQuestion")]
        public void RemoveCategoryFromQuestion(string questionID, [FromBody]int categoryID)
        {
        }


        // DELETE: api/ExamQuestion/5
        public void Delete(string questionID)
        {
        }
    }
}
