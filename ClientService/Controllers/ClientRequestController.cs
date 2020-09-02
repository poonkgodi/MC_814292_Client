using ClientService.Models;
using ClientService.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.ServiceBus;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace ClientService.Controllers
{
    public class ClientRequestController : ControllerBase
    {
        private static string bus_connectionString = "Endpoint=sb://auditclientns.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=rDJbSB0nbmK0cs0fw9A0vbLfMyIa8+Zudb3nlCgj6GI=";
        private static string queuename = "auditmq";
        private static IQueueClient _queueClient;

        private readonly ILogger<ClientRequestController> _logger;
        private  IRepository<ClientRequest> _repoEntity;
        public ClientRequestController(IRepository<ClientRequest> repoEntity)
        {
            this._repoEntity = repoEntity;
        }

        //Get All Values
        [HttpGet("GetClientRequest")]
        public IEnumerable<ClientRequest> GetClientRequestDetails()
        {
            var userData = _repoEntity.GetAll();
            return userData;
        }

        // POST api/values
        [HttpPost]
        [Route("AddClientRequest")]
        public IActionResult AddClientRequest([FromBody] ClientRequest orepoentity)
        {
            try
            {
                int res = _repoEntity.Insert(orepoentity);
                if (res != 0)
                {
                    return Ok(res);
                }
                return Forbid();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
