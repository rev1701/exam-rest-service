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
        //Controller that will handle everything related to Subject Controller
    {
        WCF.Service1Client client = new WCF.Service1Client(); //readonly suggested
                                                              // GET: api/Subject

        #region TODO
        // TODO:complete methods inside this region.
        // TODO:Add NLog to each method inside the entire controller (not just this region).  Each Controller should have its own log file
        // TODO:Add Unit Tests for each method inside this controller.  There is already a Unit Test Library in this project with a class already made for this controller


        #endregion
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

        // POST:
        [ActionName("AddExistingCategory")]
        public void AddNewCategory(string SubjectName, [FromBody]string CategoryName)
        {
            client.spAddExistingCategory(SubjectName, CategoryName);
        }
           
        // Delete:
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
