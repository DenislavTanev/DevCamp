namespace DevCamp.Web.ViewModels.Users
{
    using DevCamp.Data.Models;
    using DevCamp.Services.Mapping;

    public class EditNameViewModel : IMapFrom<ApplicationUser>
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
}
