namespace DevCamp.Web.ViewModels.Users
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using DevCamp.Data.Models;
    using DevCamp.Services.Mapping;
    using DevCamp.Web.ViewModels.DropDownModels;

    public class EditLocationInputModel : IMapTo<ApplicationUser>
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        public int CountryId { get; set; }

        public IEnumerable<CountriesDropDownViewModel> Countries { get; set; }
    }
}
