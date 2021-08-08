namespace DevCamp.Web.ViewModels.Users
{
    using System.ComponentModel.DataAnnotations;

    using DevCamp.Data.Models;
    using DevCamp.Services.Mapping;

    public class EditProfessionViewModel : IMapFrom<ApplicationUser>
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "The field is required!")]
        [MinLength(10, ErrorMessage = "The field requires more than 10 characters!")]
        [MaxLength(50, ErrorMessage = "The field must not be more than 50 characters!")]
        public string Profession { get; set; }
    }
}
