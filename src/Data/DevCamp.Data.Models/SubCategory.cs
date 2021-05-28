namespace DevCamp.Data.Models
{
    using System.Collections.Generic;

    using DevCamp.Data.Common.Models;

    public class SubCategory : BaseModel<int>
    {
        public SubCategory()
        {
            this.Listings = new HashSet<Listing>();
        }

        public string Name { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public ICollection<Listing> Listings { get; set; }
    }
}
