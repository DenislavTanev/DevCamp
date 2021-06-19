namespace DevCamp.Web.ViewModels.Users
{
    using System.Collections.Generic;

    using DevCamp.Data.Models;

    public class UserViewModel
    {
        public string Name { get; set; }

        public string ProfilePic { get; set; }

        public string Information { get; set; }

        public int CountryId { get; set; }

        public Country Country { get; set; }

        public ICollection<Language> SpokenLanguages { get; set; }

        public ICollection<Listing> Listings { get; set; }

        public ICollection<UserSkill> Skills { get; set; }
    }
}
