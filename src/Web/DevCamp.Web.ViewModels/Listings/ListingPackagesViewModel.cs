namespace DevCamp.Web.ViewModels.Listings
{
    using System.Collections.Generic;

    using DevCamp.Data.Models;
    using DevCamp.Services.Mapping;

    public class ListingPackagesViewModel : IMapFrom<Listing>
    {
        public int ListingId { get; set; }

        public IEnumerable<PackagesViewModel> Packages { get; set; }
    }
}
