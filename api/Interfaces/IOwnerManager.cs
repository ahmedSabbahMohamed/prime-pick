using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Account.Owner;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Interfaces
{
    public interface IOwnerManager
    {
        IQueryable<Owner> Owners{ get; }
        Task<Owner> FindByEmailAsync(string email);
        Task<OwnerResult> CreateAsync(Owner owner, string Password);
        Task<OwnerResult> UpdateAsync(Owner owner);
        bool CheckPassword(Owner owner, string Password);
    }
}