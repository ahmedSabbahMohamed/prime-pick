using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;


namespace api.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _config;
        private readonly SymmetricSecurityKey _key;
        private readonly UserManager<AppUser> _userManager;
        public TokenService(IConfiguration config, UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            _config = config;
            _key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(config["JWT:SigningKey"]));
        }

        public async Task<SecurityToken> CreateToken(AppUser user)
        {

            List<Claim> claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.GivenName, user.Name),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
            };

            IList<string> roles = await _userManager.GetRolesAsync(user);

            foreach (string role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role.ToString()));
            }

            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDiscriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddSeconds(60),
                SigningCredentials = creds,
                Issuer = _config["JWT:Issuer"],
                Audience = _config["JWT:Audience"]
            };

            var TokenHandler = new JwtSecurityTokenHandler();
            var Token = TokenHandler.CreateToken(tokenDiscriptor);

            return Token;
        }

        public SecurityToken CreateToken(Owner owner)
        {

            List<Claim> claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Email, owner.Email),
                new Claim(JwtRegisteredClaimNames.GivenName, owner.Name),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, owner.OwnerId),
                new Claim(ClaimTypes.Role, "Owner"),
            };

            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDiscriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddSeconds(60),
                SigningCredentials = creds,
                Issuer = _config["JWT:Issuer"],
                Audience = _config["JWT:Audience"]
            };

            var TokenHandler = new JwtSecurityTokenHandler();
            var Token = TokenHandler.CreateToken(tokenDiscriptor);

            return Token;
        }

        public RefreshToken CreateRefreshToken()
        {
            var refreshToken = Guid.NewGuid().ToString();

            return new RefreshToken
            {
                Token = refreshToken,
                ExpiresOn = DateTime.UtcNow.AddMinutes(2),
                CreatedOn = DateTime.UtcNow,
                
            };
        }
    }
}