namespace DevCamp.Data.Models
{
    using System.Collections.Generic;

    using DevCamp.Data.Common.Models;

    public class Skill : BaseDeletableModel<string>
    {
        public Skill()
        {
            this.Users = new HashSet<ApplicationUser>();
        }

        public string TechnologyName { get; set; }

        public string Icon { get; set; }

        public ICollection<ApplicationUser> Users { get; set; }
    }
}
