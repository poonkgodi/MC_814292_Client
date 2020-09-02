using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientService.Controllers
{
    public class FilesAttachmentController : ControllerBase
    {
        private readonly ILogger<FilesAttachmentController> _logger;
        /// <summary>
        /// Upload multiple files. This demo is dummy and only waits 2 seconds.
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        [HttpPost("multiple-files")]
        public async Task Upload(List<IFormFile> files)
        {
            _logger.LogInformation($"validating {files.Count} files");
            foreach (var file in files)
            {
                _logger.LogInformation($"saving file {file.FileName}");
                await Task.Delay(1000);
            }
            _logger.LogInformation("All files saved.");
        }
    }
    public class FileAttachmentSubmissionResult
    {
        public int AuditorId { get; set; }
        public int FormId { get; set; }
    }
}
