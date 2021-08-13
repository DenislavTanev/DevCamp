namespace DevCamp.Web.Controllers
{
    using System.Threading.Tasks;

    using DevCamp.Data.Models;
    using DevCamp.Services.Data.Interfaces;
    using DevCamp.Web.ViewModels.DropDownModels;
    using DevCamp.Web.ViewModels.Skills;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class SkillsController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ISkillsService skillsService;

        public SkillsController(
            UserManager<ApplicationUser> userManager,
            ISkillsService skillsService)
        {
            this.userManager = userManager;
            this.skillsService = skillsService;
        }

        public IActionResult AddSkill()
        {
            var skills = this.skillsService.GetAll<SkillsDropDownViewModel>();

            var userId = this.userManager.GetUserId(this.User);

            var viewModel = new SkillsCreateInputModel
            {
                UserId = userId,
                Skills = skills,
            };

            return this.PartialView(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddSkill(SkillsCreateInputModel input)
        {
            await this.skillsService.CreateAsync(input.UserId, input.SkillId);

            return this.RedirectToAction("Profile", "Users", new { userId = input.UserId });
        }

        public async Task<IActionResult> DeleteSkill(int id)
        {
            var userId = this.userManager.GetUserId(this.User);

            await this.skillsService.DeleteAsync(id);

            return this.RedirectToAction("Profile", "Users", new { userId = userId });
        }
    }
}
