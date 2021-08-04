namespace DevCamp.Web.ViewModels.PricePackages
{
    using DevCamp.Data.Models;
    using DevCamp.Services.Mapping;

    public class PackageEditViewModel : IMapFrom<Package>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public int ListingId { get; set; }

        public PackageItemCreateInputModel Items { get; set; }
    }
}
