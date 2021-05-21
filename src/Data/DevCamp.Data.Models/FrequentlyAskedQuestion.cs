namespace DevCamp.Data.Models
{
    using DevCamp.Data.Common.Models;

    public class FrequentlyAskedQuestion : BaseDeletableModel<string>
    {
        public string Question { get; set; }

        public string Answer { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }
    }
}
