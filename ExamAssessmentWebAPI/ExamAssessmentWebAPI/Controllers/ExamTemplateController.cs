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
        
        
        
        [HttpGet]
        [ActionName("GetExam")]
        public WCF.ExamTemplate Get(string id)
        {
            var result = client.getExamTemplate(id);
            WCF.ExamTemplate template = client.getExamTemplate(id);
            return template;
        }
        [HttpGet]
        [ActionName("GetIDList")]
        public List<string> GetIDList()
        {
            return client.GetExamIDList().ToList();
        }
        

          // GETapi/ExamTemplate/GetExamSubjects/id

        [HttpGet]
        [ActionName("GetExamSubjects")]
        public HttpResponseMessage GetExamSubjects(String id)
        {

            //var results = client.GetAllSubject();

            List<WCF.Subject> sub = new List<WCF.Subject>();
            List<WCF.Subject> result = new List<WCF.Subject>();
            sub = client.GetAllSubject().ToList();
            WCF.ExamTemplate template = client.getExamTemplate(id);
            for (int i =0; i < template.ExamQuestions.Count(); i++ )
            {
                for(int j =0; j < template.ExamQuestions.ElementAt(i).ExamQuestion_Categories.Count(); j++)
                {
                    for(int k =0; k < sub.Count(); k++)
                    {
                        for(int jj =0; jj < sub.ElementAt(k).listCat.Count(); jj++)
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
            return Request.CreateResponse(HttpStatusCode.OK,result);
            
        }


        // POST: api/ExamTemplate
        [ActionName("AddExam")]
        public void Post([FromBody]WCF.ExamTemplate exam)
        {
            client.AddNewExam(exam.ExamTemplateName, exam.ExamTemplateID, exam.ExamType.ExamTypeName);
        }

        // PUT: api/ExamTemplate/5
        [ActionName("AddQuestionToExam")]
        public void Put(string extid, int weight, [FromBody] string exquesID)
        {
            client.spAddQuestionToExam(extid, exquesID, weight);
        }

        // DELETE: api/ExamTemplate/?extid=***&weight=**
        public void Delete(string ETID)
        {
            client.DeleteExam(ETID);
            
        }
    }
}
