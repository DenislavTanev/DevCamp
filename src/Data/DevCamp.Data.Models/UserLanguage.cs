namespace DevCamp.Data.Models
{
    using DevCamp.Data.Common.Models;

    public class UserLanguage : BaseDeletableModel<int>
    {
        public int LanguageId { get; set; }

        public Language Language { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public string Level { get; set; }
    }
}
