﻿namespace DevCamp.Web.ViewModels.Skills
{
    using DevCamp.Data.Models;
    using DevCamp.Services.Mapping;

    public class SkillsViewModel : IMapFrom<UserSkill>
    {
        public int SkillId { get; set; }

        public Skill Skill { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }
    }
}
