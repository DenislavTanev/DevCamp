namespace DevCamp.Data.Models
{
    using System.Collections.Generic;

    using DevCamp.Data.Common.Models;

    public class Skill : BaseDeletableModel<int>
    {
        public Skill()
        {
            this.Users = new HashSet<UserSkill>();
        }

        public string TechnologyName { get; set; }

        public string Level { get; set; }

        public ICollection<UserSkill> Users { get; set; }
    }
}
