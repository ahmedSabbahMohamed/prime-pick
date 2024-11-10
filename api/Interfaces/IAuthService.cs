using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Account;
using api.DTOs.Account.Owner;

namespace api.Interfaces
{
    public interface IAuthService
    {
        Task<AuthDTO> RegisterAsync(RegisterDTO regitser);
        Task<AuthDTO> AdminRegisterAsync(RegisterDTO registerDTO);
        Task<AuthDTO> LoginAsync(LoginDTO login);
        Task<AuthDTO> RefreshTokenAsync(RefreshTokenRequestDTO tokenRequestDTO);
        Task<OwnerAuthDTO> OwnerRegisterAsync(OwnerRegisterDTO ownerRegisterDTO);
        Task<OwnerAuthDTO> OwnerLoginAsync(LoginDTO loginDTO);
        
    }
}