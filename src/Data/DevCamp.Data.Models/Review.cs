namespace DevCamp.Data.Models
{
    using DevCamp.Data.Common.Models;

    public class Review : BaseDeletableModel<int>
    {
        public double Stars { get; set; }

        public string Message { get; set; }

        public int ListingId { get; set; }

        public Listing Listing { get; set; }

        public string CustomerId { get; set; }

        public ApplicationUser Customer { get; set; }
    }
}
