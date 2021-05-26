namespace DevCamp.Data.Models
{
    using System.Collections.Generic;

    using DevCamp.Data.Common.Models;

    public class Listing : BaseDeletableModel<int>
    {
        public Listing()
        {
            this.Images = new HashSet<string>();
        }

        public string Title { get; set; }

        // check
        public ICollection<string> Images { get; set; }

        public string ProjectDetails { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        // check
        public ICollection<Package> Packages { get; set; }
    }
}
