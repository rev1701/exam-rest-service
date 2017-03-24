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
        public ExamTemplate Get(int id)
        {
            return new ExamTemplate();
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
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ExamTemplate/5
        public void Delete(int id)
        {
        }
    }
}
