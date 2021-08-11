namespace DevCamp.Web.ViewModels.DropDownModels
{
    using DevCamp.Data.Models;
    using DevCamp.Services.Mapping;

    public class SkillsDropDownViewModel : IMapFrom<Skill>
    {
        public int Id { get; set; }

        public string TechnologyName { get; set; }
    }
}
