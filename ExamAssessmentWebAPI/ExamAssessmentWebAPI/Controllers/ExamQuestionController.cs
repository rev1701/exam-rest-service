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
    /// <summary>
    /// Controller that will handle the responsibilities of all things related to an ExamQuestion.
    /// </summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ExamQuestionController : ApiController
    {
        WCF.Service1Client client = new WCF.Service1Client(); //Readonly suggested

        #region TODO

        // TODO:complete methods inside this region.
        // TODO:Add NLog to each method inside the entire controller (not just this region).  Each Controller should have its own log file
        // TODO:Add Unit Tests for each method inside this controller.  There is already a Unit Test Library in this project with a class already made for this controller
        // TODO: Add a new Method that will return a list of questions that belong under a certain subject

        /// TODO: Test This Method: Unsure of Results
        /// <summary>
        ///  Method will return subjects related to a specific question
        /// </summary>
        /// <param name="questionID">string ExamQuestionID</param>
        /// <endpoint>[HttpGet]: api/ExamQuestion/GetSpecificQuestionSubjects/{id}</endpoint>
        /// <returns>HTTP Response message along with JSON result of the Subject List< </returns>
        [HttpGet]
        [ActionName("GetSpecificQuestionSubjects")]
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

        /// TODO: further testing requried on this method.  Not always excepting question object in request body.
        /// <summary>
        ///  Method should post an entire brand new question to the database.  Including adding in the subquestions and answers.
        /// </summary>
        /// <param name="question">ExamQuestion Object in Request Body</param>
        /// <endpoint>[HttpPost]: api/ExamQuestion</endpoint>
        /// <returns>HTTP Response on success or failure of the method</returns>
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

        /// TODO:function not working yet, requires refactoring
        /// <summary>
        ///  Function will change what the correct answer is assigned to the ExamQuestion
        /// </summary>
        /// <param name="questionID">string questionID</param>
        /// <param name="value">Answer Object From Request Body</param>
        /// <endpoint> [HttpPut]: api/ExamQuestion/ChangeCorrectAnswer/id</endpoint>
        /// <returns>HTTP Response on success or failure of the method </returns>
        [HttpPut]
        [ActionName("ChangeCorrectAnswer")]
          public HttpResponseMessage ChangeCorrectAnswer([FromUri]string questionID, [FromBody]Answer value)
        {
            try
            {
                if (questionID == null || questionID == "" || value == null)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid Input");
                }
                return Request.CreateResponse(HttpStatusCode.OK, "");

               }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        /// TODO: Method is not tested and requires refactoring
        /// <summary>
        ///  method will add an existing category to an existing exam question
        /// </summary>
        /// <param name="Category">string Category Name</param>
        /// <param name="ExamQuestionID">string ExamQuestionID</param>
        /// <endpoint>[HttpPost]: api/ExamQuestion/AddCategoryToQuestoin/id</endpoint>
        /// <returns>returns HTTP Response message on success or failure</returns>
        [HttpPost]
        [ActionName("AddCategoryToQuestion")]
        public HttpResponseMessage AddCategoryToQuestion([FromUri]string Category, [FromUri]string ExamQuestionID)
        {
            try
            {
                if (Category == null || Category == "" || ExamQuestionID == "" || ExamQuestionID == null)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid input");
                }

                //   client.addQuestionCategories(Category, ExamQuestionID);    

                return Request.CreateResponse(HttpStatusCode.OK);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        /// TODO:Method needs testing and possible refactoring
        /// <summary>
        ///  will remove an existing category from an existing question
        /// </summary>
        /// <param name="ExamQuestionID"></param>
        /// <param name="category"></param>
        /// <endpoint>[HttpPut]: api/RemoveCategoryFromQuestion/{id}</endpoint>
        /// <returns>Returns HTTP Response on success or failure</returns> 
        [HttpPut]
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

        /// TODO:Method incomplete
        /// <summary>
        ///   Method will delete an exam question given the ExamQuestionID
        /// </summary>
        /// <param name="questionID">string QuestionID</param>
        /// <endpoint>[HttpDelete]api/ExamQuestion/{id}</endpoint>
        /// <returns></returns>
        [HttpDelete]
        public HttpResponseMessage Delete(string questionID)
        {
            try
            {
                if (questionID == null || questionID == "")
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid Input");
                }

                return Request.CreateResponse(HttpStatusCode.OK, "");
               }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

        }

        #endregion TODO

        /// <summary>
        ///  Method will return a list of all ExamQuestionIDs in the database
        /// </summary>
        /// <endpoint>[HttpGet]: api/ExamQuestion/GetExamQuestionIDs</endpoint>
        /// <returns>HTTP Response message along with JSON result of the ExamQuestionIDs</returns>
        [HttpGet]
        [ActionName("GetExamQuestionIDs")]
        public HttpResponseMessage GetAllExamQuestionIDs()
        {
            List < WCF.ExamQuestion > examQ = client.GetAllExamQuestion().ToList();
            List<String> result = new List<string>();
            for(int i = 0; i < examQ.Count; i++)
            {
                result.Add(examQ.ElementAt(i).ExamQuestionID);
            }
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        /// <summary>
        ///  returns a list of all ExamQuestions in the database
        /// </summary>
        /// <endpoint>[HttpGet]: api/ExamQuestion/GetAllExamQuestions</endpoint>
        /// <returns>HTTP Response message along with JSON result of the ExamQuestion List</returns>
        [HttpGet]
        [ActionName("GetAllExamQuestions")]
        public HttpResponseMessage GetAllExamQuestions()
        {
            try
            {
                List<WCF.ExamQuestion> examQuestionList = client.GetAllExamQuestion().ToList();
                if (examQuestionList == null || examQuestionList.Count <= 0)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }

                return Request.CreateResponse(HttpStatusCode.OK, examQuestionList);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        /// <summary>
        ///  Returns a specific exam question given an ExamQuestionID
        /// </summary>
        /// <param name="questionID">string ExamQuestionID</param>
        /// <endpoint>[HttpGet]: api/ExamTemplate/GetSpecificExamQuestion</endpoint>
        /// <returns>HTTP Response message along with JSON result of the ExamQuestion</returns>
        [HttpGet]
        [ActionName("GetSpecificExamQuestion")]
        public HttpResponseMessage GetSpecificExamQuestion(string questionID)
        {
            try
            {
              WCF.ExamQuestion examQuestion = GetSpecificExQuest(questionID);

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

        //returns a specific exam question, private method used inside public method
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
