namespace DevCamp.Data.Models
{
    using DevCamp.Data.Common.Models;

    public class PackageCheckItem : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        public bool IsIncluded { get; set; }

        public int PackageId { get; set; }

        public Package Package { get; set; }
    }
}
