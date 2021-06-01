namespace DevCamp.Data.Models
{
    using System.Collections.Generic;

    using DevCamp.Data.Common.Models;

    public class Skill : BaseDeletableModel<int>
    {
        public Skill()
        {
            this.Users = new HashSet<ApplicationUser>();
            this.Listings = new HashSet<Listing>();
        }

        public string TechnologyName { get; set; }

        public string Icon { get; set; }

        public ICollection<ApplicationUser> Users { get; set; }

        public ICollection<Listing> Listings { get; set; }
    }
}
