using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Services_SPA.App_Start;
using Services_SPA.Models;

namespace Services_SPA.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        
        // GET api/values
        [HttpGet]
        [EnableCors("SiteCorsPolicy")]
        public List<Place> Get()
        {
            MySqlConnection conn = WebApiConfig.conn();
            MySqlCommand query = conn.CreateCommand();
            query.CommandText = "SELECT * FROM markers";
            var results = new List<Place>();
            try
            {
                conn.Open();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {

                throw;
            }
            MySqlDataReader fetch_query = query.ExecuteReader();
            while (fetch_query.Read())
            {
                Place p = new Place();
                p.id = fetch_query.GetString(0);
                p.name = fetch_query.GetString(1);
                p.lat = fetch_query.GetFloat(3);
                p.lng = fetch_query.GetFloat(4);
                results.Add(p);
                /*results.Add(new Place(fetch_query["id"].ToString(), 
                                      fetch_query["name"].ToString(), 
                                      fetch_query["lat"], 
                                      fetch_query["lng"].ToString(), null));*/
            }
            return results;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
