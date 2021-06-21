using DevCamp.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevCamp.Data.Models
{
    public class UserLanguage : BaseDeletableModel<int>
    {
        public int LanguageId { get; set; }

        public Language Language { get; set; }

        public string UserId { get; set; }
    }
}
