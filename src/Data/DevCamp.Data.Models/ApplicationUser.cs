// ReSharper disable VirtualMemberCallInConstructor
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
            this.Listings = new HashSet<Listing>();
            this.Skills = new HashSet<UserSkill>();
            this.Achievements = new HashSet<UserAchievement>();
            this.SpokenLanguages = new HashSet<UserLanguage>();
            this.Educations = new HashSet<Education>();
            this.Certifications = new HashSet<Certification>();
        }

        // Audit info
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        // Deletable entity
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        // Personal info
        public string Name { get; set; }

        public int? CountryId { get; set; }

        public Country Country { get; set; }

        public string Information { get; set; }

        public string Profession { get; set; }

        public TimeSpan ResponseTime { get; set; }

        public DateTime LastDelivery { get; set; }

        public byte[] ProfilePic { get; set; }

        public ICollection<UserLanguage> SpokenLanguages { get; set; }

        public ICollection<Listing> Listings { get; set; }

        public ICollection<UserSkill> Skills { get; set; }

        public ICollection<UserAchievement> Achievements { get; set; }

        public ICollection<Education> Educations { get; set; }

        public ICollection<Certification> Certifications { get; set; }

        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }

        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }

        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }
    }
}
