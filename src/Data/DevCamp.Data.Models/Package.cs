namespace DevCamp.Data.Models
{
    using DevCamp.Data.Common.Models;

    public class Package : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        public double Price { get; set; }

        public string PackageInfo { get; set; }

        public string Description { get; set; }

        public string DaysDelivery { get; set; }

        public string DayDeliveryOptions { get; set; }

        public string DayDeliveryOptionsPrice { get; set; }

        public string Revisions { get; set; }

        public int MyProperty { get; set; }
    }
}
