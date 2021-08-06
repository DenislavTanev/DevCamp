namespace DevCamp.Web.ViewModels.Languages
{
    using DevCamp.Data.Models;
    using DevCamp.Services.Mapping;

    public class LanguageCreateInputModel : IMapTo<UserLanguage>
    {
        public int LanguageId { get; set; }

        public string Level { get; set; }
    }
}
