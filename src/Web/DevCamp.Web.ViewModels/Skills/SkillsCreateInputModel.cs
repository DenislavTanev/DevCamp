namespace DevCamp.Web.ViewModels.Skills
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using DevCamp.Data.Models;
    using DevCamp.Services.Mapping;
    using DevCamp.Web.ViewModels.DropDownModels;

    public class SkillsCreateInputModel : IMapTo<UserSkill>
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        public int SkillId { get; set; }

        public IEnumerable<SkillsDropDownViewModel> Skills { get; set; }
    }
}
