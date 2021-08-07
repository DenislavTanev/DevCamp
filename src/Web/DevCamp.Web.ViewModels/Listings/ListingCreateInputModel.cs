namespace DevCamp.Web.ViewModels.Listings
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    using DevCamp.Data.Models;
    using DevCamp.Services.Mapping;
    using DevCamp.Web.ViewModels.DropDownModels;

    public class ListingCreateInputModel : IMapTo<Listing>
    {
        [Required(ErrorMessage = "The field is required!")]
        [MinLength(5, ErrorMessage = "The field requires more than 5 characters!")]
        [MaxLength(200, ErrorMessage = "The field must not be more than 200 characters!")]
        [DisplayName("Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "The field is required!")]
        [MinLength(20, ErrorMessage = "The field requires more than 20 characters!")]
        [MaxLength(1000, ErrorMessage = "The field must not be more than 1000 characters!")]
        [DisplayName("Gig Information")]
        public string ProjectDetails { get; set; }

        public string UserId { get; set; }

        [Required(ErrorMessage = "The field is required!")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "The field is required!")]
        public int SubCategoryId { get; set; }

        [Required(ErrorMessage = "The field is required!")]
        public int SectorId { get; set; }

        public IEnumerable<CategoriesDropDownViewModel> Categories { get; set; }

        public IEnumerable<SectorsDropDownViewModel> Sectors { get; set; }

        public IEnumerable<SubCategoriesDropDownViewModel> SubCategories { get; set; }
    }
}
