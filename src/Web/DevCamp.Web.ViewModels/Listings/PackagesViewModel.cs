namespace DevCamp.Web.ViewModels.Listings
{
    using DevCamp.Data.Models;
    using DevCamp.Services.Mapping;

    public class PackagesViewModel : IMapFrom<Package>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public string Description { get; set; }

        public int ListingId { get; set; }

        public string Revisions { get; set; }

        public string DeliveryTime { get; set; }
    }
}
