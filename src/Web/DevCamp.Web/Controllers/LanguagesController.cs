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

            var viewModel = new LanguageCreateInputModel
            {
                UserId = userId,
                Languages = languages,
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddLanguage(LanguageCreateInputModel input)
        {
            await this.usersService.AddLanguageAsync(input.UserId, input.LanguageId, input.Level);

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
            await this.usersService.EditLanguageAsync(input.Id, input.Level);

            return this.RedirectToAction("Profile", "Users", new { userId = userId });
        }
    }
}
