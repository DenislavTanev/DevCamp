namespace DevCamp.Data.Models
{
    using System.Collections.Generic;

    using DevCamp.Data.Common.Models;

    public class Country : BaseDeletableModel<int>
    {
        public Country()
        {
            this.Users = new HashSet<ApplicationUser>();
        }

        public string Name { get; set; }

        // Check
        public string Flag { get; set; }

        public ICollection<ApplicationUser> Users { get; set; }
    }
}
