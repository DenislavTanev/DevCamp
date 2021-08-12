namespace DevCamp.Web.ViewModels.Listings
{
    using System.ComponentModel.DataAnnotations;

    using DevCamp.Data.Models;
    using DevCamp.Services.Mapping;

    public class EditTitleInputModel : IMapTo<Listing>
    {
        public int Id { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(150)]
        public string Title { get; set; }
    }
}
