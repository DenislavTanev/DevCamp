namespace DevCamp.Web.ViewModels.Listings
{
    using System.ComponentModel.DataAnnotations;

    using DevCamp.Data.Models;
    using DevCamp.Services.Mapping;

    public class EditDetailsInputModel : IMapTo<Listing>
    {
        public int Id { get; set; }

        [Required]
        [MinLength(40)]
        [MaxLength(1000)]
        public string ProjectDetails { get; set; }
    }
}
