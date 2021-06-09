namespace DevCamp.Web.ViewModels.Listings
{
    using DevCamp.Data.Models;
    using DevCamp.Services.Mapping;

    public class ListingViewModel : IMapFrom<Listing>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public double? StartingPrice { get; set; }

        public string UserProfilePic { get; set; }

        public string Username { get; set; }
    }
}
