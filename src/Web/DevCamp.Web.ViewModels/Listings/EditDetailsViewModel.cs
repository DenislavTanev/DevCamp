namespace DevCamp.Web.ViewModels.Listings
{
    using DevCamp.Data.Models;
    using DevCamp.Services.Mapping;

    public class EditDetailsViewModel : IMapFrom<Listing>
    {
        public int Id { get; set; }

        public string ProjectDetails { get; set; }
    }
}
