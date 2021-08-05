namespace DevCamp.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DevCamp.Data.Models;
    using DevCamp.Services.Data.Interfaces;
    using DevCamp.Web.ViewModels.Users;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class UsersController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IUsersService usersService;
        private readonly ILanguagesService languagesService;
        private readonly ICountriesService countriesService;

        public UsersController(
            UserManager<ApplicationUser> userManager,
            IUsersService usersService,
            ILanguagesService languagesService,
            ICountriesService countriesService)
        {
            this.userManager = userManager;
            this.usersService = usersService;
            this.languagesService = languagesService;
            this.countriesService = countriesService;
        }

        public async Task<IActionResult> Index()
        {
            var userId = this.userManager.GetUserId(this.User);
            var user = await this.usersService.GetById<UserViewModel>(userId);

            return this.View(user);
        }

        public async Task<IActionResult> Profile()
        {
            var userId = this.userManager.GetUserId(this.User);
            var user = await this.usersService.GetById<UserViewModel>(userId);

            return this.View(user);
        }

        public async Task<IActionResult> EditDescription()
        {
            var userId = this.userManager.GetUserId(this.User);
            var user = await this.usersService.GetById<EditDescriptionViewModel>(userId);

            return this.View(user);
        }

        [HttpPost]
        public async Task<IActionResult> EditDescription(EditDescriptionViewModel input)
        {
            await this.usersService.EditDescriptionAsync(input.Id, input.Information);

            return this.RedirectToAction("Profile", "Users", new { userId = input.Id });
        }
    }
}
