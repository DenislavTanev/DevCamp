namespace DevCamp.Web.ViewModels.Users
{
    using System.Collections.Generic;

    using DevCamp.Data.Models;
    using DevCamp.Services.Mapping;
    using DevCamp.Web.ViewModels.DropDownModels;

    public class EditLocationViewModel : IMapFrom<ApplicationUser>
    {
        public string UserId { get; set; }

        public int CountryId { get; set; }

        public IEnumerable<CountriesDropDownViewModel> Countries { get; set; }
    }
}
