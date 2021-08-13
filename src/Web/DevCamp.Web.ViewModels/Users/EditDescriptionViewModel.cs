namespace DevCamp.Web.ViewModels.Users
{
    using DevCamp.Data.Models;
    using DevCamp.Services.Mapping;

    public class EditDescriptionViewModel : IMapFrom<ApplicationUser>
    {
        public string Id { get; set; }

        public string Information { get; set; }
    }
}
