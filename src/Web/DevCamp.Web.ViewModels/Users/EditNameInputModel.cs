namespace DevCamp.Web.ViewModels.Users
{
    using System.ComponentModel.DataAnnotations;

    using DevCamp.Data.Models;
    using DevCamp.Services.Mapping;

    public class EditNameInputModel : IMapTo<ApplicationUser>
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "The field is required!")]
        [MinLength(3, ErrorMessage = "The field requires more than 3 characters!")]
        [MaxLength(30, ErrorMessage = "The field must not be more than 30 characters!")]
        public string Name { get; set; }
    }
}
