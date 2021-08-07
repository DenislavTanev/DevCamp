namespace DevCamp.Web.ViewModels.Languages
{
    using System.Collections.Generic;

    using DevCamp.Data.Models;
    using DevCamp.Services.Mapping;
    using DevCamp.Web.ViewModels.DropDownModels;

    public class LanguageCreateInputModel : IMapTo<UserLanguage>
    {
        public string UserId { get; set; }

        public IEnumerable<LanguagesDropDownViewModel> Languages { get; set; }

        public IEnumerable<LevelDropDownViewModel> Levels { get; set; }

        public int LevelId { get; set; }

        public int LanguageId { get; set; }
    }
}
