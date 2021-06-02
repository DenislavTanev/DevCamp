namespace DevCamp.Data.Models
{
    using System.Collections.Generic;

    using DevCamp.Data.Common.Models;

    public class Language : BaseDeletableModel<int>
    {
        public Language()
        {
            this.Users = new HashSet<ApplicationUser>();
        }

        public string Name { get; set; }

        public ICollection<ApplicationUser> Users { get; set; }
    }
}
