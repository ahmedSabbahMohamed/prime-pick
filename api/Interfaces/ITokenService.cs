using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.IdentityModel.Tokens;

namespace api.Interfaces
{
    public interface ITokenService
    {
        SecurityToken CreateToken(AppUser user);
        RefreshToken CreateRefreshToken();
    }
}