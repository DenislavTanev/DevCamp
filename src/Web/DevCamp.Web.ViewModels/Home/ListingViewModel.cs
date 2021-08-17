namespace DevCamp.Web.ViewModels.Home
{
    using System.Collections.Generic;

    using DevCamp.Data.Models;
    using DevCamp.Services.Mapping;
    using DevCamp.Web.ViewModels.Listings;

    public class ListingViewModel : IMapFrom<Listing>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public decimal StartingPrice { get; set; }

        public string UserId { get; set; }

        public UserForListingViewModel User { get; set; }

        public int CategoryId { get; set; }

        public int SubCategoryId { get; set; }

        public List<string> ListingImages { get; set; }
    }
}
