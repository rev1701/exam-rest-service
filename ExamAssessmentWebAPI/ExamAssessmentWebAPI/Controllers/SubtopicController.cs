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
        WCF.Service1Client client = new WCF.Service1Client(); //Readonly suggested

    public HttpResponseMessage Get()
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
                        
                        
                                Sub.Add(subx);
                            
                    }
                }
            }
            for (int lop = 0; lop < 20; lop++)
            {


                for (int kk = 0; kk < Sub.Count; kk++)
                {
                    for (int ll = kk + 1; ll < Sub.Count; ll++)
                    {
                        if (Sub.ElementAt(kk).Subtopic_ID == Sub.ElementAt(ll).Subtopic_ID)
                        {
                            Sub.RemoveAt(ll);
                        }
                    }

                }
            }
          
            Sub.OrderByDescending(S => S.Subtopic_ID);
            //Return the List of SubTopic Objects
            return Request.CreateResponse(HttpStatusCode.OK,Sub);
        }

        /// <summary>
        ///  Will Add a new Subtopic
        /// </summary>
        /// <param name="CategoryName"></param>
        /// <param name="SubtopicName"></param>
        [ActionName("AddNewSubtopic")]
        public void AddNewSubtopic(string CategoryName, [FromBody]string SubtopicName)
        {
            client.spAddNewCategoryType(SubtopicName, CategoryName);
        }

        // DELETE: api/Subtopic/5

        public void Delete(string subtopicName)
        {
            client.DeleteSubtopic(subtopicName);
        }
    }
}
