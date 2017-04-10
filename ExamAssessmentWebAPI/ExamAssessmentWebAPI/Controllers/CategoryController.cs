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
    public class CategoryController : ApiController
    {
        WCF.Service1Client client = new WCF.Service1Client(); //readonly suggested

        #region TODO

        // TODO:complete methods inside this region.
        // TODO: Add HTTP Response as return type for any methods that don't have it.
        // TODO:Add NLog to each method inside the entire controller (not just this region).  Each Controller should have its own log file
        // TODO:Add Unit Tests for each method inside this controller.  There is already a Unit Test Library in this project with a class already made for this controller

        /// <summary>
        ///  Method will add a brand new category to the database.  Required to be associated with a Subject.
        /// </summary>
        /// <param name="subjectName">string subjectName</param>
        /// <param name="categoryName">string categoryName</param>
        /// <endpoint>PUT: api/Category/?subjectName={id}</endpoint>
        /// <returns></returns>
        /// 
        [HttpPut]
        public void AddCategory(string subjectName, [FromBody]string categoryName)
        {
            client.spAddNewCategoryType(subjectName, categoryName);
        }

        /// <summary>
        ///  Add an Existing Subtopic to a category
        /// </summary>
        /// <param name="CategoryName">string CategoryName</param>
        /// <param name="SubtopicName">string SubtopicName (inside request body)</param>
        /// <endpoint>api/Category/AddExistingSubtopic/?CategoryName={id}</endpoint>
        /// <returns></returns>
        [ActionName("AddExistingSubtopic")]
        public void AddExistingSubtopic(string CategoryName, [FromBody]string SubtopicName)
        {
            client.spAddExistingSubtopicToCategory(SubtopicName, CategoryName);
        }

        /// <summary>
        ///  Will Remove a subtopic from the category
        /// </summary>
        /// <param name="CategoryName">string CategoryName</param>
        /// <param name="SubtopicName">string SubtopicName (In Request Body)</param>
        /// <endpoint>api/Category/RemoveSubtopic/?CategoryName={id}/endpoint>
        [ActionName("RemoveSubtopic")]
        public void RemoveSubtopic(string CategoryName, [FromBody]string SubtopicName)
        {
            client.RemoveSubtopicFromCategory(SubtopicName, CategoryName);
        }

        /// <summary>
        ///  Will Remove a Category from the database along with all references to the category
        /// </summary>
        /// <param name="CategoryName">string CategoryName</param>
        /// <endpoint>DELETE: api/Category/CategoryName={id}</endpoint>\
        [HttpDelete]
        public void Delete(string CategoryName)
        {
            client.DeleteCategory(CategoryName);
        }

        #endregion TODO

        /// <summary>
        ///  Will return every category in the database.  Will return only unique values.
        /// </summary>
        /// <endpoint>GET: api/Category</endpoint>
        /// <returns>HTTP Response message along with JSON result of the Category List</returns>
        public HttpResponseMessage  Get()
        {
            // Uses the get All Subject method to get all of the categories since all categories will be attached to a subject.  The method filters through all of the subjects and only keeps unique values.
            var info = client.GetAllSubject().ToList();
            List <WCF.Category> Cat = new List<WCF.Category>();
            
            foreach (WCF.Subject item in info)
            {
                foreach (WCF.Category catx in item.listCat)
                {
                      Cat.Add(catx);
                }
            }
            for (int lop = 0; lop < 20; lop++)
            {
                for (int kk = 0; kk < Cat.Count; kk++)
                {
                    for (int ll = kk + 1; ll < Cat.Count; ll++)
                    {
                        if (Cat.ElementAt(kk).Categories_ID == Cat.ElementAt(ll).Categories_ID)
                        {
                            Cat.RemoveAt(ll);
                        }
                    }
                }
            }

            return Request.CreateResponse(HttpStatusCode.OK,Cat);
        }


    }
}
