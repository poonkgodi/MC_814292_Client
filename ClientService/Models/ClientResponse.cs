using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClientService.Models
{
    public class ClientResponse
    {
        public int Id { get; set; }
        public string AuditRequestID { get; set; }
        public string AuditPortfolioID { get; set; }
        public string AuditorID { get; set; }
        [Required]
        public int ClientId { get; set; }
        public string Request { get; set; }
        public DateTime Created_Timestamp { get; set; } = DateTime.Now;

        
        //[StringLength(50, MinimumLength = 2, ErrorMessage = "Must be with 2 to 50 characters")]
        public string Doc_Name { get; set; }
        
        
       // [StringLength(250, MinimumLength = 2, ErrorMessage = "Must be with 2 to 250 characters")]
        public string Doc_Path { get; set; }

        [NotMapped]
        public IFormFile File { get; set; }
    }
}
