namespace DevCamp.Data.Models
{
    using DevCamp.Data.Common.Models;

    public class PackageTextItem : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        public string Content { get; set; }

        public int PackageId { get; set; }

        public Package Package { get; set; }
    }
}
