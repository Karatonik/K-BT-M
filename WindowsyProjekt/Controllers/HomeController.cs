using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Net;
using WindowsyProjekt.Models.Requests;
using WindowsyProjekt.Repository;
using Microsoft.Extensions.Logging;

namespace WindowsyProjekt.Controllers
{
    [Route("api/[action]")]
    public class HomeController : Controller
    {
        private readonly ILogger _logger;
        private readonly IProjectRepository _projectRepository;

        public HomeController(
            ILogger<HomeController> logger,
            IProjectRepository projectRepository)
        {
            _logger = logger;
            _projectRepository = projectRepository;
        }

        [HttpGet]
        public string GetStreet()
        {
            WebRequest request = WebRequest.Create("http://localhost:59294/api/hello");
            // If required by the server, set the credentials.
            request.Credentials = CredentialCache.DefaultCredentials;
            // Get the response.
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            // Display the status.
            Console.WriteLine(response.StatusDescription);
            // Get the stream containing content returned by the server.
            Stream dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();

            return responseFromServer;
        }

        [HttpPost]
        public bool SaveToDatabase([FromBody]DataRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.City)
                || string.IsNullOrWhiteSpace(request.StreetName)
                || string.IsNullOrWhiteSpace(request.StreetCordX)
                || string.IsNullOrWhiteSpace(request.StreetCordY))
                return false;

            return _projectRepository.SaveToDatabase(request) == 1;
        }

        //[HttpPost]
        //public bool SaveToDatabase(string City, string StreetName, string StreetCordX, string StreetCordY, string Additional)
        //{
        //    return true;
        //}
    }
}
