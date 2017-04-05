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
        WCF.Service1Client client = new WCF.Service1Client(); // Readonly suggested
              
        [HttpGet]
        [ActionName("GetExam")]
        public WCF.ExamTemplate Get(string id)
        {
            WCF.ExamTemplate template = client.getExamTemplate(id);
            return template;
        }
        
          // GETapi/ExamTemplate/GetExamSubjects/id
        [ActionName("GetExamSubjects")]
        public List<WCF.Subject> GetExamSubjects(String id)
        {

            List<WCF.Subject> sub = new List<WCF.Subject>();
            List<WCF.Subject> result = new List<WCF.Subject>();
            sub = client.GetAllSubject().ToList();
            WCF.ExamTemplate template = client.getExamTemplate(id);
            for (int i =0; i < template.ExamQuestions.Count(); i++ )
            {
                for(int j =0; j < template.ExamQuestions.ElementAt(i).ExamQuestion_Categories.Count(); j++)
                {
                    for(int k =0; k < sub.Count; k++)
                    {
                        if(sub.ElementAt(k).listCat.Contains(template.ExamQuestions.ElementAt(i).ExamQuestion_Categories.ElementAt(j))&& !result.Contains(sub.ElementAt(k)))
                        {
                           result.Add(sub.ElementAt(k));
                        }
                    }
                }
            }
            return result;
            
        }


        // POST: api/ExamTemplate
        [ActionName("AddExam")]
        public void Post([FromBody]string ExamTemplateName)
        {
           //client.AddNewExam(ExamTemplateName, "b", "a"); //UPDATE SERVICE REFERENCE UPON MERGE AND THEN UNCOMMENT
        }

        // PUT: api/ExamTemplate/5
        public void Put(string extid, int weight, [FromBody] WCF.ExamQuestion exques)
        {
            client.spAddQuestionToExam(extid, exques.ExamQuestionID, weight);
        }
        
        // DELETE: api/ExamTemplate/5
        public void Delete(string ETID)
        {
            client.DeleteExam(ETID);
            
        }
    }
}
