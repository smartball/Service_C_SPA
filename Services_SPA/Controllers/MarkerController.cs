using System;
using System.Collections.Generic;
using System.Linq;
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
    public class MarkerController : Controller
    {
        // GET: api/values
        [HttpGet]
        [EnableCors("SiteCorsPolicy")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{deed_number},{province_id},{amphur_code}")]
        [EnableCors("SiteCorsPolicy")]
        public List<Marker> Get(int deed_number, int province_id, int amphur_code)
        {
            MarkerQuery mark = new MarkerQuery();
            var point = mark.getMarker(deed_number, province_id, amphur_code);

            return point;
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
