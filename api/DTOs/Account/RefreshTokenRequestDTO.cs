using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.Account
{
    public class RefreshTokenRequestDTO
    {
        [Required]
        public string refresh_token { get; set; }
    }
}