namespace DevCamp.Web.ViewModels.Listings
{
    using DevCamp.Data.Models;
    using DevCamp.Services.Mapping;

    public class ListingViewModel : IMapFrom<Listing>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public decimal? StartingPrice { get; set; }

        public byte[] UserProfilePic { get; set; }

        public string Username { get; set; }
    }
}
