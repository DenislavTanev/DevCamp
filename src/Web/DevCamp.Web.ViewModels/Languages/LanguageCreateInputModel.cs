namespace DevCamp.Web.ViewModels.Languages
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using DevCamp.Data.Models;
    using DevCamp.Services.Mapping;
    using DevCamp.Web.ViewModels.DropDownModels;

    public class LanguageCreateInputModel : IMapTo<UserLanguage>
    {
        [Required]
        public string UserId { get; set; }

        public IEnumerable<LanguagesDropDownViewModel> Languages { get; set; }

        public IEnumerable<LevelDropDownViewModel> Levels { get; set; }

        [Required]
        public int LevelId { get; set; }

        [Required]
        public int LanguageId { get; set; }
    }
}
