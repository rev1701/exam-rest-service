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
    public class SubjectController : ApiController
    {
        // GET: api/Subject
        public IEnumerable<string> Get()
        {
            return new List<Subject>();
        }

        // POST: api/Subject
        public void Post([FromBody]string value)
        {
        }

        // PUT:
        [ActionName("AddCategory")]
        public void Put(int SubjectId, [FromBody]string value)
        {
        }

        // PUT:
        [ActionName("RemoveCategory")]
        public void Put(int SubjectId, [FromBody]string value)
        {
        }

        // DELETE: api/Subject/5
        public void Delete(int SubjectId)
        {
        }
    }
}
