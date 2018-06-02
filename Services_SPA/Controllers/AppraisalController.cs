using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services_SPA.Models;
using Services_SPA.App_Start;
using System.Globalization;
using Microsoft.AspNetCore.Cors;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Services_SPA.Controllers
{
    [Route("api/[controller]")]
    public class AppraisalController : Controller
    {
        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{lat},{lng}")]
        [EnableCors("SiteCorsPolicy")]
        public float Get(string lat, string lng)
        {
            SearchPlace sp = new SearchPlace();
            var search = sp.getPlace(lat, lng);
            int a = 2000;
            float area = 60;
            var nearby_parse = float.Parse(search, CultureInfo.InvariantCulture.NumberFormat);
            //var weight_fac = sp.getWeight();
            //var wf_parse = float.Parse(weight_fac, CultureInfo.InvariantCulture.NumberFormat);
            var weight_road = sp.getRoad();
            var wr_parse = float.Parse(weight_road, CultureInfo.InvariantCulture.NumberFormat);
            var sums = (nearby_parse * a) + (wr_parse * a);
            var total = sums * area;
            return sums;



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
