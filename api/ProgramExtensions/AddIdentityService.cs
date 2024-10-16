using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.AspNetCore.Identity;
using api.Data;

namespace api.ProgramExtensions
{
    public static class AddIdentityService
    {
        public static void AddIdentityExt(this IServiceCollection services)
        {
            services.AddIdentity<AppUser, IdentityRole>(op =>{
                op.Password.RequiredLength = 12;
                op.Password.RequireDigit = true;
                op.Password.RequireUppercase = true;
                op.Password.RequireLowercase = true;
                op.Password.RequireNonAlphanumeric = true;
            })
            .AddEntityFrameworkStores<AppDbContext>();
        }
    }
}