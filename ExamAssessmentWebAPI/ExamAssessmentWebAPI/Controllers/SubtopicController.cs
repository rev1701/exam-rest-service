using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Cors;
using LMS1701.EA.Models;
using Newtonsoft.Json;
using WCF = ExamAssessmentWebAPI.ExamWCF;


namespace LMS1701.EA.Controllers
{ 
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    
    public class SubtopicController : ApiController
    {
        WCF.Service1Client client = new WCF.Service1Client();
        private MediaTypeWithQualityHeaderValue jsonMediaType = new MediaTypeWithQualityHeaderValue("application/json");
        
                                          // GET: api/Subtopic/
    public List<WCF.SubTopic> Get()
        {
            var info = client.GetAllSubject();
            List<WCF.SubTopic> Sub = new List<WCF.SubTopic>();
            //Get the Subject objects
            foreach (WCF.Subject item in info)
            {
                //Get the Category objects
                foreach (WCF.Category catx in item.listCat)
                {
                    //Get the Subtopic Objects
                    foreach (WCF.SubTopic subx in catx.subtopics)
                    {
                        //Iterate through the Subtopic return list to see and prevent if any duplicates are added
                        foreach (WCF.SubTopic suby in Sub)
                            if (suby.Subtopic_Name.Equals(subx.Subtopic_Name))
                            {
                                //The subtopic is already in the List
                                continue;
                            }
                            else
                            {
                                //Add the non duplicate Subtopic in the list
                                Sub.Add(subx);
                            }
                    }
                }
            }
            //Return the List of SubTopic Objects
            return Sub;
        }

        // POST: api/Subtopic
        public void Post([FromBody]string value, int CategoryId)
        {

        }

        // DELETE: api/Subtopic/5
        
        public void Delete(int SubtopicId)
        {
            
        }
    }
}
