namespace DevCamp.Data.Models
{
    using System.Collections.Generic;

    using DevCamp.Data.Common.Models;

    public class Level : BaseModel<int>
    {
        public Level()
        {
            this.Users = new HashSet<UserLanguage>();
        }

        public string Name { get; set; }

        public ICollection<UserLanguage> Users { get; set; }
    }
}
