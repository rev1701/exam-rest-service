﻿using System;
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
        WCF.Service1Client client = new WCF.Service1Client(); //readonly suggeseted

        // GET: api/Answer/id
        public List<Answer> Get(int SubquestionID)
        { 
            var results = client.GetAnswersQuestion(SubquestionID).ToList();
            List<Answer> ans = new List<Answer>();
            foreach(WCF.Answers item in results)
            {
                Answer a = new Models.Answer();
                a.DisplayedAnswer = item.Answer1;
                a.IsCorrect = item.correct.isCorrect;    
                a.PKID = item.PKID;
                ans.Add(a);
            }
            return ans;
        }


        // POST: api/Answer
        public void Post(int QuestionID, [FromBody]WCF.Answers answer)
        {
           client.AddAnswer(QuestionID, answer.Answer1,answer.correct.isCorrect);  //Calls the delete answer Update The Service Reference 
        }

        // PUT: api/Answer/5
        public void Put(int answerid, [FromBody]string answer)
        {
            client.UpdateAnswer(answerid, answer);
        }

        // DELETE: api/Answer/5
        public void Delete(string answerdescription)
        {
           client.DeleteAnswer(answerdescription);  
        }
    }
}
