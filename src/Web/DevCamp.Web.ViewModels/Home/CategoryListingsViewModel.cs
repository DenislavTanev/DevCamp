namespace DevCamp.Web.ViewModels.Home
{
    using System.Collections.Generic;

    using DevCamp.Web.ViewModels.DropDownModels;

    public class CategoryListingsViewModel
    {
        public CategoriesDropDownViewModel Category { get; set; }

        public SubCategoriesDropDownViewModel SubCategory { get; set; }

        public List<SubCategoriesDropDownViewModel> SubCategories { get; set; }

        public SectorsDropDownViewModel Sector { get; set; }

        public List<CategoriesDropDownViewModel> Categories { get; set; }

        public List<ListingViewModel> Listings { get; set; }

        public int ListingsCount { get; set; }
    }
}
