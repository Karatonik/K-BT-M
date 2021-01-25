using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web.Http;

namespace AnyApi
{
    public class HelloController : ApiController
    {
        private List<CityModel> CityList = new List<CityModel>
        {
            ///new CityModel { MscFull = "Toruń", Woj = "04", Pow = "63", Gmi = "01", Rd = "1", Msc = "0982724", U = true, A = false },
          //  new CityModel { MscFull = "Poznań", Woj = "30", Pow = "64", Gmi = "01", Rd = "1", Msc = "0969400", U = true, A = false },
            new CityModel { MscFull = "Bydgoszcz", Woj = "04", Pow = "61", Gmi = "01", Rd = "1", Msc = "0928363", U = true, A = false }
           // new CityModel { MscFull = "Warszawa", Woj = "14", Pow = "65", Gmi = "01", Rd = "1", Msc = "0918123", U = true, A = false },
           // new CityModel { MscFull = "Wrocław", Woj = "02", Pow = "64", Gmi = "01", Rd = "1", Msc = "0986283", U = true, A = false },
          //  new CityModel { MscFull = "Lublin", Woj = "06", Pow = "63", Gmi = "01", Rd = "1", Msc = "0954700", U = true, A = false },
           // new CityModel { MscFull = "Łódź", Woj = "10", Pow = "61", Gmi = "01", Rd = "1", Msc = "0957650", U = true, A = false },
          //  new CityModel { MscFull = "Opole", Woj = "16", Pow = "61", Gmi = "01", Rd = "1", Msc = "0965016", U = true, A = false },
           // new CityModel { MscFull = "Rzeszów", Woj = "18", Pow = "63", Gmi = "01", Rd = "1", Msc = "0974133", U = true, A = false },
          //  new CityModel { MscFull = "Gdańsk", Woj = "22", Pow = "61", Gmi = "01", Rd = "1", Msc = "0933016", U = true, A = false }
        };

        public string Get()
        {
            var random = new Random();

            var proxy = new ChannelFactory<ITerytWs1>("custom");
            proxy.Credentials.UserName.UserName = "Arventill";
            proxy.Credentials.UserName.Password = "MvM2E19N0";
            var result = proxy.CreateChannel();

            int rInt2 = random.Next(0, CityList.Count);
            var randomCity = CityList[rInt2];

            var miejscowosci = result.PobierzListeUlicDlaMiejscowosci(randomCity.Woj, randomCity.Pow, randomCity.Gmi, randomCity.Rd, randomCity.Msc, randomCity.U, randomCity.A, DateTime.Now);
            int liczbaMiejscowosci = miejscowosci.Count();
            int rInt = random.Next(0, liczbaMiejscowosci);

            return randomCity.MscFull + ", " + miejscowosci[rInt].Nazwa2 + " " + miejscowosci[rInt].Nazwa1;
        }

        public bool Post(DataRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.City) || string.IsNullOrWhiteSpace(request.StreetName)
                                                        || request.StreetCordX == 0 || request.StreetCordY == 0
                                                        || request.StreetCordX == null || request.StreetCordY == null)
                return false;

            return true;
        }
    }
}