namespace DevCamp.Web.ViewModels.Skills
{
    using DevCamp.Data.Models;
    using DevCamp.Services.Mapping;

    public class SkillsViewModel : IMapFrom<UserSkill>
    {
        public int Id { get; set; }

        public Skill Skill { get; set; }
    }
}
