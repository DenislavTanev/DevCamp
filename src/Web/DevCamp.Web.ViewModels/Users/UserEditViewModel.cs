namespace DevCamp.Web.ViewModels.Users
{
    using System.Collections.Generic;

    using DevCamp.Data.Models;

    public class UserEditViewModel
    {
        public string Name { get; set; }

        public string ProfilePic { get; set; }

        public string Information { get; set; }

        public int CountryId { get; set; }

        public ICollection<Language> SpokenLanguages { get; set; }
    }
}
