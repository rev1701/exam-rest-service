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
    public class ExamQuestionController : ApiController
    {
        WCF.Service1Client client = new WCF.Service1Client(); //Readonly suggested


        /**
         *  Returns all of the subjects in a specific question
         **/

        
        [HttpGet]
        [ActionName("GetSpecificQuestionSubjects")]
        [Route("GetSpecificQuestionSubjects/{questionID}")]
        public HttpResponseMessage GetSpecificQuestionSubjects([FromUri] string questionID)
        {
            try
            {
                WCF.ExamQuestion examQuestion = GetSpecificExQuest(questionID);
                List<WCF.Subject> subjects = client.GetAllSubject().ToList();
                List<WCF.Subject> specificQuestionSubjects = null;

                if (examQuestion == null)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Not able to retrieve exam question");
                }

                if (subjects == null || subjects.Count <= 0)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Not able to retrieve Subjects");
                }


                foreach (WCF.Subject subject in subjects)
                {
                    foreach (WCF.Category cat in subject.listCat)
                    {
                        foreach (WCF.Category category in examQuestion.ExamQuestion_Categories)
                        {
                            if (cat.Categories_ID == category.Categories_ID)
                            {
                                specificQuestionSubjects.Add(subject);
                            }
                        }
                    }
                }

                return Request.CreateResponse(HttpStatusCode.OK, specificQuestionSubjects);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }


        /// <summary>
        /// This method gets the exam question ID's for all Exam Questions 
        /// </summary>
        /// <returns>HTTP Response Message</returns>
        [HttpGet]
        [ActionName("GetExamQuestionIDs")]
        public HttpResponseMessage GetAllExamQuestionIDs()
        {
            List < WCF.ExamQuestion > examQ = client.GetAllExamQuestion().ToList(); //make the client call for the service and store it in a list of exam questions
            List<String> result = new List<String>(); // make a new list of strings
            for(int i = 0; i < examQ.Count; i++) // loop through the list of WCF Exam Questions
            {
                result.Add(examQ.ElementAt(i).ExamQuestionID); // Add to the results list the current ExamQuestionID
            }
            return Request.CreateResponse(HttpStatusCode.OK, result); //Return Status code that it connected correctly and the result
        }
        
        /// <summary>
        /// Get Method to get all of the Exam Questions in the Database and returns a response code if it worked or not 
        /// </summary>
        /// <returns>HTTP Response Code</returns>
        [HttpGet]
        [ActionName("GetAllExamQuestions")]
        public HttpResponseMessage GetAllExamQuestions()
        {
            try
            {
                List<WCF.ExamQuestion> examQuestionList = client.GetAllExamQuestion().ToList(); // the client calls the ExamQuestionList Table and stores it as a list of ExamQuestion
                if (examQuestionList == null || examQuestionList.Count <= 0) // If the ExamQuestionList is null or if there are no elements in the list
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest); //Send back a bad request
                }

                return Request.CreateResponse(HttpStatusCode.OK, examQuestionList); //If not empty send back a good request with list of All Exam Questions
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message); //Some other error caught send bad request
            }
        }

        /// <summary>
        /// Get Method that returns a specific Exam Question using the ExamQuestionID
        /// </summary>
        /// <param name="questionID">ExamQuestionID</param>
        /// <returns>Http Response Message</returns>
        [HttpGet]
        [ActionName("GetSpecificExamQuestion")]
        
        public HttpResponseMessage GetSpecificExamQuestion(string questionID)
        {
          //  return Request.CreateResponse(HttpStatusCode.OK);
            try
            {
              WCF.ExamQuestion examQuestion = GetSpecificExQuest(questionID); //Makes a WCF ExamQuestion object 

                if (examQuestion == null)
                {
                   return Request.CreateResponse(HttpStatusCode.BadRequest, "Exam question does not exist");
                }

                return Request.CreateResponse(HttpStatusCode.OK, examQuestion);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        // POST: api/ExamQuestion

        public HttpResponseMessage Post([FromBody]WCF.ExamQuestion question)
        {
            try
            {
                if (question.ExamQuestionID == null || question.ExamQuestionName == null || question.QuestionType == null)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid Exam Question");
                }

                client.AddExamQuestion(question);

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        // PUT: api/ExamQuestion/ChangeCorrectAnswer/id
        /*   [HttpPut]
           [ActionName("ChangeCorrectAnswer")]
           [Route("ChangeCorrectAnswer/{questionID}")]
           // GET: api/ExamQuestion/5
          public HttpResponseMessage ChangeCorrectAnswer([FromUri]string questionID, [FromBody]Answer value)
           {
               try
               {
                   if (questionID == null || questionID == "" || value == null)
                   {
                       return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid Input");
                   }
                               client.
                   //todo

               }
               catch (Exception ex)
               {
                   return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
               }
           }*/

        //POST: api/ExamQuestion/AddCategoryToQuestoin/id
        [HttpPost]
        [ActionName("AddCategoryToQuestion")]
      //  [Route("AddCategoryToQuestion/{questionID}/{categoryID}")]
        public HttpResponseMessage AddCategoryToQuestion([FromUri]string Category, [FromUri]String ExamQuestionID)
        {
            try
            {
                if (Category == null || Category == "" || ExamQuestionID =="" || ExamQuestionID == null)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid input");
                }

             //   client.addQuestionCategories(Category, ExamQuestionID);     update service reference

                return Request.CreateResponse(HttpStatusCode.OK);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        //DELETE: api/RemoveCategoryFromQuestion/id
        [HttpDelete]
        [ActionName("RemoveCategoryFromQuestion")]
        
        public HttpResponseMessage RemoveCategoryFromQuestion([FromUri]string ExamQuestionID, [FromUri]string category)
        {
            try
            {
                if (ExamQuestionID == null || category == null || ExamQuestionID == "" || category == "")
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid input");
                }

                //client.DeleteQuestionCategory(category, ExamQuestionID); Update service reference
                
                return Request.CreateResponse(HttpStatusCode.OK);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        // DELETE: api/ExamQuestion/5
        /*   public HttpResponseMessage Delete(string questionID)
           {
               try
               {
                   if (questionID == null || questionID == "")
                   {
                       return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid Input");
                   }

                   //todo
               }
               catch (Exception ex)
               {
                   return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
               }

           } */

        //returns a specific exam question
        private WCF.ExamQuestion GetSpecificExQuest(string questionID)
        {
            try
            {
                List<WCF.ExamQuestion> examQuestions = client.GetAllExamQuestion().ToList();

                if (examQuestions == null || examQuestions.Count <= 0)
                {
                    return null;
                }

                WCF.ExamQuestion examQuestion = examQuestions.FirstOrDefault(exQ => exQ.ExamQuestionID == questionID);

                return examQuestion;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
