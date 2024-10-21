using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace api.ProgramExtensions
{
    public static class AddJwtAuthService
    {
        public static void AddJwtAuthExt(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(op => {
                op.DefaultAuthenticateScheme = 
                op.DefaultChallengeScheme = 
                op.DefaultForbidScheme = 
                op.DefaultScheme =
                op.DefaultSignInScheme = 
                op.DefaultSignOutScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(op =>{
                op.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = configuration["JWT:Issuer"],
                    ValidateAudience = true,
                    ValidAudience = configuration["JWT:Audience"],
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        System.Text.Encoding.UTF8.GetBytes(configuration["JWT:SigningKey"])
                    
                    ),
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });
        }
    }
}