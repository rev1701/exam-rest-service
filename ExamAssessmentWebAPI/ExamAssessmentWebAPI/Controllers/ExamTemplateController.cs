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
    public class ExamTemplateController : ApiController
    {
        WCF.Service1Client client = new WCF.Service1Client();
        #region TODO
        // TODO:complete methods inside this region.
        // TODO:Add NLog to each method inside the entire controller (not just this region).  Each Controller should have its own log file
        // TODO:Add Unit Tests for each method inside this controller.  There is already a Unit Test Library in this project with a class already made for this controller
        /// <TODO>Currently not working properly.  Needs to be refactored. Only returning empty sets</TODO>
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

            //var results = client.GetAllSubject();

            List<WCF.Subject> sub = new List<WCF.Subject>();
            List<WCF.Subject> result = new List<WCF.Subject>();
            sub = client.GetAllSubject().ToList();
            WCF.ExamTemplate template = client.getExamTemplate(id);
            for (int i = 0; i < template.ExamQuestions.Count(); i++)
            {
                for (int j = 0; j < template.ExamQuestions.ElementAt(i).ExamQuestion_Categories.Count(); j++)
                {
                    for (int k = 0; k < sub.Count(); k++)
                    {
                        for (int jj = 0; jj < sub.ElementAt(k).listCat.Count(); jj++)
                        {
                            if (sub.ElementAt(k).listCat.ElementAt(jj).Categories_Name == template.ExamQuestions.ElementAt(i).ExamQuestion_Categories.ElementAt(j).Categories_Name)
                            {

                                result.Add(sub.ElementAt(k));

                            }
                        }

                    }
                }
            }
            List<WCF.Subject> tempR = new List<WCF.Subject>();
            tempR.AddRange(result);
            for (int lop = 0; lop < 20; lop++)
            {


                for (int kk = 0; kk < result.Count; kk++)
                {
                    for (int ll = kk + 1; ll < result.Count; ll++)
                    {
                        if (result.ElementAt(kk).Subject_Name == result.ElementAt(ll).Subject_Name)
                        {
                            result.RemoveAt(ll);
                        }
                    }

                }
            }
            return Request.CreateResponse(HttpStatusCode.OK, result);

        }

        #endregion TODO

        /// <summary>
        /// Method will allow you to input a ExamTemplateID and it will return a full Exam Template that matches that ID
        /// Exam Template will include all questions associated with it as well as each category attached to those questions.
        /// </summary>
        /// <param name="id">examtemplateID (NOT PKID)</param>
        /// <endpoint>[HttpGet]:api/ExamTemplate/GetExam/{id}</endpoint>
        /// <returns>HTTP Response Message along with JSON Result of the Exam</returns>
        [HttpGet]
        [ActionName("GetExam")]
        public HttpResponseMessage Get(string id)
        {
            try
            {
                WCF.ExamTemplate template = client.getExamTemplate(id);
                if (id == null || id == "")
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid examID");
                }

                return Request.CreateResponse(HttpStatusCode.OK, template);
            }
            catch (Exception ex)
            {
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
                if (ExamIdList.Count<=0 || ExamIdList==null)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest,"Exam Id's Not Found" );
                    
                }
                return Request.CreateResponse(HttpStatusCode.OK,ExamIdList);

            }catch(Exception ex)
            {

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
                if(exam==null || exam.ExamTemplateID==null||exam.ExamTemplateID==""||exam.ExamTemplateName==null||exam.ExamTemplateName=="")
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid Exam Template");
                }
                client.AddNewExam(exam.ExamTemplateName, exam.ExamTemplateID, exam.ExamType.ExamTypeName);
                return Request.CreateResponse(HttpStatusCode.OK,"Template Added");
            }
            catch (Exception ex)
            {
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
                if (extid==null||extid==""||exquesID==""||exquesID==null)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid Parameters");
                }
                client.RemoveQuestionFromExam(extid, exquesID);
                return Request.CreateResponse(HttpStatusCode.OK,$"Question {exquesID} removed from exam {extid}");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest,ex.Message);
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
                if (extid==null||extid=="" || weight==0||exquesID==null||exquesID=="")
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid Entries");
                }
                client.spAddQuestionToExam(extid, exquesID, weight);
                return Request.CreateResponse(HttpStatusCode.OK, $"Question {exquesID} added to Exam {extid} with weight of {weight}");
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
            
        }

        /// <summary>
        ///  Method will delete an exam template given an ExamTemplateID
        /// </summary>
        /// <param name="ETID">string ExamTemplateID</param>
        /// <endpoint>[HttpDelete]api/ExamTemplate/{id}</endpoint>
        /// <returns>HTTP Response message on success or failure</returns>
        public HttpResponseMessage Delete(string ETID)
        {
            try
            {
                if (ETID==null || ETID=="")
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid ID");
                }
                client.DeleteExam(ETID);
                return Request.CreateResponse(HttpStatusCode.OK, $"Exam {ETID} Deleted from database");
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
            
        }



    }
}
