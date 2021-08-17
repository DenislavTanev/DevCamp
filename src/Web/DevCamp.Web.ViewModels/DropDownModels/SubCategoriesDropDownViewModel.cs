namespace DevCamp.Web.ViewModels.DropDownModels
{
    using DevCamp.Data.Models;
    using DevCamp.Services.Mapping;

    public class SubCategoriesDropDownViewModel : IMapFrom<SubCategory>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CategoryId { get; set; }
    }
}
