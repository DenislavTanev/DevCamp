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
        private readonly ILanguagesService languagesService;
        private readonly ILevelsService levelsService;
        private readonly IUserLanguagesService userLanguagesService;

        public LanguagesController(
            UserManager<ApplicationUser> userManager,
            ILanguagesService languagesService,
            ILevelsService levelsService,
            IUserLanguagesService userLanguagesService)
        {
            this.userManager = userManager;
            this.languagesService = languagesService;
            this.levelsService = levelsService;
            this.userLanguagesService = userLanguagesService;
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
            await this.userLanguagesService.AddLanguageAsync(input.UserId, input.LanguageId, input.LevelId);

            return this.RedirectToAction("Profile", "Users", new { userId = input.UserId });
        }

        public async Task<IActionResult> EditLanguage(int id)
        {
            var language = await this.userLanguagesService.GetById<UserLanguageViewModel>(id);

            var levels = this.levelsService.GetAll<LevelDropDownViewModel>();

            var viewModel = new LanguageEditInputModel
            {
                Levels = levels,
                Id = id,
                LanguageName = language.Language.Name,
                LevelName = language.Level.Name,
                LevelId = language.LevelId,
            };

            return this.PartialView(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditLanguage(LanguageEditInputModel input)
        {
            var userId = this.userManager.GetUserId(this.User);
            await this.userLanguagesService.EditLanguageAsync(input.Id, input.LevelId);

            return this.RedirectToAction("Profile", "Users", new { userId = userId });
        }

        public async Task<IActionResult> DeleteLanguage(int id)
        {
            var userId = this.userManager.GetUserId(this.User);

            await this.userLanguagesService.DeleteAsync(id);

            return this.RedirectToAction("Profile", "Users", new { userId = userId });
        }
    }
}
