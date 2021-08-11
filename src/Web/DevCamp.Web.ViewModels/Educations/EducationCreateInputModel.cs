namespace DevCamp.Web.ViewModels.Educations
{
    using System.Collections.Generic;

    using DevCamp.Data.Models;
    using DevCamp.Services.Mapping;
    using DevCamp.Web.ViewModels.DropDownModels;

    public class EducationCreateInputModel : IMapTo<Education>
    {
        public string UniversityName { get; set; }

        public string UniversityLocation { get; set; }

        public string Title { get; set; }

        public string Major { get; set; }

        public int GraduationYear { get; set; }

        public string UserId { get; set; }

        public IEnumerable<CountriesDropDownViewModel> Countries { get; set; }

        public List<string> Titles { get; set; }

        public List<int> Years { get; set; }
    }
}
