﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
namespace LMS1701.EA.Controllers
{
    public class SubquestionController : ApiController
    {
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        // GET: api/Subquestion
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Subquestion/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Subquestion
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Subquestion/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Subquestion/5
        public void Delete(int id)
        {
        }
    }
}
