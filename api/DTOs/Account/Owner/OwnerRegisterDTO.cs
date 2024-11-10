using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.Account.Owner
{
    public class OwnerRegisterDTO
    {
        [Required]
        [EmailAddress]
        public string? email { get; set; }

        [Required]
        public string? first_name { get; set; }
        
        [Required]
        public string? last_name { get; set; }

        [Required]
        public string? phone { get; set; }

        [Required]
        public string? password { get; set; }
    }
}