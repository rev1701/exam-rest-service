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
        //The beginning of every controller, make a Service Client to be able to use our SOAP service
        WCF.Service1Client client = new WCF.Service1Client(); //readonly suggeseted 

        // GET: api/Answer/id
        /// <summary>
        /// Gets a specific Subquestion's Answer List
        /// </summary>
        /// <param name="SubquestionID">QuestionID</param>
        /// <returns>The List of Answers correlating to that quesiton</returns>
        public List<Answer> Get(int SubquestionID)
        { 
            var results = client.GetAnswersQuestion(SubquestionID).ToList(); // makes a call to the client SOAP method GetAnswersQuestion and converts the result to a List of WCF model type Answers
            List<Answer> ans = new List<Answer>(); //Make an Empty Answer model list to store the answer
            foreach(WCF.Answers item in results) //For each answer in the list of WCF.Answers
            {
                Answer a = new Models.Answer(); //Make an empty Answer object
                a.DisplayedAnswer = item.Answer1; //stores the current answer description in the table to the empty answer object
                a.IsCorrect = item.correct.isCorrect; //stores the IsCorrect bit/bool
                a.PKID = item.PKID; //stores the answer PKID
                ans.Add(a); //Add the current Answer object that was recently filled to the List of answers that are going to be returned
            }
            return ans; //Return the list
        }


        // POST: api/Answer
        /// <summary>
        /// The Post method to add an answer and attach it to a question using the From body answer object and the question ID matched
        /// </summary>
        /// <param name="QuestionID">The Question ID of the question getting its answers editied</param>
        /// <param name="answer">The answer object in the FromBody</param>
        public void Post(int QuestionID, [FromBody]Answer answer)
        {
           client.AddAnswer(QuestionID, answer.DisplayedAnswer,answer.IsCorrect);  //Calls the AddAnswer SOAP method from the service
            
        }

        // PUT: api/Answer/5
        /// <summary>
        /// The Put method to edit an answer already attached to a question using the answer id and the actual value of the answer in the FromBody
        /// </summary>
        /// <param name="answerid">The answer id of the answer you want to edit</param>
        /// <param name="answer">the actual answer string in the FromBody</param>
        public void Put(int answerid, [FromBody]string answer)
        {
            client.UpdateAnswer(answerid, answer); //Calls the UpdateAnswer SOAP method from the service
        }

        // DELETE: api/Answer/5
        //TODO see SOAP DeleteAnswer Method
        //This should be changed to using the Answer ID to picking which answer to delete so that you dont have to match the answer string
        /// <summary>
        /// The Delete method to get rid of an answer based on using the answer description string
        /// </summary>
        /// <param name="answerdescription">the answer string</param>
        public void Delete(string answerdescription)
        {
           client.DeleteAnswer(answerdescription);  //Calls the DeleteAnswer SOAP method from the service
        }
    }
}
