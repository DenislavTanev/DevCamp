namespace DevCamp.Web.ViewModels.PricePackages
{
    using DevCamp.Data.Models;
    using DevCamp.Services.Mapping;

    public class PackageItemViewModel : IMapFrom<PackageItem>
    {
        public int Id { get; set; }

        public int PackageId { get; set; }

        public int ItemId { get; set; }

        public string Content { get; set; }
    }
}
