namespace DevCamp.Web.ViewModels.Listings
{
    using DevCamp.Data.Models;
    using DevCamp.Services.Mapping;

    public class EditTitleViewModel : IMapFrom<Listing>
    {
        public int Id { get; set; }

        public string Title { get; set; }
    }
}
