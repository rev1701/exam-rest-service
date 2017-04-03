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
    public class AnswerController : ApiController
    {
        WCF.Service1Client client = new WCF.Service1Client();

        // GET: api/Answer/id
        public List<Answer> Get(int SubquestionID)
        { 
            var results = client.GetAnswersQuestion(SubquestionID).ToList();
            List<Answer> ans = new List<Answer>();
            foreach(WCF.Answers item in results)
            {
                Answer a = new Models.Answer();
                a.DisplayedAnswer = item.Answer1;
                a.IsCorrect = item.correct.isCorrect;    //UPDATE SERVICE REFEREENCE
                a.PKID = item.PKID;
                ans.Add(a);
            }
            return ans;
        }


        // POST: api/Answer
        public void Post(int QuestionID, [FromBody]string value)
        {
           //client.AddAnswer(QuestionID, Answer);  Calls the delete answer Update The Service Reference 
        }

        // PUT: api/Answer/5
        public void Put(int id, [FromBody]string value)
        {
            
        }

        // DELETE: api/Answer/5
        public void Delete(int id)
        {
            //client.DeleteAnswer(answerdesc);   Calls the delete answer Update the Service Reference
        }
    }
}
