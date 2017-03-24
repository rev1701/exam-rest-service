using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
namespace LMS1701.EA.Controllers
{
    public class SubtopicController : ApiController
    {
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        // GET: api/Subtopic
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Subtopic/5
        public string Get(int Subtopicid)
        {
            return "value";
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
