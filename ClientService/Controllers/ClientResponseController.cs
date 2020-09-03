using ClientService.Models;
using ClientService.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientService.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ClientResponseController
    {
        IHostingEnvironment env;
        private readonly ILogger<ClientResponseController> _logger;
        private IRepository<ClientResponse> _repoClientResponse;
        public ClientResponseController(IHostingEnvironment _env, IRepository<ClientResponse> repoClientResponse)
        {
            this._repoClientResponse = repoClientResponse;
            env = _env;
            env.WebRootPath = "D:\\MC\\mcservices-814292-master\\ClientService\\";
        }
        //Get All Values
        [HttpGet("GetClientResponses")]
        public IEnumerable<ClientResponse> GetClientResponses()
        {
            var objData = _repoClientResponse.GetAll();
            return objData;
        }

        [HttpPost]
        [Route("AddClientResponse")]
        public void Create([FromForm] ClientResponse repoClientResponse)
        {
            #region Read File Content

            var uploads = Path.Combine(env.WebRootPath, "uploads");
            bool exists = Directory.Exists(uploads);
            if (!exists)
                Directory.CreateDirectory(uploads);

            string fileName = Path.GetFileName(repoClientResponse.File.FileName);
            byte[] fileData;
            using (var target = new MemoryStream())
            {
                repoClientResponse.File.CopyTo(target);
                fileData = target.ToArray();
            }


            //var fileStream = new FileStream(Path.Combine(uploads, product.File.FileName), FileMode.Create);
            string mimeType = repoClientResponse.File.ContentType;
            //= new byte[product.File.Length];

            BlobStorageService objBlobService = new BlobStorageService();

            repoClientResponse.ImagePath = objBlobService.UploadFileToBlob(repoClientResponse.File.FileName, fileData, mimeType);
            #endregion



            _repoClientResponse.Create(repoClientResponse);
        }


        // PUT api/values
        [HttpPut]
        [Route("UpdateResponse/{id:int}")]
        public void UpdateResponse([FromBody] ClientResponse repoClientResponse, int id)
        {
            try
            {
                int res = _repoClientResponse.Update(repoClientResponse);

                // Send the Audit request to client Application through ServiceBus Queue */
                string bus_connectionString = "Endpoint=sb://auditclientns.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=rDJbSB0nbmK0cs0fw9A0vbLfMyIa8+Zudb3nlCgj6GI=";
                string queuename = "clientmq";
                IQueueClient auditQueue;
                auditQueue = new QueueClient(bus_connectionString, queuename);

                string auditRequestID = repoClientResponse.AuditRequestID;

                ClientResponsetoAuditRequest cresponse = new ClientResponsetoAuditRequest();
                cresponse.AuditPortfolioID = repoClientResponse.AuditPortfolioID;
                cresponse.AuditRequestID = repoClientResponse.AuditRequestID;
                cresponse.AuditorID = repoClientResponse.AuditorID;
                cresponse.ClientId = repoClientResponse.ClientId;
                cresponse.Created_Timestamp = repoClientResponse.Created_Timestamp;
                cresponse.Request = repoClientResponse.Request +
                                String.Format("[{0} : {1}]"
                                , repoClientResponse.ImageName
                                , repoClientResponse.ImagePath);


                string clientRequestMessage = JsonConvert.SerializeObject(cresponse);
                clientRequestMessage = repoClientResponse.AuditRequestID + "|" + clientRequestMessage;
                var message = new Message(Encoding.UTF8.GetBytes(clientRequestMessage));
                auditQueue.SendAsync(message);

            }
            catch (Exception ex)
            {
                string Err = ex.Message;
            }
        }
    }


    public class FileAttachmentForm
    {
        public int FormId { get; set; }
        public IFormFile File { get; set; }
    }
}
