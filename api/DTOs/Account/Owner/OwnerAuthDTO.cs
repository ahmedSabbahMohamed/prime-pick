using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.Account.Owner
{
    public class OwnerAuthDTO
    {
        public string name { get; set; }
        public string email { get; set; }
        public bool is_authenticated { get; set; } = false;
        public string message { get; set; }
        public string token { get; set; }
        public string role { get; set; }
        public string? refresh_token { get; set; }
        public DateTime refresh_token_expiration { get; set; }
    }
}