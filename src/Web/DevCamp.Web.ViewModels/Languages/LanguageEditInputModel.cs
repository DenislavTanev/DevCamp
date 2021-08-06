namespace DevCamp.Web.ViewModels.Languages
{
    using System.ComponentModel.DataAnnotations;

    using DevCamp.Data.Models;
    using DevCamp.Services.Mapping;

    public class LanguageEditInputModel : IMapTo<UserLanguage>
    {
        public int Id { get; set; }

        [Required]
        public int LanguageId { get; set; }

        [Required]
        public string Level { get; set; }
    }
}
