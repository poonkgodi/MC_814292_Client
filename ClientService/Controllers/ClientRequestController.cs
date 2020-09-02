using System;
using System.Collections.Generic;
using ClientService.Models;
using ClientService.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Logging;

namespace ClientService.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
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
        [HttpGet]
        public IEnumerable<ClientRequest> GetClientRequest()
        {
            var userData = _repoEntity.GetAll();
            return userData;
        }

        // POST api/values
        [HttpPost]
        public IActionResult PostClient([FromBody] ClientRequest orepoentity)
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
