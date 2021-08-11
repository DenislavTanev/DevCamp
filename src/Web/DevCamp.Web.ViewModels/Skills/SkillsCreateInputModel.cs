namespace DevCamp.Web.ViewModels.Skills
{
    using System.Collections.Generic;

    using DevCamp.Data.Models;
    using DevCamp.Services.Mapping;
    using DevCamp.Web.ViewModels.DropDownModels;

    public class SkillsCreateInputModel : IMapTo<UserSkill>
    {
        public string UserId { get; set; }

        public int SkillId { get; set; }

        public IEnumerable<SkillsDropDownViewModel> Skills { get; set; }
    }
}
