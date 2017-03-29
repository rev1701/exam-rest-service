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

namespace LMS1701.EA.Controllers
{ 
        [EnableCors(origins: "*", headers: "*", methods: "*")]
public class SubtopicController : ApiController
    {


        private MediaTypeWithQualityHeaderValue jsonMediaType = new MediaTypeWithQualityHeaderValue("application/json");
        HttpClient client = new HttpClient(); 
                                          // GET: api/Subtopic/
    public List<Subtopic> Get()
        {
            List<Subtopic> test = new List<Subtopic>();
            client.BaseAddress = new Uri(WebApiConfig.baseUrl);
            client.DefaultRequestHeaders.Accept.Add(jsonMediaType);
            HttpResponseMessage response = client.GetAsync("api/subtopics").Result;

            if (response.IsSuccessStatusCode)
            {
                var obj = response.Content.ReadAsStringAsync().Result;
                test = JsonConvert.DeserializeObject<List<Subtopic>>(obj);
            }
            return test;
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
