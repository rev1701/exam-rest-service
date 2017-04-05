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

        // GET: api/ExamQuestion
        // return IEnumerable<ExamQuestion>
        [HttpGet]
        [ActionName("GetAllExamQuestions")]
        public List<WCF.ExamQuestion> GetAllExamQuestions()
        {
            return client.GetAllExamQuestion().ToList();
            //try
            //{
            //    List<WCF.ExamQuestion> examQuestionList = client.GetAllExamQuestion().ToList();
            //    if (examQuestionList == null || examQuestionList.Count <= 0)
            //    {
            //        return Request.CreateResponse(HttpStatusCode.BadRequest);
            //    }

            //    return Request.CreateResponse(HttpStatusCode.OK, examQuestionList);
            //}
            //catch (Exception ex)
            //{
            //    return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            //}
        }

        [HttpGet]
        [ActionName("GetSpecificExamQuestion")]
        [Route("GetSpecificExamQuestion/{questionID}")]
        // GET: api/ExamQuestion/5
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
        [Route("AddCategoryToQuestion/{questionID}/{categoryID}")]
        public HttpResponseMessage AddCategoryToQuestion([FromUri]string questionID, [FromUri]int categoryID)
        {
            try
            {
                if (questionID == null || questionID == "" || categoryID < 0)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid input");
                }

                client.spAddQuestionCategories(questionID, categoryID);

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
        [Route("RemoveCategoryFromQuestion/{questionID}/{categoryID}")]
        public HttpResponseMessage RemoveCategoryFromQuestion([FromUri]string questionID, [FromUri]string categoryID)
        {
            try
            {
                if (questionID == null || categoryID == null || questionID == "" || categoryID == "")
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid input");
                }

                client.spDeleteQuestionCategory(categoryID, questionID);

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
