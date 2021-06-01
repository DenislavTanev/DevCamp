namespace DevCamp.Data.Models
{
    using System.Collections.Generic;

    using DevCamp.Data.Common.Models;

    public class Skill : BaseDeletableModel<int>
    {
        public Skill()
        {
            this.Users = new HashSet<UserSkill>();
            this.Listings = new HashSet<ListingSkill>();
        }

        public string TechnologyName { get; set; }

        public string Icon { get; set; }

        public ICollection<UserSkill> Users { get; set; }

        public ICollection<ListingSkill> Listings { get; set; }
    }
}
