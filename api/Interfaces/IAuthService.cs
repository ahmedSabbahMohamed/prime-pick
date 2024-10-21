using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Account;

namespace api.Interfaces
{
    public interface IAuthService
    {
        Task<AuthDTO> RegisterAsync(RegisterDTO regitser);
        Task<AuthDTO> LoginAsync(LoginDTO login);
        Task<AuthDTO> RefreshTokenAsync(string token);
        
    }
}