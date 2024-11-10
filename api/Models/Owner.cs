using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Owner
    {
        public string? OwnerId { get; set; } // Primary Key
        public string? Email { get; set; }
        public string? PasswordHash { get; set; }

        // Contact Info
        public string? Name { get; set; }
        public string? ContactNumber { get; set; }
        public string? AlternativeContactNumber { get; set; }
        public bool EmailVerified { get; set; }

        // Business Info
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; }

        // Booking and Availability
        public bool CanAcceptBookings { get; set; }

        // Profile & Business Details
        public string? ProfileImageUrl { get; set; }
        public string? SocialMediaLinks { get; set; }

        public List<RefreshToken>? RefreshTokens { get; set; } = new List<RefreshToken>();
        //public List<Stay>? Stays { get; set; }
    }
}