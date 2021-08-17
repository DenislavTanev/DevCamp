namespace DevCamp.Web.ViewModels.Home
{
    using System.Collections.Generic;

    using DevCamp.Data.Models;
    using DevCamp.Services.Mapping;
    using DevCamp.Web.ViewModels.DropDownModels;

    public class CategoriesViewModel
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public string CategoryImg { get; set; }

        public IEnumerable<SubCategoriesDropDownViewModel> SubCategories { get; set; }
    }
}
