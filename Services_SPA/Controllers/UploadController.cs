using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Services_SPA.App_Start;
using Services_SPA.Models;
using Microsoft.AspNetCore.Cors;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Services_SPA.Controllers
{
    [Route("api/[controller]")]
    public class UploadController : Controller
    {
        // GET: api/values
        [HttpGet]
        public List<Marker> Get()
        {
            MySqlConnection con = WebApiConfig.conn();

            MySqlCommand cm = con.CreateCommand();

            cm.CommandText = "SELECT * from property";

            try
            {
                con.Open();
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            var resultMarker = new List<Marker>();

            MySqlDataReader mySQLReader = cm.ExecuteReader();

            while (mySQLReader.Read())
            {
                Marker mark = new Marker();

                mark.deed_number = mySQLReader.GetInt32(0);
                mark.province_id = mySQLReader.GetInt32(1);
                mark.amphur_code = mySQLReader.GetInt32(2);
                mark.size = mySQLReader.GetInt32(3);
                mark.lat = mySQLReader.GetFloat(4);
                mark.lng = mySQLReader.GetFloat(5);
                mark.cost_appraisal = mySQLReader.GetInt32(6);
                resultMarker.Add(mark);
            }
            return resultMarker;
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
