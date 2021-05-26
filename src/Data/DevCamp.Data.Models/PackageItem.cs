namespace DevCamp.Data.Models
{
    using DevCamp.Data.Common.Models;

    public class PackageItem : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        public bool? IsIncluded { get; set; }

        public string? Content { get; set; }
    }
}
