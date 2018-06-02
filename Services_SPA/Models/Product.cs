using System;
namespace Services_SPA.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string NAME { get; set; }
        public string AREA_SIZE { get; set; }
        public string AREA_APPRAISAL { get; set; }
        public string DPM_APPRAISAL { get; set; }
        public string DISTANCE { get; set; }
        public string SELL_PRICE { get; set; }
        public string PHONE { get; set; }
        public int PROVINCE { get; set; }
        public int AMPHUR { get; set; }
        public string ROAD { get; set; }
        public string WIDTH { get; set; }
        public string SHAPE { get; set; }
        public string DESCRIPTION { get; set; }
        public int USER_ID { get; set; }
        public Product()
        {
        }
    }
}
