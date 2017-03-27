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
    public class AnswerController : ApiController
    {
        // GET: api/Answer/id
        public IEnumerable<Answer> Get(int SubquestionID)
        {
            return new List<Answer>();
        }


        // POST: api/Answer
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Answer/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Answer/5
        public void Delete(int id)
        {
        }
    }
}
