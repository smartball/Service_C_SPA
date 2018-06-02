using System;
namespace Services_SPA.Models
{
    public class Place
    {
        public string id { get; set; }
        public string name { get; set; }
        public float lat { get; set; }
        public float lng { get; set; }
        public string error { get; set; }
        public float distance { get; set; }
        public float sum { get; set; }
        public Place(string id, string name, float lat, float lng, string error)
        {
            this.id = id;
            this.name = name;
            this.lat = lat;
            this.lng = lng;
            this.error = error;
        }
        public Place()
        {
        }
    }
}
