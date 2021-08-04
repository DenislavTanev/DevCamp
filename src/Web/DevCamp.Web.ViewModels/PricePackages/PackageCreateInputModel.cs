namespace DevCamp.Web.ViewModels.PricePackages

{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using DevCamp.Data.Models;
    using DevCamp.Services.Mapping;

    public class PackageCreateInputModel : IMapTo<Package>
    {
        [Required]
        public string Name { get; set; }

        public double Price { get; set; }

        [MinLength(5, ErrorMessage = "The field requires more than 5 characters!")]
        [MaxLength(50, ErrorMessage = "The field must not be more than 50 characters!")]
        public string Description { get; set; }

        public int ListingId { get; set; }

        public string Revisions { get; set; }

        public string DeliveryTime { get; set; }

        public IEnumerable<PackageItemCreateInputModel> Items { get; set; }
    }
}
