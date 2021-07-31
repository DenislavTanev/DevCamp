namespace DevCamp.Data.Models
{
    using DevCamp.Data.Common.Models;

    public class Certification : BaseDeletableModel<int>
    {
        public string Certificate { get; set; }

        public string CertifiedFrom { get; set; }

        public int Year { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }
    }
}
