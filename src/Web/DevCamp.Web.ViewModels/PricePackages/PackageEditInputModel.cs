namespace DevCamp.Web.ViewModels.PricePackages
{
    using System.ComponentModel.DataAnnotations;

    using DevCamp.Data.Models;
    using DevCamp.Services.Mapping;

    public class PackageEditInputModel : IMapTo<Package>
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "The field requires more than 5 characters!")]
        [MaxLength(50, ErrorMessage = "The field must not be more than 50 characters!")]
        public string Description { get; set; }

        public int ListingId { get; set; }

        public PackageItemEditInputModel Items { get; set; }
    }
}
