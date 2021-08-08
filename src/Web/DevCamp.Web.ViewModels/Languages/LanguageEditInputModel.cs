namespace DevCamp.Web.ViewModels.Languages
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using DevCamp.Data.Models;
    using DevCamp.Services.Mapping;
    using DevCamp.Web.ViewModels.DropDownModels;

    public class LanguageEditInputModel : IMapTo<UserLanguage>
    {
        [Required]
        public int Id { get; set; }

        public string LanguageName { get; set; }

        public string LevelName { get; set; }

        [Required]
        public int LevelId { get; set; }

        public IEnumerable<LevelDropDownViewModel> Levels { get; set; }
    }
}
