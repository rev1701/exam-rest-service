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
        [ActionName("GetQuestionSubjects")]
        public List <WCF.Subject> GetQuestionSubjects(string questionID)
        {
            List <WCF.Subject> Subjects = new List <WCF.Subject>();
        
            //var results = client.();

            // return results.ToList<WCF.Subject>();
            return new List<WCF.Subject>();
        }
        // GET: api/ExamQuestion
        public IEnumerable<ExamQuestion> Get()
        {
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
