using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
namespace LMS1701.EA.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ExamQuestionController : ApiController
    {
        // GET: api/ExamQuestion
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/ExamQuestion/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ExamQuestion
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ExamQuestion/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ExamQuestion/5
        public void Delete(int id)
        {
        }
    }
}
