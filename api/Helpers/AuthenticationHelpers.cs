using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Account;
using api.DTOs.Account.Owner;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace api.Helpers
{
    public class AuthenticationHelpers
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IOwnerManager _ownerManager;
        private readonly ITokenService _tokenService;
        public AuthenticationHelpers(UserManager<AppUser> userManager, ITokenService tokenService, IOwnerManager ownerManager)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _ownerManager = ownerManager;
        }


        public async Task<AuthDTO> HandleExistingUserRegistrationAsync(AppUser user, string Role)
        {
            if(await _userManager.IsInRoleAsync(user, Role))
                return new AuthDTO { message = "Email is Already Registered!" };
            else
            {
                var addRole = await _userManager.AddToRoleAsync(user, Role);

                if(!addRole.Succeeded)
                {
                    return new AuthDTO { message = FormatErrors(addRole.Errors) };
                }

                return await GenerateAuthDtoWithToken(user);
            }
        }

        public async Task<AuthDTO> RegisterNewUserAsync(RegisterDTO register)
        {
            AppUser newUser = new AppUser
            {
                UserName = register.email.ToLower(),
                Name = register.name,
                Email = register.email.ToLower(),
                PhoneNumber = register.phone
            };

            var Result = await _userManager.CreateAsync(newUser, register.password);

            if(!Result.Succeeded)
            {
                return new AuthDTO { message = FormatErrors(Result.Errors) };
            }

            var addedToRole = await _userManager.AddToRoleAsync(newUser, "User");

            if(!addedToRole.Succeeded)
            {
                return new AuthDTO { message = FormatErrors(addedToRole.Errors) };
            }

            return await GenerateAuthDtoWithToken(newUser);

        }

        public async Task<AuthDTO> RegisterNewAdminAsync(RegisterDTO adminRegisterDTO)
        {
            AppUser newAdmin = new AppUser
            {
                UserName = adminRegisterDTO.email,
                Name = adminRegisterDTO.name,
                Email = adminRegisterDTO.email,
                PhoneNumber = adminRegisterDTO.phone
            };

            var Result = await _userManager.CreateAsync(newAdmin, adminRegisterDTO.password);

            if(!Result.Succeeded)
            {
                return new AuthDTO { message = FormatErrors(Result.Errors) };
            }

            var addedToRole = await _userManager.AddToRoleAsync(newAdmin, "Admin");

            if(!addedToRole.Succeeded)
            {
                return new AuthDTO { message = FormatErrors(addedToRole.Errors) };
            }

            return await GenerateAuthDtoWithToken(newAdmin);

        }

        public async Task<OwnerAuthDTO> RegisterNewOwnerAsync(OwnerRegisterDTO ownerRegisterDTO)
        {
            Owner NewOwner = new Owner
            {
                Name = ownerRegisterDTO.first_name + " " + ownerRegisterDTO.last_name,
                Email = ownerRegisterDTO.email.ToLower(),
                ContactNumber = ownerRegisterDTO.phone
            };

            var Result = await _ownerManager.CreateAsync(NewOwner, ownerRegisterDTO.password);

            if (!Result.Succeeded)
            {
                return new OwnerAuthDTO { message = Result.Error };
            }
            
            return await GenerateOwnerAuthDtoWithToken(NewOwner);
        }

        public async Task<AuthDTO> UserRefreshToken(string token)
        {
            AuthDTO authModel= new AuthDTO();

            var user = await _userManager.Users
                .Include(u => u.RefreshTokens)
                .FirstOrDefaultAsync(u => u.RefreshTokens.Any(t => t.Token == token));

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

            var JwtToken = await _tokenService.CreateToken(user);
            authModel.is_authenticated = true;
            authModel.token = new JwtSecurityTokenHandler().WriteToken(JwtToken);
            authModel.refresh_token = newRefreshToken.Token;
            authModel.refresh_token_expiration = newRefreshToken.ExpiresOn;

            return authModel;
        }

        public async Task<AuthDTO> OwnerRefreshToken(string token)
        {
            AuthDTO authModel = new AuthDTO();

            var owner = await _ownerManager.Owners
                .Include(u => u.RefreshTokens)
                .FirstOrDefaultAsync(u => u.RefreshTokens.Any(t => t.Token == token));

            if(owner == null)
            {
                authModel.message = "Invalid Token";
                return authModel;
            }


            var refreshToken = owner.RefreshTokens.Single(t => t.Token == token);

            if(!refreshToken.IsActive)
            {
                authModel.message = "Inactive Token";
                return authModel;
            }

            refreshToken.RevokedOn = DateTime.UtcNow;

            RefreshToken newRefreshToken = _tokenService.CreateRefreshToken();
            owner.RefreshTokens.Add(newRefreshToken);
            await _ownerManager.UpdateAsync(owner);

            var JwtToken = _tokenService.CreateToken(owner);
            authModel.is_authenticated = true;
            authModel.token = new JwtSecurityTokenHandler().WriteToken(JwtToken);
            authModel.refresh_token = newRefreshToken.Token;
            authModel.refresh_token_expiration = newRefreshToken.ExpiresOn;

            return authModel;
        }




        private async Task<OwnerAuthDTO> GenerateOwnerAuthDtoWithToken(Owner owner)
        {
            var token = _tokenService.CreateToken(owner);
            var RefreshToken = _tokenService.CreateRefreshToken();
            owner.RefreshTokens.Add(RefreshToken);
            await _ownerManager.UpdateAsync(owner);


            return new OwnerAuthDTO 
            {
                name = owner.Name,
                email = owner.Email,
                is_authenticated = true,
                role = "Owner",
                token = new JwtSecurityTokenHandler().WriteToken(token),
                refresh_token = RefreshToken.Token,
                refresh_token_expiration = RefreshToken.ExpiresOn
            };
        }

        private async Task<AuthDTO> GenerateAuthDtoWithToken(AppUser user)
        {
            var newToken = await _tokenService.CreateToken(user);
            var newRefreshToken = _tokenService.CreateRefreshToken();
            user.RefreshTokens.Add(newRefreshToken);
            await _userManager.UpdateAsync(user);
            var Roles = await _userManager.GetRolesAsync(user);


            return new AuthDTO 
            {
                name = user.Name,
                email = user.Email,
                is_authenticated = true,
                roles = Roles.ToList(),
                token = new JwtSecurityTokenHandler().WriteToken(newToken),
                refresh_token = newRefreshToken.Token,
                refresh_token_expiration = newRefreshToken.ExpiresOn
            };
        }

        private string FormatErrors(IEnumerable<IdentityError> errors)
        {
            string TotalErrors = string.Empty;

            foreach(var error in errors)
            {
                TotalErrors += $"{error.Description.Substring(0, error.Description.Length - 1)}, ";
            }
            
            return $"{TotalErrors.Substring(0, TotalErrors.Length - 2)}";
        }


    }
}