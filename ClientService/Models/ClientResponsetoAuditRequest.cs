using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientService.Models
{
    public class ClientResponsetoAuditRequest
    {
        public int Id { get; set; }
        public string AuditRequestID { get; set; }
        public string AuditPortfolioID { get; set; }
        public string AuditorID { get; set; }
        public int ClientId { get; set; }
        public string Request { get; set; }
        public DateTime Created_Timestamp { get; set; } = DateTime.Now;
        //public string Request_Comment { get; set; }
        //public string Response_Comment { get; set; }
    }
}
