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

        // GET: api/Subtopic/
        public string Get()
        {
            return new List<Subtopic>();
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
