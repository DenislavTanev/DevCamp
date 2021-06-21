namespace DevCamp.Web.ViewModels.Users
{
    using System;
    using System.Collections.Generic;

    using DevCamp.Data.Models;
    using DevCamp.Services.Mapping;

    public class UserViewModel : IMapFrom<ApplicationUser>
    {
        public string Name { get; set; }

        public string ProfilePic { get; set; }

        public string Information { get; set; }

        public DateTime CreatedOn { get; set; }

        public int CountryId { get; set; }

        public Country Country { get; set; }

        public ICollection<Language> SpokenLanguages { get; set; }

        public ICollection<Listing> Listings { get; set; }

        public ICollection<UserSkill> Skills { get; set; }
    }
}
