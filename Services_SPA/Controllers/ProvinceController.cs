using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Services_SPA.App_Start;
using Services_SPA.Models;
using Microsoft.AspNetCore.Cors;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Services_SPA.Controllers
{
    [Route("api/[controller]")]
    public class ProvinceController : Controller
    {
        // GET: api/values
        [HttpGet]
        [EnableCors("SiteCorsPolicy")]
        public List<ProvinceModel> Get()
        {
            MySqlConnection con = WebApiConfig.conn();

            MySqlCommand cm = con.CreateCommand();

            cm.CommandText = "SELECT * from province order by PROVINCE_NAME ASC";

            try
            {
                con.Open();
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            var Province = new List<ProvinceModel>();

            MySqlDataReader mySQLReader = cm.ExecuteReader();

            while (mySQLReader.Read())
            {
                ProvinceModel p = new ProvinceModel();
                p.province_id = mySQLReader.GetInt32(0);
                p.province_code = mySQLReader.GetString(1);
                p.province_name = mySQLReader.GetString(2);
                p.geo_id = mySQLReader.GetInt32(3);

                Province.Add(p);
            }
            return Province;
        }

        // GET api/values/5
        [HttpGet("{province_id}")]
        [EnableCors("SiteCorsPolicy")]
        public List<AmphurModel> Get(int province_id)
        {
            Amphur am = new Amphur();
            var amp = am.getAmphur(province_id);
            return amp;
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
