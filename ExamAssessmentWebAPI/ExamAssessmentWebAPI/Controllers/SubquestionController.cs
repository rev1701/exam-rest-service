using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using LMS1701.EA.Models;
using WCF = ExamAssessmentWebAPI.ExamWCF;

namespace LMS1701.EA.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class SubquestionController : ApiController
    {
       
        WCF.Service1Client client = new WCF.Service1Client(); //Suggested make readonly
        //Todo: All methods that do not have an http 
        //response type need to have a http response type
        /// <summary>
        /// Method will return a list of subtopics.
        /// </summary>
        /// <returns></returns>
        public List<WCF.Question> Get()
        {
            return client.GetAllQuestions().ToList();
        }

        
        // PUT: api/Subquestion/
        /// <summary>
        /// Adds in a new Question using the put method.
        /// </summary>
        /// <param name="SubquestionId"></param>
        /// <param name="value"></param>
        public void Put(int SubquestionId, [FromBody]Answer value)
        {
            client.spAddQuestionToAnswer(SubquestionId, value.PKID, value.IsCorrect);
        }
    }
}
