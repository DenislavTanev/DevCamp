namespace DevCamp.Data.Models
{
    using System;

    using DevCamp.Data.Common.Models;

    public class Payment : BaseModel<int>
    {
        public string Status { get; set; }

        public decimal Price { get; set; }

        public int PackagePeriod { get; set; }

        public string PaymentId { get; set; }

        public string CardHolder { get; set; }

        public string Ip { get; set; }

        public string LastFourCardDigit { get; set; }

        public DateTime CardExpires { get; set; }

        public int ListingId { get; set; }

        public Listing Listing { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }
    }
}
