using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.Account
{
    public class RegisterDTO
    {
        [Required]
        public string? name { get; set; }

        [Required]
        [EmailAddress]
        public string? email { get; set; }

        [Required]
        public string? password { get; set; }
        public string? phone { get; set; }
    }
}