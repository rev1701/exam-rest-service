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
            var allsubjects = client.GetAllSubject();
            foreach(var item in allsubjects)
            {
                test.Add(item);
            }
            return test;
        }

        // POST: api/Subject
        public void Post([FromBody]string SubjectName)
        {
            client.AddSubject(SubjectName);
        }

        // PUT:
        [ActionName("AddExistingCategory")]
        public void AddNewCategory(string SubjectName, [FromBody]string CategoryName)
        {
            client.spAddExistingCategory(SubjectName, CategoryName);
        }
           
        // PUT:
        [ActionName("RemoveCategory")]
        public void RemoveCategory(string SubjectName, [FromBody]string CategoryName)
        {
            client.RemoveCategoryFromSubject(CategoryName, SubjectName);
        }

        // DELETE: api/Subject/5
        public void Delete(string SubjectName)
        {
            client.DeleteSubject(SubjectName);
        }
    }
}
