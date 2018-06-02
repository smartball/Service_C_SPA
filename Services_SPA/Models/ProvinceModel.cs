using System;
namespace Services_SPA.Models
{
    public class ProvinceModel
    {
        public int province_id { get; set; }
        public string province_code { get; set; }
        public string province_name { get; set; }
        public int geo_id { get; set; }
        public ProvinceModel()
        {
        }
    }
}
