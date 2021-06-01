namespace DevCamp.Data.Models
{
    using System.Collections.Generic;

    using DevCamp.Data.Common.Models;

    public class Achievement : BaseDeletableModel<int>
    {
        public Achievement()
        {
            this.Users = new HashSet<ApplicationUser>();
        }

        public string Name { get; set; }

        public string Icon { get; set; }

        public string Requiremnets { get; set; }

        public bool IsOwned { get; set; }

        public ICollection<ApplicationUser> Users { get; set; }
    }
}
