namespace DevCamp.Web.ViewModels.Listings
{
    using System.Collections.Generic;

    using DevCamp.Data.Models;
    using DevCamp.Services.Mapping;
    using DevCamp.Web.ViewModels.FAQs;
    using DevCamp.Web.ViewModels.Packages;

    public class ListingDetailsViewModel : IMapFrom<Listing>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string ProjectDetails { get; set; }

        public double? StartingPrice { get; set; }

        public string UserId { get; set; }

        public int CategoryId { get; set; }

        public int SubCategoryId { get; set; }

        public ICollection<PackageViewModel> Packages { get; set; }

        public ICollection<FaqViewModel> Faqs { get; set; }
    }
}
