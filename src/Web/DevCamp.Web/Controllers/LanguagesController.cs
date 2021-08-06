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

        public LanguagesController(
            UserManager<ApplicationUser> userManager,
            IUsersService usersService,
            ILanguagesService languagesService)
        {
            this.userManager = userManager;
            this.usersService = usersService;
            this.languagesService = languagesService;
        }

        public IActionResult AddLanguage()
        {
            var languages = this.languagesService.GetAll<LanguagesDropDownViewModel>();

            var userId = this.userManager.GetUserId(this.User);

            return this.View(userId, languages);
        }

        [HttpPost]
        public async Task<IActionResult> AddLanguage(LanguageCreateInputModel input)
        {
            var userId = this.userManager.GetUserId(this.User);
            await this.usersService.AddLanguageAsync(userId, input.LanguageId, input.Level);

            return this.View(userId);
        }

        public IActionResult EditLanguage(int id)
        {
            return this.View(id);
        }

        [HttpPost]
        public async Task<IActionResult> EditLanguage(LanguageEditInputModel input)
        {
            var userId = this.userManager.GetUserId(this.User);
            await this.usersService.EditLanguageAsync(input.Id, input.Level);

            return this.RedirectToAction("Profile", "Users", new { userId = userId });
        }
    }
}
