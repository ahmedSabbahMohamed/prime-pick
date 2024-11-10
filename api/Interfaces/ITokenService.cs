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
        Task<SecurityToken> CreateToken(AppUser user);
        SecurityToken CreateToken(Owner owner);
        RefreshToken CreateRefreshToken();
    }
}