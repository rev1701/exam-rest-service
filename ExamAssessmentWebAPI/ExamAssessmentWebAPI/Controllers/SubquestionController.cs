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
    public class SubquestionController : ApiController
    {
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        // GET: api/Subquestion
        // GET: api/Subquestion/5



        // PUT: api/Subquestion/
        public void Put(int SubquestionId, [FromBody]string value)
        {
        }
    }
}
