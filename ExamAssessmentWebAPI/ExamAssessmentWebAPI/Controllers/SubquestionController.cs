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
    public class SubquestionController : ApiController
    {
       
        WCF.Service1Client client = new WCF.Service1Client();
        // GET: api/Subquestion
        // GET: api/Subquestion/5



        // PUT: api/Subquestion/
        public void Put(int SubquestionId, [FromBody]string value)
        {
        }
    }
}
