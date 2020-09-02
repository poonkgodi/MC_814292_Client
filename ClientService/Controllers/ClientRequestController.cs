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
        private static IRepository<ClientRequest> _repoEntity;
        public ClientRequestController(IRepository<ClientRequest> repoEntity)
        {
            _repoEntity = repoEntity;
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
        public IActionResult AddClientRequest()
        {
            try
            {
                RegisterMessageHandlerAndReceiveMessages();
                return Ok();
            }
            catch (Exception ex)
            {
                return Forbid();
            }
        }
       
        public static void RegisterMessageHandlerAndReceiveMessages()
        {
            _queueClient = new QueueClient(bus_connectionString, queuename);

            var options = new MessageHandlerOptions(ExceptionReceived)
            {
                MaxConcurrentCalls = 1,
                AutoComplete = false
            };

            _queueClient.RegisterMessageHandler(ProcessMessagesAsync, options);
            //_queueClient.CloseAsync().Wait();
        }

       public static async Task ProcessMessagesAsync(Message message, CancellationToken token)
        {
            String str = Encoding.UTF8.GetString(message.Body);
            ClientRequest clientRequest = Newtonsoft.Json.JsonConvert.DeserializeObject<ClientRequest>(str);
            int res = _repoEntity.Insert(clientRequest);
            await _queueClient.CompleteAsync(message.SystemProperties.LockToken);
        }
        static Task ExceptionReceived(ExceptionReceivedEventArgs args)
        {
            return Task.CompletedTask;
        }
    }
}
