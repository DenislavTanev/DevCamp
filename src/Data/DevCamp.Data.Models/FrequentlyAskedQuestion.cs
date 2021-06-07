namespace DevCamp.Data.Models
{
    using DevCamp.Data.Common.Models;

    public class FrequentlyAskedQuestion : BaseDeletableModel<int>
    {
        public string Question { get; set; }

        public string Answer { get; set; }

        public int ListingId { get; set; }

        public Listing Listing { get; set; }
    }
}
