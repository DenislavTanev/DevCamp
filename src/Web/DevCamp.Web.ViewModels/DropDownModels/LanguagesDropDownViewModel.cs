namespace DevCamp.Web.ViewModels.DropDownModels
{
    using DevCamp.Data.Models;
    using DevCamp.Services.Mapping;

    public class LanguagesDropDownViewModel : IMapFrom<Language>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
