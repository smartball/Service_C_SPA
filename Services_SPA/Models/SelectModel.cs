using System;
namespace Services_SPA.Models
{
    public class SelectModel
    {
        public int id { get; set; }
        public int province_id { get; set; }
        public int amphur_code { get; set; }
        public int type { get; set; }
        public string factor_name { get; set; }
        public float weight { get; set; }
        public SelectModel()
        {
        }
    }
}
