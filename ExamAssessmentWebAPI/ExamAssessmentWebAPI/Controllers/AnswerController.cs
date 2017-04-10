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
        #region TODO

        // TODO: Test each method inside this controller
        // TODO: Change Return type to HTTPResponse
        // TODO:Add NLog to each method inside the entire controller (not just this region).  Each Controller should have its own log file
        // TODO:Add Unit Tests for each method inside this controller.  There is already a Unit Test Library in this project with a class already made for this controller
        // TODO: Add a new Method that will return a list of questions that belong under a certain subject
        #endregion TODO

        //The beginning of every controller, make a Service Client to be able to use our SOAP service
        WCF.Service1Client client = new WCF.Service1Client(); //readonly suggeseted 

        /// <summary>
        /// Gets a specific Subquestion's Answer List
        /// </summary>
        /// <param name="SubquestionID">int QuestionID (NOT Exam Question)</param>
        /// <endpoint>GET: api/Answer/id</endpoint>
        /// <returns>The List of Answers correlating to that quesiton</returns>
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

        /// <summary>
        /// The Post method to add an answer and attach it to a question using the From body answer object and the question ID matched
        /// </summary>
        /// <param name="QuestionID">The Question ID of the question getting its answers editied</param>
        /// <endpoint>POST: api/Answer</endpoint>
        /// <param name="answer">The answer object in the FromBody</param>
        /// <returns></returns>
        public void Post(int QuestionID, [FromBody]Answer answer)
        {
           client.AddAnswer(QuestionID, answer.DisplayedAnswer,answer.IsCorrect);  
            
        }
    
        /// <summary>
        /// The Put method to edit an answer already attached to a question using the answer id and the actual value of the answer in the FromBody
        /// </summary>
        /// <param name="answerid">The answer id of the answer you want to edit</param>
        /// <param name="answer">the actual answer string in the FromBody</param>
        /// <endpoint>PUT: api/Answer/5</endpoint>
        public void Put(int answerid, [FromBody]string answer)
        {
            client.UpdateAnswer(answerid, answer); //Calls the UpdateAnswer SOAP method from the service
        }

        /// TODO: This should be changed to using the Answer ID to picking which answer to delete so that you dont have to match the answer string.  Will need WCF refactoring.
        /// <summary>
        /// The Delete method to get rid of an answer based on using the answer description string
        /// </summary>
        /// <param name="answerdescription">the answer string</param>
        /// <endpoint>DELETE: api/Answer/5</endpoint>
        public void Delete(string answerdescription)
        {
           client.DeleteAnswer(answerdescription);  //Calls the DeleteAnswer SOAP method from the service
        }
    }
}
