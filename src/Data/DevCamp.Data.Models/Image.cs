namespace DevCamp.Data.Models
{
    using DevCamp.Data.Common.Models;

    public class Image : BaseDeletableModel<string>
    {
        public byte[] Img { get; set; }

        public int? ListingId { get; set; }

        public Listing Listing { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }
    }
}
