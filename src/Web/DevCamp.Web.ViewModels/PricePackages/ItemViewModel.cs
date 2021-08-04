namespace DevCamp.Web.ViewModels.PricePackages
{
    using DevCamp.Data.Models;
    using DevCamp.Services.Mapping;

    public class ItemViewModel : IMapFrom<PackageItem>
    {
        public int ItemId { get; set; }

        public string Name { get; set; }
    }
}
