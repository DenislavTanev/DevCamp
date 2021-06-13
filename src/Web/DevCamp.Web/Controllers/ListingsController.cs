namespace DevCamp.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DevCamp.Data.Models;
    using DevCamp.Services.Data.Interfaces;
    using DevCamp.Web.ViewModels.DropDownModels;
    using DevCamp.Web.ViewModels.Listings;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class ListingsController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IListingsService listingsService;
        private readonly ICategoriesService categoriesService;
        private readonly ISubCategoriesService subCategoriesService;
        private readonly SignInManager<ApplicationUser> signInManager;

        public ListingsController(
            UserManager<ApplicationUser> userManager,
            IListingsService listingsService,
            ICategoriesService categoriesService,
            ISubCategoriesService subCategoriesService,
            SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.listingsService = listingsService;
            this.categoriesService = categoriesService;
            this.subCategoriesService = subCategoriesService;
            this.signInManager = signInManager;
        }

        public IActionResult Edit()
        {
            return this.View();
        }

        public IActionResult Create()
        {
            var categories = this.categoriesService.GetAll<CategoriesDropDownViewModel>(1);
            var subCategories = this.subCategoriesService.GetAll<SubCategoriesDropDownViewModel>(1);

            var viewModel = new ListingCreateInputModel
            {
                Categories = categories,
                SubCategories = subCategories,
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ListingCreateInputModel input)
        {
            var user = await this.userManager.GetUserAsync(this.User);

            if (!this.ModelState.IsValid)
            {
                input.Categories = this.categoriesService.GetAll<CategoriesDropDownViewModel>(1);

                return this.View(input);
            }

            await this.listingsService.CreateAsync(
                input.Title,
                input.ProjectDetails,
                user.Id,
                (int)input.CategoryId,
                (int)input.SubCategoryId);

            return this.RedirectToAction("Index");
        }
    }
}
