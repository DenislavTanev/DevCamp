using DevCamp.Data.Models;
using DevCamp.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevCamp.Web.ViewModels.Languages
{
    public class UserLanguageViewModel : IMapFrom<UserLanguage>
    {
        public int LanguageId { get; set; }

        public Language Language { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public int LevelId { get; set; }

        public Level Level { get; set; }
    }
}
