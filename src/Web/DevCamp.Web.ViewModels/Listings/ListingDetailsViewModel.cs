namespace DevCamp.Web.ViewModels.Listings
{
    using System.Collections.Generic;

    using DevCamp.Data.Models;
    using DevCamp.Services.Mapping;
    using DevCamp.Web.ViewModels.DropDownModels;
    using DevCamp.Web.ViewModels.FAQs;
    using DevCamp.Web.ViewModels.Images;

    public class ListingDetailsViewModel : IMapFrom<Listing>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string ProjectDetails { get; set; }

        public decimal? StartingPrice { get; set; }

        public SectorsDropDownViewModel Sector { get; set; }

        public CategoriesDropDownViewModel Category { get; set; }

        public SubCategoriesDropDownViewModel SubCategory { get; set; }

        public UserForListingViewModel User { get; set; }

        public PackagesViewModel BasicPackage { get; set; }

        public PackagesViewModel StandardPackage { get; set; }

        public PackagesViewModel PremiumPackage { get; set; }

        public ICollection<FaqViewModel> Faqs { get; set; }

        public List<string> ListingImages { get; set; }
    }
}
