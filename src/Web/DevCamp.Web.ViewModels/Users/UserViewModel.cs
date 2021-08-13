namespace DevCamp.Web.ViewModels.Users
{
    using System;
    using System.Collections.Generic;

    using DevCamp.Data.Models;
    using DevCamp.Services.Mapping;
    using DevCamp.Web.ViewModels.Certifications;
    using DevCamp.Web.ViewModels.DropDownModels;
    using DevCamp.Web.ViewModels.Educations;
    using DevCamp.Web.ViewModels.Languages;
    using DevCamp.Web.ViewModels.Listings;
    using DevCamp.Web.ViewModels.Skills;

    public class UserViewModel : IMapFrom<ApplicationUser>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string ProfilePicture { get; set; }

        public string Information { get; set; }

        public string Profession { get; set; }

        public DateTime CreatedOn { get; set; }

        public CountriesDropDownViewModel Country { get; set; }

        public ICollection<UserLanguageViewModel> SpokenLanguages { get; set; }

        public ICollection<ListingViewModel> Listings { get; set; }

        public ICollection<SkillsViewModel> Skills { get; set; }

        public ICollection<EducationViewModel> Educations { get; set; }

        public ICollection<CertificationViewModel> Certifications { get; set; }
    }
}
