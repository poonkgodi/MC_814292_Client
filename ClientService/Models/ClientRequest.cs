using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClientService.Models
{
    public class ClientRequest
    {
        public int Id { get; set; }
        public string AuditPortfolioID { get; set; }
        public string AuditRequestID { get; set; }
        public string AuditorID { get; set; }
        [Required]
        public int ClientId { get; set; }
        public string Request { get; set; }
        public DateTime Created_Timestamp { get; set; }
        //public string Request_Comment { get; set; }
        //public string Response_Comment { get; set; }
    }
}
