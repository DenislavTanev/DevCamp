namespace DevCamp.Web.ViewModels.Languages
{
    using DevCamp.Data.Models;
    using DevCamp.Services.Mapping;

    public class LanguageEditViewModel : IMapFrom<UserLanguage>
    {
        public int Id { get; set; }

        public int LanguageId { get; set; }

        public string Name { get; set; }

        public string Level { get; set; }
    }
}
