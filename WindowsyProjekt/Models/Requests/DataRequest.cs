using System.ComponentModel.DataAnnotations;

namespace WindowsyProjekt.Models.Requests
{
    public class DataRequest
    {
        public string City { get; set; }

        public string StreetName { get; set; }

        public string StreetCordX { get; set; }

        public string StreetCordY { get; set; }

        public string Additional { get; set; }
    }
}