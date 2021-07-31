namespace DevCamp.Data.Models
{
    using DevCamp.Data.Common.Models;

    public class Education : BaseDeletableModel<int>
    {
        public string UniversityName { get; set; }

        public string UniversityLocation { get; set; }

        public string Title { get; set; }

        public string Major { get; set; }

        public int GraduationYear { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }
    }
}
