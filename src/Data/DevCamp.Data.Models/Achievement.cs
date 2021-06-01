namespace DevCamp.Data.Models
{
    using System.Collections.Generic;

    using DevCamp.Data.Common.Models;

    public class Achievement : BaseDeletableModel<int>
    {
        public Achievement()
        {
            this.Users = new HashSet<UserAchievement>();
        }

        public string Name { get; set; }

        public string Icon { get; set; }

        public string Requirements { get; set; }

        public ICollection<UserAchievement> Users { get; set; }
    }
}
