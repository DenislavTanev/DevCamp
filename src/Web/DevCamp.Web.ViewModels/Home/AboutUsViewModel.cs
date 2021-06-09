namespace DevCamp.Web.ViewModels.Home
{
    using DevCamp.Data.Models;
    using DevCamp.Services.Mapping;

    public class AboutUsViewModel : IMapFrom<AboutUs>
    {
        public string Email { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public string LocationUrlForGoogleMaps { get; set; }

        public string LocationUrlForOpenStreetMap { get; set; }
    }
}
