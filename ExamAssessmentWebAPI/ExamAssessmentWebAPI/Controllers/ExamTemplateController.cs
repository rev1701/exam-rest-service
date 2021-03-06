﻿using ExamAssessmentWebAPI.App_Start;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WCF = ExamAssessmentWebAPI.ExamWCF;

namespace LMS1701.EA.Controllers
{
    /// <summary>
    /// Controller that will handle the responsibilities of all things related to an ExamTemplate.
    /// </summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ExamTemplateController : ApiController
    {
        WCF.Service1Client client = new WCF.Service1Client();
        #region TODO
        /// <TODO>:Add NLog to each method inside the entire controller (not just this region).  Each Controller should have its own log file</TODO>
        /// <TODO>:Add Unit Tests for each method inside this controller.  There is already a Unit Test Library in this project with a class already made for this controller</TODO>
        #endregion TODO

        /// <summary>
        /// Method is supposed to return a list of Subjects related to a specified Exam
        /// </summary>
        /// <endpoint>api/ExamTemplate/GetExamSubjects/{id}</endpoint>
        /// <param name="id">ExamTemplateID</param>
        /// <returns>HTTP Response message along with JSON result of the Subject List</returns>
        [HttpGet]
        [ActionName("GetExamSubjects")]
        public HttpResponseMessage GetExamSubjects(string id)
        {
            try
            {
                List<WCF.Subject> sub = client.GetAllSubject().ToList();  // all the subjects
                List<WCF.Subject> result = new List<WCF.Subject>();  // the results of the subjects
                WCF.ExamTemplate template = client.getExamTemplate(id);

                foreach (var subject in sub)
                {
                    bool foundSubject = false;
                    foreach (var subjectcategory in subject.listCat)
                    {
                        foreach (var examquestion in template.ExamQuestions)
                        {
                            foreach (var category in examquestion.ExamQuestion_Categories)
                            {
                                if (subjectcategory.Categories_ID == category.Categories_ID)
                                {
                                    if (foundSubject == false)
                                    {
                                        result.Add(subject);
                                        foundSubject = true;
                                        NLogConfig.logger.Log(new LogEventInfo(LogLevel.Info, "WebAPILogger", $"{subject.Subject_Name} is a subject in the {id} exam template"));
                                    }
                                }
                            }
                        }
                    }
                }

                return Request.CreateResponse(HttpStatusCode.OK, result.Distinct().ToList());
            }
            catch (System.ServiceModel.FaultException ex)
            {
                NLogConfig.logger.Error(ex, "There is no exam template with this ID. Enter a correct exam template ID.");
                return Request.CreateResponse(HttpStatusCode.BadRequest, "There is no exam template with this ID. Enter a correct exam template ID.");
            }
            catch (Exception ex)
            {
                NLogConfig.logger.Error(ex, ex.Message);
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpGet]
        [ActionName("GetExamName")]
        public HttpResponseMessage GetExamName(string id)
        {
            try
            {
                string examname = client.getExamTemplate(id).ExamTemplateName;
                return Request.CreateResponse(HttpStatusCode.OK, examname);
            }catch(Exception ex)
            {
               return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }


        /// <summary>
        /// Method will allow you to input a ExamTemplateID and it will return a full Exam Template that matches that ID
        /// Exam Template will include all questions associated with it as well as each category attached to those questions.
        /// </summary>
        /// <param name="id">string examtemplateID (NOT PKID)</param>
        /// <endpoint>[HttpGet]:api/ExamTemplate/GetExam/{id}</endpoint>
        /// <returns>HTTP Response Message along with JSON Result of the Exam</returns>
        [HttpGet]
        [ActionName("GetExam")]
        public HttpResponseMessage Get(string id)
        {
            try
            {
                if (id == null || id == "")
                {
                    NLogConfig.logger.Error("Invalid examID");
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid examID");
                }

                WCF.ExamTemplate template = client.getExamTemplate(id);
                NLogConfig.logger.Log(new LogEventInfo(LogLevel.Info, "WebAPILogger", $"Retreived {id} exam template"));
                return Request.CreateResponse(HttpStatusCode.OK, template);
            }
            catch (System.ServiceModel.FaultException ex)
            {
                NLogConfig.logger.Error(ex, "This exam template does not exist.");
                return Request.CreateResponse(HttpStatusCode.BadRequest, "This exam template does not exist.");
            }
            catch (Exception ex)
            {
                NLogConfig.logger.Error(ex, ex.Message);
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

        }

        /// <summary>
        /// Returns a list of all of the ExamIDs in the database.  
        /// </summary>
        /// <endpoint>[HttpGet]: api/ExamTemplate/GetIDList</endpoint>
        /// <returns>HTTP Response Message along with JSON Rsult of the ExamID List</returns>
        [HttpGet]
        [ActionName("GetIDList")]
        public HttpResponseMessage GetIDList()
        {
            try
            {
                var ExamIdList = client.GetExamIDList().ToList();
                if (ExamIdList.Count <= 0 || ExamIdList == null)
                {
                    NLogConfig.logger.Error("Exam Id's Not Found");
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Exam Id's Not Found");
                }
                NLogConfig.logger.Log(new LogEventInfo(LogLevel.Info, "WebAPILogger", $"All the exam template IDs have been returned."));
                return Request.CreateResponse(HttpStatusCode.OK, ExamIdList);
            }
            catch (Exception ex)
            {
                NLogConfig.logger.Error(ex, ex.Message);
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        /// <summary>
        ///  Will post an exam to the database.  Will be a template with zero examQuestions
        /// </summary>
        /// <param name="exam">ExamTemplate Object in request body</param>
        /// <endpoint>[HttpPost]: api/ExamTemplate/AddExam</endpoint>
        /// <returns>HTTP Response method on success or failure</returns>
        [ActionName("AddExam")]
        public HttpResponseMessage AddExam([FromBody]WCF.ExamTemplate exam)
        {
            try
            {
                if (exam == null || exam.ExamTemplateID == null || exam.ExamTemplateID == "" || exam.ExamTemplateName == null || exam.ExamTemplateName == "")
                {
                    NLogConfig.logger.Error("Invalid Exam Template.");
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid Exam Template");
                }
                client.AddNewExam(exam.ExamTemplateName, exam.ExamTemplateID, exam.ExamType.ExamTypeName);
                NLogConfig.logger.Log(new LogEventInfo(LogLevel.Info, "WebAPILogger", $"{exam.ExamTemplateID} was added as an exam template."));
                return Request.CreateResponse(HttpStatusCode.OK, "Template Added");
            }
            catch (Exception ex)
            {
                NLogConfig.logger.Error(ex, "Invalid Exam Template");
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        /// <summary>
        ///  Method will remove a specified ExamQuestion from the ExamTemplate.
        /// </summary>
        /// <param name="extid">string ExamTemplateID</param>
        /// <param name="exquesID">string ExamQuestionID from Request Body</param>
        /// <endpoint>[HttpPut]: api/ExamTemplate/RemoveQuestionFromExam/?extid={id}</endpoint>
        /// <returns>Returns HTTP Response message on success or failure</returns>
        [HttpPut]
        [ActionName("RemoveQuestionFromExam")]
        public HttpResponseMessage RemoveQuestionFromExam(string extid, [FromBody] string exquesID)
        {
            try
            {
                if (extid == null || extid == "" || exquesID == "" || exquesID == null)
                {
                    NLogConfig.logger.Error("Invalid Parameters");
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid Parameters");
                }
                client.RemoveQuestionFromExam(extid, exquesID);
                NLogConfig.logger.Log(new LogEventInfo(LogLevel.Info, "WebAPILogger", $"Question {exquesID} was removed from exam {extid}."));
                return Request.CreateResponse(HttpStatusCode.OK, $"Question {exquesID} was removed from exam {extid}");
            }
            catch (Exception ex)
            {
                NLogConfig.logger.Error("Invalid Parameters");
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        /// <summary>
        ///  Method will add a specified existing ExamQuestion to the given ExamTemplate.  Will also set the Question Weight which is relative to the exam
        /// </summary>
        /// <param name="extid">string ExamTemplateID</param>
        /// <param name="weight">int weight (default should be 1)</param>
        /// <param name="exquesID">string ExamQuestionID (From Request Body)</param>
        /// <endpoint>[HttpPut]: api/ExamTemplate/AddQuestionToExam/?extid={id}&weight={num}</endpoint>
        /// <returns>HttpResponse Message on success or failure</returns>
        [HttpPut]
        [ActionName("AddQuestionToExam")]
        public HttpResponseMessage Put(string extid, int weight, [FromBody] string exquesID)
        {
            try
            {
                if (extid == null || extid == "" || weight == 0 || exquesID == null || exquesID == "")
                {
                    NLogConfig.logger.Error("Invalid Entries.");
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid Entries");
                }
                client.spAddQuestionToExam(extid, exquesID, weight);
                NLogConfig.logger.Log(new LogEventInfo(LogLevel.Info, "WebAPILogger", $"Question {exquesID} added to Exam {extid} with weight of {weight}."));
                return Request.CreateResponse(HttpStatusCode.OK, $"Question {exquesID} added to Exam {extid} with weight of {weight}");
            }
            catch (Exception ex)
            {
                NLogConfig.logger.Error("Invalid Entries.");
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

        }

        /// <summary>
        ///  Method will delete an exam template given an ExamTemplateID
        /// </summary>
        /// <param name="ETID">string ExamTemplateID</param>
        /// <endpoint>[HttpDelete]api/ExamTemplate/{id}</endpoint>
        /// <returns>HTTP Response message on success or failure</returns>
        [HttpDelete]
        public HttpResponseMessage Delete(string ETID)
        {
            try
            {
                if (ETID == null || ETID == "")
                {
                    NLogConfig.logger.Error("Invalid ID.");
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid ID");
                }
                client.DeleteExam(ETID);
                NLogConfig.logger.Log(new LogEventInfo(LogLevel.Info, "WebAPILogger", $"Exam {ETID} Deleted from database"));
                return Request.CreateResponse(HttpStatusCode.OK, $"Exam {ETID} Deleted from database");
            }
            catch (Exception ex)
            {
                NLogConfig.logger.Error("Invalid ID.");
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
