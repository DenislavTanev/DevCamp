namespace DevCamp.Data.Models
{
    using System.Collections.Generic;

    using DevCamp.Data.Common.Models;

    public class Listing : BaseDeletableModel<int>
    {
        public Listing()
        {
            this.Packages = new HashSet<Package>();
        }

        public string Title { get; set; }

        public string ProjectDetails { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public ICollection<Package> Packages { get; set; }
    }
}
