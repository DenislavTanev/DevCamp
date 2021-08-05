namespace DevCamp.Data.Models
{
    using System.Collections.Generic;

    using DevCamp.Data.Common.Models;

    public class Package : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public string Revisions { get; set; }

        public string DeliveryTime { get; set; }

        public int ListingId { get; set; }

        public Listing Listing { get; set; }
    }
}
