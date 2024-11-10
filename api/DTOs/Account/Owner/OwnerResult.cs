using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.Account.Owner
{
    public class OwnerResult
    {
        public bool Succeeded { get; set; }
        public string Error { get; set; } = string.Empty;
    }
}