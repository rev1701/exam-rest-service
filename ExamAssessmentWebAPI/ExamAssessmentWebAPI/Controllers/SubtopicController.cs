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
        #region TODO

        // TODO: complete/test methods inside this region.
        // TODO: any method that does not have HTTP Response as a return type will need to be changed to reflect that.
        // TODO:Add NLog to each method inside the entire controller (not just this region).  Each Controller should have its own log file
        // TODO:Add Unit Tests for each method inside this controller.  There is already a Unit Test Library in this project with a class already made for this controller
        // TODO: Add a new Method that will return a list of questions that belong under a certain subject

        /// <summary>
        ///  Will Add a new Subtopic to the database.  Must be attached to a category
        /// </summary>
        /// <param name="CategoryName">string CategoryName</param>
        /// <param name="SubtopicName">string SubtopicName (in request body)</param>
        /// <endpoint>api/Subtopic/AddNewSubtopic/?CategoryName={id}</endpoint>
        [ActionName("AddNewSubtopic")]
        public void AddNewSubtopic(string CategoryName, [FromBody]string SubtopicName)
        {
            client.spAddNewCategoryType(SubtopicName, CategoryName);
        }

        /// <summary>
        ///  Will delete a subtopic from the databas along with all references to it
        /// </summary>
        /// <endpoint>DELETE: api/Subtopic/5</endpoint>
        /// <param name="subtopicName">string subtopicName</param>
        public void Delete(string subtopicName)
        {
            client.DeleteSubtopic(subtopicName);
        }

        #endregion TODO

        /// <summary>
        /// Method will return all Subtopics in the database.  
        /// </summary>
        /// <endpoint>GET: api/Subtopic</endpoint>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage Get()
        {
            //Method will use get all subject to go through and get all of the subtopics. Each subtopic is attached to a category which is attached to a subject.  Will filter through and only return unique values.
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




    }
}
