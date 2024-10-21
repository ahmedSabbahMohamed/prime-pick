using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace api.Helpers
{
    public class ClaimsExtractor
    {
        public static string? ExtractEmailFromToken(string refreshToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            if (tokenHandler.CanReadToken(refreshToken))
            {
                var jwtToken = tokenHandler.ReadJwtToken(refreshToken); 
                
                var emailClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email);

                if (emailClaim != null)
                {
                    return emailClaim.Value;
                }
            }
            
            return null; 
        }
    }
}