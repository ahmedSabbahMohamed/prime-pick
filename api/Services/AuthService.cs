using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Account;
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
        private readonly ITokenService _tokenService;

        public AuthService(UserManager<AppUser> userManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }

        public async Task<AuthDTO> LoginAsync(LoginDTO login)
        {
            AuthDTO authModel = new AuthDTO();

            AppUser? user = await _userManager.FindByEmailAsync(login.email);

            if(user is null || !await _userManager.CheckPasswordAsync(user, login.password))
            {
                return new AuthDTO { message = "Username or password is invalid!"};
            }

            var token = _tokenService.CreateToken(user);

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

        public async Task<AuthDTO> RegisterAsync(RegisterDTO register)
        {
            if(await _userManager.FindByEmailAsync(register.email) != null)
                return new AuthDTO { message = "Email is Already Registered!" };

            AppUser newUser = new AppUser
            {
                UserName = register.email,
                Name = register.name,
                Email = register.email,
                PhoneNumber = register.phone
            };

            var Result = await _userManager.CreateAsync(newUser, register.password);

            if(!Result.Succeeded)
            {
                string errors = string.Empty;

                foreach(var error in Result.Errors)
                {
                    errors += $"{error.Description.Substring(0, error.Description.Length - 1)}, ";
                }

                return new AuthDTO { message = $"{errors.Substring(0, errors.Length - 2)}" };
            }

            var addedToRole = await _userManager.AddToRoleAsync(newUser, "User");

            if(!addedToRole.Succeeded)
            {
                string errors = string.Empty;

                foreach(var error in Result.Errors)
                {
                    errors += $"{error.Description.Substring(0, error.Description.Length - 1)}, ";
                }

                return new AuthDTO { message = $"{errors.Substring(0, errors.Length - 2)}" };
            }


            var token = _tokenService.CreateToken(newUser);
            var refreshToken = _tokenService.CreateRefreshToken();
            newUser.RefreshTokens.Add(refreshToken);
            await _userManager.UpdateAsync(newUser);

            return new AuthDTO 
            {
                name = newUser.Name,
                email = newUser.Email,
                is_authenticated = true,
                roles = new List<string> { "User" },
                token = new JwtSecurityTokenHandler().WriteToken(token),
                refresh_token = refreshToken.Token,
                refresh_token_expiration = refreshToken.ExpiresOn
            };
        }


        public async Task<AuthDTO> RefreshTokenAsync(string token)
        {
            var authModel = new AuthDTO();

            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.RefreshTokens.Any(t => t.Token == token));

            if(user == null)
            {
                authModel.message = "Invalid Token";
                return authModel;
            }

            var refreshToken = user.RefreshTokens.Single(t => t.Token == token);

            if(!refreshToken.IsActive)
            {
                authModel.message = "Inactive Token";
                return authModel;
            }

            refreshToken.RevokedOn = DateTime.UtcNow;

            RefreshToken newRefreshToken = _tokenService.CreateRefreshToken();
            user.RefreshTokens.Add(newRefreshToken);
            await _userManager.UpdateAsync(user);

            var JwtToken = _tokenService.CreateToken(user);
            authModel.is_authenticated = true;
            authModel.token = new JwtSecurityTokenHandler().WriteToken(JwtToken);
            authModel.refresh_token = newRefreshToken.Token;
            authModel.refresh_token_expiration = newRefreshToken.ExpiresOn;

            return authModel;
        }


    }
}