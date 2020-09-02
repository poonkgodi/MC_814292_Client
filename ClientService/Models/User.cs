using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClientService.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "UserName")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Must be with 2 to 50 characters")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please provide Password Details")]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "Must be with 8 to 20 characters")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Please provide Address Details")]
        public string Address { get; set; }
        public string EmailAddress { get; set; }
        public string UserRoleType { get; set; }
        public DateTime Created_Timestamp { get; set; }
    }
}
