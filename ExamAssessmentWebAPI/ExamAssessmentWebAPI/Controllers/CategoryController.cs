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
        public List <WCF.Category> Get()
        {
            var info = client.GetAllSubject().ToList();
            List <WCF.Category> Cat = new List<WCF.Category>();
            
            foreach (WCF.Subject item in info)
            {
                foreach (WCF.Category catx in item.listCat)
                {
                    foreach(WCF.Category caty in Cat)
                    {
                        if (caty.Categories_Name.Equals(catx.Categories_Name))
                        {
                            continue;
                        }
                        else
                        {
                            Cat.Add(catx);
                        }
                        
                    }
                }
            }
            return Cat;
        }

        // POST: api/Category
        public void Post([FromBody]string subjectName, string categoryName)
        {
            client.spAddNewCategoryType(subjectName, categoryName);
        }

        // PUT: api/Category/
        [ActionName("AddNewSubtopic")]
        public void AddNewSubtopic(string CategoryName, [FromBody]string SubtopicName)
        {
            client.spAddNewCategoryType(SubtopicName, CategoryName);
        }
        [ActionName("AddExistingSubtopic")]
        public void AddExistingSubtopic(string CategoryName, [FromBody]string SubtopicName)
        {
            client.spAddExistingSubtopicToCategory(SubtopicName, CategoryName);
        }
        // PUT: api/Category/
        [ActionName("RemoveSubtopic")]
        public void RemoveSubtopic(string CategoryName, [FromBody]string SubtopicName)
        {
            client.RemoveSubtopicFromCategory( SubtopicName,  CategoryName);
        }

        // DELETE: api/Category/5
        public void Delete(string CategoryName)
        {
            client.DeleteCategory(CategoryName);
        }
    }
}
