namespace DevCamp.Web.ViewModels.Listings
{
    using DevCamp.Data.Models;
    using DevCamp.Services.Mapping;

    public class EditDescriptionViewModel : IMapFrom<Listing>
    {
        public int Id { get; set; }

        public string ProjectDetails { get; set; }
    }
}
