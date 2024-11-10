using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Account;
using api.DTOs.Account.Owner;
using api.Helpers;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace api.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IOwnerManager _ownerManager;
        private readonly ITokenService _tokenService;
        private readonly AuthenticationHelpers _authHelper;

        public AuthService(UserManager<AppUser> userManager, ITokenService tokenService, AuthenticationHelpers authHelper, IOwnerManager ownerManager)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _authHelper = authHelper;
            _ownerManager = ownerManager;
        }


        public async Task<AuthDTO> RegisterAsync(RegisterDTO register)
        {
            AppUser user = await _userManager.FindByEmailAsync(register.email);

            if(user != null)
            {
                return await _authHelper.HandleExistingUserRegistrationAsync(user, "User");
            }

            return await _authHelper.RegisterNewUserAsync(register);
        }



        public async Task<AuthDTO> LoginAsync(LoginDTO login)
        {
            AuthDTO authModel = new AuthDTO();

            AppUser? user = await _userManager.FindByEmailAsync(login.email);

            if(user is null || !await _userManager.CheckPasswordAsync(user, login.password))
            {
                return new AuthDTO { message = "Username or password is invalid!"};
            }

            var token = await _tokenService.CreateToken(user);

            var refreshToken = user.RefreshTokens.FirstOrDefault(t => t.IsActive);

            if(refreshToken != null)
            {
                authModel.refresh_token = refreshToken.Token;
                authModel.refresh_token_expiration = refreshToken.ExpiresOn;
            }
            else
            {
                var NewRefreshToken = _tokenService.CreateRefreshToken();
                authModel.refresh_token = NewRefreshToken.Token;
                authModel.refresh_token_expiration = NewRefreshToken.ExpiresOn;
                user.RefreshTokens.Add(NewRefreshToken);
                await _userManager.UpdateAsync(user);
            }

            authModel.name = user.Name;
            authModel.email = user.Email;
            authModel.is_authenticated = true;
            var Roles = await _userManager.GetRolesAsync(user);
            authModel.roles = Roles.ToList();
            authModel.token = new JwtSecurityTokenHandler().WriteToken(token);

            return authModel;
        }



        public async Task<AuthDTO> AdminRegisterAsync(RegisterDTO registerDTO)
        {
            AppUser user = await _userManager.FindByEmailAsync(registerDTO.email);

            if(user != null)
            {
                return await _authHelper.HandleExistingUserRegistrationAsync(user, "Admin");
            }

            return await _authHelper.RegisterNewAdminAsync(registerDTO);
        }


        public async Task<AuthDTO> RefreshTokenAsync(RefreshTokenRequestDTO refreshTokenRequestDTO)
        {
            switch(refreshTokenRequestDTO.role)
            {
                case "User":
                    return await _authHelper.UserRefreshToken(refreshTokenRequestDTO.refresh_token);
                default:
                    return await _authHelper.OwnerRefreshToken(refreshTokenRequestDTO.refresh_token);
            }
        }


        
        


        public async Task<OwnerAuthDTO> OwnerRegisterAsync(OwnerRegisterDTO ownerRegisterDTO)
        {
            Owner Owner = await _ownerManager.FindByEmailAsync(ownerRegisterDTO.email);

            if(Owner == null)
            {
                return await _authHelper.RegisterNewOwnerAsync(ownerRegisterDTO);
            }

            return new OwnerAuthDTO { message = "Email Already Registered!"};
        }


        public async Task<OwnerAuthDTO> OwnerLoginAsync(LoginDTO login)
        {
            OwnerAuthDTO authModel = new OwnerAuthDTO();

            Owner? owner = await _ownerManager.FindByEmailAsync(login.email);

            if(owner is null || ! _ownerManager.CheckPassword(owner, login.password))
            {
                return new OwnerAuthDTO { message = "Username or password is invalid!"};
            }

            var token = _tokenService.CreateToken(owner);

            var refreshToken = owner.RefreshTokens.FirstOrDefault(t => t.IsActive);

            if(refreshToken != null)
            {
                authModel.refresh_token = refreshToken.Token;
                authModel.refresh_token_expiration = refreshToken.ExpiresOn;
            }
            else
            {
                var NewRefreshToken = _tokenService.CreateRefreshToken();
                authModel.refresh_token = NewRefreshToken.Token;
                authModel.refresh_token_expiration = NewRefreshToken.ExpiresOn;
                owner.RefreshTokens.Add(NewRefreshToken);
                await _ownerManager.UpdateAsync(owner);
            }

            authModel.name = owner.Name;
            authModel.email = owner.Email;
            authModel.is_authenticated = true;
            authModel.role = "Owner";
            authModel.token = new JwtSecurityTokenHandler().WriteToken(token);

            return authModel;
        }
    }
}