using BlazorOSM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorOSM.Services
{
   public interface IDataRequestService
    {
        Task<String> getDataRequest();

        Task setDataRequest(DataRequest dataRequest);
    }
}
