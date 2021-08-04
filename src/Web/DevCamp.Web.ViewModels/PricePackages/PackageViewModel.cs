namespace DevCamp.Web.ViewModels.PricePackages
{
    using System.Collections.Generic;

    using DevCamp.Data.Models;
    using DevCamp.Services.Mapping;

    public class PackageViewModel : IMapFrom<Package>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public int ListingId { get; set; }
    }
}
