namespace DevCamp.Data.Models
{
    using System.Collections.Generic;

    using DevCamp.Data.Common.Models;

    public class Package : BaseDeletableModel<int>
    {
        public Package()
        {
            this.CheckItems = new HashSet<PackageCheckItem>();
            this.TextItems = new HashSet<PackageTextItem>();
        }

        public string Name { get; set; }

        public double Price { get; set; }

        public string PackageInfo { get; set; }

        public string Description { get; set; }

        public ICollection<PackageCheckItem> CheckItems { get; set; }

        public ICollection<PackageTextItem> TextItems { get; set; }

        public string DeliveryPeriod { get; set; }

        public bool IsBoosted { get; set; }

        public string BoostedDeliveryPeriod { get; set; }

        public double BoostedDeliveryPrice { get; set; }

        public double TotalPrice { get; set; }

        public int ListingId { get; set; }

        public Listing Listing { get; set; }
    }
}
