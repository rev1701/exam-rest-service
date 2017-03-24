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
    public class CategoryController : ApiController
    {
        // GET: api/Category
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Category/5
        public string Get(int CategoryId)
        {
            return "value";
        }

        // POST: api/Category
        public void Post([FromBody]string value, int SubjectId)
        {
        }

        // PUT: api/Category/
        [ActionName("AddSubtopic")]
        public void Put(int CategoryId, [FromBody]string value)
        {
        }

        // PUT: api/Category/
        [ActionName("RemoveSubtopic")]
        public void Put(int CategoryId, [FromBody]string value)
        {
        }

        // DELETE: api/Category/5
        public void Delete(int CategoryId)
        {
        }
    }
}
