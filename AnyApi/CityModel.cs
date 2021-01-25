using System;

namespace AnyApi
{
    public class CityModel
    {
        public string Woj { get; set; }

        public string Pow { get; set; }

        public string Gmi { get; set; }

        public string Rd { get; set; }

        public string Msc { get; set; }

        public bool U { get; set; }

        public bool A { get; set; }

        public DateTime Date { get; set; }

        public string MscFull { get; set; }

        public CityModel()
        {
            Date = DateTime.Now;
        }

    }
}