namespace DevCamp.Data.Models
{
    using DevCamp.Data.Common.Models;

    public class UserSkill : BaseDeletableModel<int>
    {
        public int SkillId { get; set; }

        public Skill Skill { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }
    }
}
