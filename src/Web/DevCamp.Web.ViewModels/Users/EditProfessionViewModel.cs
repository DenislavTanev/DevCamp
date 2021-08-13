namespace DevCamp.Web.ViewModels.Users
{
    using DevCamp.Data.Models;
    using DevCamp.Services.Mapping;

    public class EditProfessionViewModel : IMapFrom<ApplicationUser>
    {
        public string Id { get; set; }

        public string Profession { get; set; }
    }
}
