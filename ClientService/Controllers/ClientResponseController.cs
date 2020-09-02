using ClientService.Models;
using ClientService.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ClientService.Controllers
{
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
        public IActionResult Create([FromForm] ClientResponse repoClientResponse)
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

            int res = _repoClientResponse.Insert(repoClientResponse);
            if (res != 0)
            {
                return null;
            }
            return null;
            //     return RedirectToAction(nameof(Index));
        }
           // return View(product);
    }

    public class FileAttachmentForm
    {
        public int FormId { get; set; }
        public IFormFile File { get; set; }
    }
}
