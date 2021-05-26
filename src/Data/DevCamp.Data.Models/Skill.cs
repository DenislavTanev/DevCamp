namespace DevCamp.Data.Models
{
    using DevCamp.Data.Common.Models;

    public class Skill : BaseDeletableModel<int>
    {
        public string TechnologyName { get; set; }

        public string Icon { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }
    }
}
