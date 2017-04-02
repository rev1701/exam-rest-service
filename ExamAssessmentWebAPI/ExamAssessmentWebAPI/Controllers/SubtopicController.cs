using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Cors;
using LMS1701.EA.Models;
using Newtonsoft.Json;
using WCF = ExamAssessmentWebAPI.ExamWCF;


namespace LMS1701.EA.Controllers
{ 
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    
    public class SubtopicController : ApiController
    {
        WCF.Service1Client client = new WCF.Service1Client();
        private MediaTypeWithQualityHeaderValue jsonMediaType = new MediaTypeWithQualityHeaderValue("application/json");

                                          // GET: api/Subtopic/
    public List<Subtopic> Get()
        {
            return null;
        }

        // POST: api/Subtopic
        public void Post([FromBody]string value, int CategoryId)
        {

        }

        // DELETE: api/Subtopic/5
        
        public void Delete(int SubtopicId)
        {
            
        }
    }
}
