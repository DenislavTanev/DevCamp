namespace DevCamp.Web.ViewModels.Educations
{
    using DevCamp.Data.Models;
    using DevCamp.Services.Mapping;

    public class EducationViewModel : IMapFrom<Education>
    {
        public int Id { get; set; }

        public string UniversityName { get; set; }

        public string UniversityLocation { get; set; }

        public string Title { get; set; }

        public string Major { get; set; }

        public int GraduationYear { get; set; }
    }
}
