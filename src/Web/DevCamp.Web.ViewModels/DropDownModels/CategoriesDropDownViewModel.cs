namespace DevCamp.Web.ViewModels.DropDownModels
{
    using DevCamp.Data.Models;
    using DevCamp.Services.Mapping;

    public class CategoriesDropDownViewModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public int SectorId { get; set; }

        public string Name { get; set; }
    }
}
