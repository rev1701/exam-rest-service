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
    public class ExamSettingsController : ApiController
    {
        // GET: api/ExamSettings/GetExamTemplate
        [ActionName("GetExamTemplate")]
        public ExamTemplate GetExamTemplate([FromBody]ExamSettings settings)
        {
            return new ExamTemplate();
        }

        // GET: api/ExamSettings/GetSubjects
        [ActionName("GetSubjects")]
        public IEnumerable<Subtopic> GetSubjects([FromBody]ExamSettings settings)
        {
            List<Subtopic> templist = new List<Subtopic>();
            Subtopic temptopic = new Subtopic();
            temptopic.PKID = 1;
            temptopic.SubtopicName = "Test";
            templist.Add(temptopic);
            return templist;
        }
    }
}
