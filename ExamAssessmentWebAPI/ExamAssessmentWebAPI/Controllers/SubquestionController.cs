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
       
        WCF.Service1Client client = new WCF.Service1Client();
        #region ObsoleteCode
        // GET: api/Subquestion
        /* public List <SubQuestion>Get()
         {

             var sq = client.GetAllQuestions().ToList();
             List<SubQuestion> sqlist = new List<SubQuestion>();
             foreach(var item in sq)
             {
                 SubQuestion qy = new SubQuestion();
                 qy.Description = item.Description;
                 qy.PKID = item.PKID;
                 qy.Answers = new List<Answer>();
                 var sqanswers = item.Answers.ToList(); 
                 foreach(var ans in sqanswers)
                 {
                     Answer newans = new Answer();
                     newans.DisplayedAnswer = ans.Answer1;
                     newans.PKID = ans.PKID;
                     newans.IsCorrect = ans.correct.isCorrect;
                     qy.Answers.Add(newans);
                 }
                 sqlist.Add(qy);
             }

             return sqlist;
         }
         */
        #endregion
        public List<WCF.Question> Get()
        {
            return client.GetAllQuestions().ToList();
        }


        // PUT: api/Subquestion/
        public void Put(int SubquestionId, [FromBody]string value)
        {
        }
    }
}
