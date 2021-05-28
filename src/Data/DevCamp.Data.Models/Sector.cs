namespace DevCamp.Data.Models
{
    using System.Collections.Generic;

    using DevCamp.Data.Common.Models;

    public class Sector : BaseModel<int>
    {
        public Sector()
        {
            this.Categories = new HashSet<Category>();
        }

        public string Name { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
    }
}
