namespace DevCamp.Web.ViewModels.Users
{
    using System.ComponentModel.DataAnnotations;

    using DevCamp.Data.Models;
    using DevCamp.Services.Mapping;

    public class EditDescriptionViewModel : IMapFrom<ApplicationUser>
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "The field is required!")]
        [MinLength(20, ErrorMessage = "The field requires more than 20 characters!")]
        [MaxLength(200, ErrorMessage = "The field must not be more than 200 characters!")]
        public string Information { get; set; }
    }
}
