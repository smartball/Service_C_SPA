using System;
namespace Services_SPA.Models
{
    public class AmphurModel
    {
        public int amphur_id { get; set; }
        public string amphur_code { get; set; }
        public string amphur_name { get; set; }
        public int geo_id { get; set; }
        public int province_id { get; set; }
        public AmphurModel()
        {
        }
    }
}
