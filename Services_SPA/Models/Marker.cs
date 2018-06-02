using System;
namespace Services_SPA.Models
{
    public class Marker
    {
        private string v1;
        private string v2;
        private string v3;
        private string v4;
        private string v5;
        private string v6;

       
        public int deed_number      { get; set; }
        public int province_id      { get; set; }
        public int amphur_code      { get; set; }
        public int size             { get; set; }
        public float lat            { get; set; }
        public float lng            { get; set; }
        public int cost_appraisal   { get; set; }

        public Marker(string v)
        {
        }

        public Marker(string v, string v1, string v2, string v3, string v4, string v5, string v6) : this(v)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.v3 = v3;
            this.v4 = v4;
            this.v5 = v5;
            this.v6 = v6;
        }

        public Marker()
        {
        }
    }
}
