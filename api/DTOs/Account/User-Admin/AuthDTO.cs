using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.Account
{
    public class AuthDTO
    {
        public string name { get; set; }
        public string email { get; set; }
        public bool is_authenticated { get; set; } = false;
        public string message { get; set; }
        public string token { get; set; }
        public List<string> roles { get; set; }
        public DateTime expires_on { get; set; }
        public string? refresh_token { get; set; }
        public DateTime refresh_token_expiration { get; set; }
    }
}