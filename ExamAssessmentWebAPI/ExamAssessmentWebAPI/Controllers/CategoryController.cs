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

        // GET: api/Category
        /// <summary>
        /// Gets All of the Categories in the database
        /// </summary>
        /// <returns>HTTP Response if it worked or not with the List of WCF.Categories</returns>
        public HttpResponseMessage  Get()
        {
            var info = client.GetAllSubject().ToList();
            List <WCF.Category> Cat = new List<WCF.Category>();
            
            foreach (WCF.Subject item in info) //loop through the subjects
            {
                foreach (WCF.Category catx in item.listCat) //loop through the categories
                {
                      Cat.Add(catx);
                }
            }
            for (int lop = 0; lop < 20; lop++) //Gets rid of Duplicates
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

        /// <summary>
        /// The HTTP Post method that lets you add a new category attached to a subject
        /// </summary>
        /// <param name="subjectName">The attached subject name  </param>
        /// <param name="categoryName">The new category name</param>

        public void Post([FromBody]string subjectName, string categoryName)
        {
            client.spAddNewCategoryType(subjectName, categoryName); //client call from SOAP service
        }


        /// <summary>
        /// Adds a new Subtopic attached to a Category
        /// </summary>
        /// <param name="CategoryName">The name of the attached category </param>
        /// <param name="SubtopicName">The New subtopic name</param>
        [ActionName("AddNewSubtopic")]
        public void AddNewSubtopic(string CategoryName, [FromBody]string SubtopicName)
        {
            client.spAddNewCategoryType(SubtopicName, CategoryName); //client call from SOAP service
        }

        /// <summary>
        /// Adds an existing subtopic to an existing category
        /// </summary>
        /// <param name="CategoryName">Name of the Category </param>
        /// <param name="SubtopicName">Subtopic Name</param>
        [ActionName("AddExistingSubtopic")]
        public void AddExistingSubtopic(string CategoryName, [FromBody]string SubtopicName)
        {
            client.spAddExistingSubtopicToCategory(SubtopicName, CategoryName); //client call from SOAP service
        }
       


            /// <summary>
            /// Removes a subtopic attached to a category
            /// </summary>
            /// <param name="CategoryName">attached Category Name</param>
            /// <param name="SubtopicName">Subtopic Name</param>
        [ActionName("RemoveSubtopic")]
        public void RemoveSubtopic(string CategoryName, [FromBody]string SubtopicName)
        {
            client.RemoveSubtopicFromCategory( SubtopicName,  CategoryName); //client call from SOAP service
        }

        // DELETE: api/Category/5
        /// <summary>
        /// Deletes a category
        /// </summary>
        /// <param name="CategoryName">Category Name</param>
        public void Delete(string CategoryName)
        {
            client.DeleteCategory(CategoryName); //client call from SOAP service
        }
    }
}
