using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ExamAssessmentWebAPI.Controllers
{
    public class SubtopicController : ApiController
    {
        // GET: api/Subtopic
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Subtopic/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Subtopic
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Subtopic/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Subtopic/5
        public void Delete(int id)
        {
        }
    }
}
