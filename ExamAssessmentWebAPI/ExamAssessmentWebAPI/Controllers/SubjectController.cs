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
    public class SubjectController : ApiController
    {
        WCF.Service1Client client = new WCF.Service1Client();
        // GET: api/Subject
        public IEnumerable<WCF.Subject> Get()
        {
            List<WCF.Subject> test = new List<WCF.Subject>();

            foreach(var item in client.GetAllSubject())
            {
                test.Add(item);
            }
            return test;
        }

        // POST: api/Subject
        public void Post([FromBody]string value)
        {
        }

        // PUT:
        [ActionName("AddCategory")]
        public void AddCategory(int SubjectId, [FromBody]string value)
        {
        }

        // PUT:
        [ActionName("RemoveCategory")]
        public void RemoveCategory(int SubjectId, [FromBody]string value)
        {
        }

        // DELETE: api/Subject/5
        public void Delete(int SubjectId)
        {
        }
    }
}
