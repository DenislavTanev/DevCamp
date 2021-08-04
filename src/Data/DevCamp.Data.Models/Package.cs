namespace DevCamp.Data.Models
{
    using System.Collections.Generic;

    using DevCamp.Data.Common.Models;

    public class Package : BaseDeletableModel<int>
    {
        public Package()
        {
            this.Items = new HashSet<PackageItem>();
        }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public string Revisions { get; set; }

        public string DeliveryTime { get; set; }

        public ICollection<PackageItem> Items { get; set; }

        public int ListingId { get; set; }

        public Listing Listing { get; set; }
    }
}
