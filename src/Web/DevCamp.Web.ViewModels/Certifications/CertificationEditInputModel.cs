namespace DevCamp.Web.ViewModels.Certifications
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using DevCamp.Data.Models;
    using DevCamp.Services.Mapping;

    public class CertificationEditInputModel : IMapTo<Certification>
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "The field requires more than 5 characters!")]
        [MaxLength(40, ErrorMessage = "The field must not be more than 40 characters!")]
        public string Certificate { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "The field requires more than 5 characters!")]
        [MaxLength(40, ErrorMessage = "The field must not be more than 40 characters!")]
        public string CertifiedFrom { get; set; }

        [Required]
        [Range(1980, 2021, ErrorMessage = "This value must be between 1980 and 2021!")]
        public int Year { get; set; }

        [Required]
        public string UserId { get; set; }

        public List<int> Years { get; set; }
    }
}
