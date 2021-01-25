using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading.Tasks;

namespace WindowsyProjekt.Controllers.Test
{
    [Route("api/[action]")]
    public class TestController : Controller
    {
        [HttpPost]
        public bool Index()
        {
            try
            {
                var proxy = new ChannelFactory<ITerytWs1>("custom");
                proxy.Credentials.UserName.UserName = "Arventill";
                proxy.Credentials.UserName.Password = "MvM2E19N0";
                var result = proxy.CreateChannel();
                var test = result.CzyZalogowanyAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Jebac to wszystko");
            }
            return true;
        }

        // GET: TestController/Details/5
        public bool Details(int id)
        {
            return true;
        }

        // GET: TestController/Create
        public bool Create()
        {
            return true;
        }

    }
}
