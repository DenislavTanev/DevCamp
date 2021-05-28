namespace DevCamp.Data.Models
{
    using System.Collections.Generic;

    using DevCamp.Data.Common.Models;

    public class Category : BaseModel<int>
    {
        public Category()
        {
            this.Listings = new HashSet<Listing>();
            this.SubCategories = new HashSet<SubCategory>();
        }

        public string Name { get; set; }

        public int SectorId { get; set; }

        public Sector Sector { get; set; }

        public ICollection<Listing> Listings { get; set; }

        public ICollection<SubCategory> SubCategories { get; set; }
    }
}
