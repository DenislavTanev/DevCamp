namespace DevCamp.Data.Models
{
    using System.Collections.Generic;

    using DevCamp.Data.Common.Models;

    public class Item : BaseDeletableModel<int>
    {
        public Item()
        {
            this.Packages = new HashSet<PackageItem>();
        }

        public string Name { get; set; }

        public ICollection<PackageItem> Packages { get; set; }
    }
}
