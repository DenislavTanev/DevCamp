namespace DevCamp.Web.ViewModels.Listings
{
    using DevCamp.Data.Models;
    using DevCamp.Services.Mapping;

    public class ListingPackagesViewModel : IMapFrom<Listing>
    {
        public int ListingId { get; set; }

        public PackagesViewModel BasicPackage { get; set; }

        public PackagesViewModel StandardPackage { get; set; }

        public PackagesViewModel PremiumPackage { get; set; }
    }
}
