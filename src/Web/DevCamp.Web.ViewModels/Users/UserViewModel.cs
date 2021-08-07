namespace DevCamp.Web.ViewModels.Users
{
    using System;
    using System.Collections.Generic;

    using DevCamp.Data.Models;
    using DevCamp.Services.Mapping;
    using DevCamp.Web.ViewModels.Languages;
    using DevCamp.Web.ViewModels.Listings;

    public class UserViewModel : IMapFrom<ApplicationUser>
    {
        public string Name { get; set; }

        public byte[] ProfilePic { get; set; }

        public string Information { get; set; }

        public string Profession { get; set; }

        public TimeSpan ResponseTime { get; set; }

        public DateTime CreatedOn { get; set; }

        public int CountryId { get; set; }

        public Country Country { get; set; }

        public ICollection<UserLanguageViewModel> SpokenLanguages { get; set; }

        public ICollection<ListingViewModel> Listings { get; set; }

        public ICollection<UserSkill> Skills { get; set; }

        public ICollection<Education> Educations { get; set; }

        public ICollection<Certification> Certifications { get; set; }
    }
}
