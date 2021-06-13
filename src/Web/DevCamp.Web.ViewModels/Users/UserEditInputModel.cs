namespace DevCamp.Web.ViewModels.Users
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using DevCamp.Data.Models;

    public class UserEditInputModel
    {
        [Required(ErrorMessage = "The field is required!")]
        [MinLength(3, ErrorMessage = "The field requires more than 3 characters!")]
        [MaxLength(30, ErrorMessage = "The field must not be more than 30 characters!")]
        public string Name { get; set; }

        [Required]
        public string ProfilePic { get; set; }

        [Required(ErrorMessage = "The field is required!")]
        [MinLength(5, ErrorMessage = "The field requires more than 5 characters!")]
        [MaxLength(500, ErrorMessage = "The field must not be more than 500 characters!")]
        public string Information { get; set; }

        [Required]
        public int CountryId { get; set; }

        public ICollection<Language> SpokenLanguages { get; set; }
    }
}
