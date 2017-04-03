﻿using System;
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
        WCF.Service1Client client = new WCF.Service1Client();

        // GET: api/Category
        public List <WCF.Category> Get()
        {
            var info = client.GetAllSubject();
            List <WCF.Category> Cat = new List<WCF.Category>();
            
            foreach (WCF.Subject item in info)
            {
                foreach (WCF.Category catx in item.listCat)
                {
                    foreach(WCF.Category caty in Cat)
                    {
                        if (caty.Categories_Name.Equals(catx.Categories_Name)){
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
        public void Post([FromBody]string value, int SubjectId)
        {

        }

        // PUT: api/Category/
        [ActionName("AddSubtopic")]
        public void AddSubtopic(int CategoryId, [FromBody]string value)
        {

        }

        // PUT: api/Category/
        [ActionName("RemoveSubtopic")]
        public void RemoveSubtopic(int CategoryId, [FromBody]string value)
        {

        }

        // DELETE: api/Category/5
        public void Delete(int CategoryId)
        {

        }
    }
}
