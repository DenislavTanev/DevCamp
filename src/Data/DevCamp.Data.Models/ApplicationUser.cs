﻿// ReSharper disable VirtualMemberCallInConstructor
namespace DevCamp.Data.Models
{
    using System;
    using System.Collections.Generic;

    using DevCamp.Data.Common.Models;

    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser, IAuditInfo, IDeletableEntity
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Roles = new HashSet<IdentityUserRole<string>>();
            this.Claims = new HashSet<IdentityUserClaim<string>>();
            this.Logins = new HashSet<IdentityUserLogin<string>>();
            this.FrequentlyAskedQuestions = new HashSet<FrequentlyAskedQuestion>();
            this.Listings = new HashSet<Listing>();
            this.Skills = new HashSet<Skill>();
            this.Achievements = new HashSet<Achievement>();
            this.WrittenReviews = new HashSet<Review>();
            this.Payments = new HashSet<Payment>();
        }

        // Audit info
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        // Deletable entity
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        // Personal info
        public string Name { get; set; }

        public string Location { get; set; }

        public string Information { get; set; }

        // Check
        public string ProfilePic { get; set; }

        public ICollection<Listing> Listings { get; set; }

        public ICollection<Skill> Skills { get; set; }

        public ICollection<Achievement> Achievements { get; set; }

        public ICollection<FrequentlyAskedQuestion> FrequentlyAskedQuestions { get; set; }

        public ICollection<Review> WrittenReviews { get; set; }

        public ICollection<Payment> Payments { get; set; }

        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }

        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }

        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }
    }
}
