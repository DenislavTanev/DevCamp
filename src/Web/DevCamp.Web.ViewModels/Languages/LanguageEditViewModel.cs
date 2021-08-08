namespace DevCamp.Web.ViewModels.Languages
{
    using System.Collections.Generic;

    using DevCamp.Data.Models;
    using DevCamp.Services.Mapping;
    using DevCamp.Web.ViewModels.DropDownModels;

    public class LanguageEditViewModel : IMapFrom<UserLanguage>
    {
        public int Id { get; set; }

        public string LanguageName { get; set; }

        public string LevelName { get; set; }

        public int LevelId { get; set; }

        public IEnumerable<LevelDropDownViewModel> Levels { get; set; }
    }
}
