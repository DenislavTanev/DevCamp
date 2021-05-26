namespace DevCamp.Data.Models
{
    using DevCamp.Data.Common.Models;

    public class Achievement : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        public string Icon { get; set; }

        public string Requiremnets { get; set; }

        public bool IsOwned { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }
    }
}
