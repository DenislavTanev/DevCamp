namespace DevCamp.Web.ViewModels.Listings
{
    using System;

    using DevCamp.Data.Models;
    using DevCamp.Services.Mapping;

    public class UserForListingViewModel : IMapFrom<ApplicationUser>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string ProfilePicture { get; set; }

        public string Information { get; set; }

        public string Profession { get; set; }

        public DateTime CreatedOn { get; set; }

        public Country Country { get; set; }
    }
}
