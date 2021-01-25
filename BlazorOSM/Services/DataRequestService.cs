
using BlazorOSM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorOSM.Services
{
    public class DataRequestService : IDataRequestService
    {
        private readonly HttpClient httpClient;

        public DataRequestService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<string> getDataRequest()
        {
            return await httpClient.GetFromJsonAsync<string>("api/GetStreet");
        }

        public async Task setDataRequest(DataRequest dataRequest)
        {
            await httpClient.PostAsJsonAsync<DataRequest>("api/SaveToDatabase", dataRequest);
        }
    }
}
