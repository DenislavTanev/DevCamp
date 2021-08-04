namespace DevCamp.Web.ViewModels.PricePackages
{
    using System.ComponentModel.DataAnnotations;

    using DevCamp.Data.Models;
    using DevCamp.Services.Mapping;

    public class PackageItemEditInputModel : IMapTo<PackageItem>
    {
        public int Id { get; set; }

        [Required]
        public int PackageId { get; set; }

        [Required]
        public int ItemId { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "The field requires more than 1 characters!")]
        [MaxLength(15, ErrorMessage = "The field must not be more than 15 characters!")]
        public string Content { get; set; }
    }
}
