namespace DevCamp.Web.ViewModels.Languages
{
    using DevCamp.Data.Models;
    using DevCamp.Services.Mapping;

    public class UserLanguageViewModel : IMapFrom<UserLanguage>
    {
        public int Id { get; set; }

        public Language Language { get; set; }

        public int LevelId { get; set; }

        public Level Level { get; set; }
    }
}
