using DevCamp.Data.Models;
using DevCamp.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevCamp.Web.ViewModels.Educations
{
    public class EducationViewModel : IMapFrom<Education>
    {
        public int Id { get; set; }

        public string UniversityName { get; set; }

        public string UniversityLocation { get; set; }

        public string Title { get; set; }

        public string Major { get; set; }

        public int GraduationYear { get; set; }

        public string UserId { get; set; }
    }
}
