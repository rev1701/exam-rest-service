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
    public class ExamQuestionController : ApiController
    {
        // GET: api/ExamQuestion/GetQuestionSubjects/id
        [ActionName("GetQuestionSubjects")]
        public IEnumerable<Subject> GetQuestionSubjects(string questionID)
        {
            return new List<Subject>();
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
