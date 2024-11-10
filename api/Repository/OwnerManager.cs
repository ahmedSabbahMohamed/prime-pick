using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.Account.Owner;
using api.Interfaces;
using api.Migrations;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class OwnerManager : IOwnerManager
    {
        private readonly AppDbContext _db;
        private readonly PasswordHasher<Owner> _passwordHasher = new PasswordHasher<Owner>();

        IQueryable<Owner> IOwnerManager.Owners => _db.Owners;

        public OwnerManager(AppDbContext db)
        {
            _db = db;
        }

        public bool CheckPassword(Owner owner, string Password)
        {
            var verificationResult = _passwordHasher.VerifyHashedPassword(owner, owner.PasswordHash, Password);

            return verificationResult == PasswordVerificationResult.Success;
        }

        public async Task<OwnerResult> CreateAsync(Owner owner, string Password)
        {
            OwnerResult ownerResult = new OwnerResult();
            try
            {
                owner.PasswordHash = _passwordHasher.HashPassword(owner, Password);
                owner.OwnerId = Guid.NewGuid().ToString();

                await _db.Owners.AddAsync(owner);
                await _db.SaveChangesAsync();
                ownerResult.Succeeded = true;

                return ownerResult;
            }
            catch (Exception ex)
            {
                ownerResult.Error = ex.Message;
                ownerResult.Succeeded = false;

                return ownerResult;
            }
        }

        public async Task<Owner> FindByEmailAsync(string email)
        {
            return await _db.Owners.FirstOrDefaultAsync(o => o.Email == email);
        }

        public async Task<OwnerResult> UpdateAsync(Owner owner)
        {
            OwnerResult ownerResult = new OwnerResult();

            try
            {
                await _db.SaveChangesAsync();
                ownerResult.Succeeded = true;
                return ownerResult;
            }
            catch (Exception ex)
            {
                ownerResult.Error = ex.Message;
                ownerResult.Succeeded = false;

                return ownerResult;
            }
        }
    }
}