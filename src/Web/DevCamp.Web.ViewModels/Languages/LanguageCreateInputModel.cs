namespace DevCamp.Web.ViewModels.Languages
{
    using DevCamp.Data.Models;
    using DevCamp.Services.Mapping;
    using DevCamp.Web.ViewModels.DropDownModels;
    using System.Collections.Generic;

    public class LanguageCreateInputModel : IMapTo<UserLanguage>
    {

        public string UserId { get; set; }

        public IEnumerable<LanguagesDropDownViewModel> Languages { get; set; }

        public int LanguageId { get; set; }

        public string Level { get; set; }
    }
}
