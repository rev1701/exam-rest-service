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
        /// 
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage  Get()
        {
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="subjectName"></param>
        /// <param name="categoryName"></param>

        public void Post([FromBody]string subjectName, string categoryName)
        {
            client.spAddNewCategoryType(subjectName, categoryName);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="CategoryName"></param>
        /// <param name="SubtopicName"></param>
        [ActionName("AddNewSubtopic")]
        public void AddNewSubtopic(string CategoryName, [FromBody]string SubtopicName)
        {
            client.spAddNewCategoryType(SubtopicName, CategoryName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="CategoryName"></param>
        /// <param name="SubtopicName"></param>
        [ActionName("AddExistingSubtopic")]
        public void AddExistingSubtopic(string CategoryName, [FromBody]string SubtopicName)
        {
            client.spAddExistingSubtopicToCategory(SubtopicName, CategoryName);
        }
       


            /// <summary>
            /// 
            /// </summary>
            /// <param name="CategoryName"></param>
            /// <param name="SubtopicName"></param>
        [ActionName("RemoveSubtopic")]
        public void RemoveSubtopic(string CategoryName, [FromBody]string SubtopicName)
        {
            client.RemoveSubtopicFromCategory( SubtopicName,  CategoryName);
        }

        // DELETE: api/Category/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="CategoryName"></param>
        public void Delete(string CategoryName)
        {
            client.DeleteCategory(CategoryName);
        }
    }
}
