namespace DevCamp.Web.ViewModels.Listings
{
    using DevCamp.Data.Models;
    using DevCamp.Services.Mapping;

    public class ListingViewModel : IMapFrom<Listing>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string ProjectDetails { get; set; }

        public double? StartingPrice { get; set; }

        public string UserId { get; set; }

        public int CategoryId { get; set; }

        public int SubCategoryId { get; set; }
    }
}
