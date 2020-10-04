using System.Collections.Generic;

namespace AdreaniExam.GeocodificadorService.Model
{
    public class Result
    {
        public int PlaceId { get; set; }
        public string Licence { get; set; }
        public string OsmType { get; set; }
        public int OsmId { get; set; }
        public List<string> Boundingbox { get; set; }
        public string Lat { get; set; }
        public string Lon { get; set; }
        public string DisplayName { get; set; }
        public string Class { get; set; }
        public string Type { get; set; }
        public double Importance { get; set; }
        public Address Address { get; set; }
    }
}
