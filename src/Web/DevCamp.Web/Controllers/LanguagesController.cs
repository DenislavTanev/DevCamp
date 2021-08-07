namespace DevCamp.Web.Controllers
{
    using System.Threading.Tasks;

    using DevCamp.Data.Models;
    using DevCamp.Services.Data.Interfaces;
    using DevCamp.Web.ViewModels.DropDownModels;
    using DevCamp.Web.ViewModels.Languages;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class LanguagesController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IUsersService usersService;
        private readonly ILanguagesService languagesService;
        private readonly ILevelsService levelsService;

        public LanguagesController(
            UserManager<ApplicationUser> userManager,
            IUsersService usersService,
            ILanguagesService languagesService,
            ILevelsService levelsService)
        {
            this.userManager = userManager;
            this.usersService = usersService;
            this.languagesService = languagesService;
            this.levelsService = levelsService;
        }

        public IActionResult AddLanguage()
        {
            var languages = this.languagesService.GetAll<LanguagesDropDownViewModel>();

            var userId = this.userManager.GetUserId(this.User);

            var levels = this.levelsService.GetAll<LevelDropDownViewModel>();

            var viewModel = new LanguageCreateInputModel
            {
                UserId = userId,
                Languages = languages,
                Levels = levels,
            };

            return this.PartialView(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddLanguage(LanguageCreateInputModel input)
        {
            await this.usersService.AddLanguageAsync(input.UserId, input.LanguageId, input.LevelId);

            return this.RedirectToAction("Profile", "Users", new { userId = input.UserId });
        }

        public IActionResult EditLanguage(int id)
        {
            return this.View(id);
        }

        [HttpPost]
        public async Task<IActionResult> EditLanguage(LanguageEditInputModel input)
        {
            var userId = this.userManager.GetUserId(this.User);
            await this.usersService.EditLanguageAsync(input.Id, input.LevelId);

            return this.RedirectToAction("Profile", "Users", new { userId = userId });
        }
    }
}
