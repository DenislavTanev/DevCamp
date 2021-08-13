namespace DevCamp.Web.ViewModels.Educations
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using DevCamp.Data.Models;
    using DevCamp.Services.Mapping;
    using DevCamp.Web.ViewModels.DropDownModels;

    public class EducationCreateInputModel : IMapTo<Education>
    {
        [Required(ErrorMessage = "The field is required!")]
        [MinLength(3, ErrorMessage = "The field requires more than 3 characters!")]
        [MaxLength(30, ErrorMessage = "The field must not be more than 30 characters!")]
        public string UniversityName { get; set; }

        [Required]
        public string UniversityLocation { get; set; }

        [Required]
        public string Title { get; set; }

        [Required(ErrorMessage = "The field is required!")]
        [MinLength(3, ErrorMessage = "The field requires more than 3 characters!")]
        [MaxLength(30, ErrorMessage = "The field must not be more than 30 characters!")]
        public string Major { get; set; }

        [Required]
        [Range(1980, 2021, ErrorMessage = "This value must be between 1980 and 2021!")]
        public int GraduationYear { get; set; }

        [Required]
        public string UserId { get; set; }

        public IEnumerable<CountriesDropDownViewModel> Countries { get; set; }

        public List<string> Titles { get; set; }

        public List<int> Years { get; set; }
    }
}
