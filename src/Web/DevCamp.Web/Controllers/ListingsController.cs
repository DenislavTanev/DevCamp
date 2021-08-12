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
    using Microsoft.EntityFrameworkCore;

    public class ListingsController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IListingsService listingsService;
        private readonly ICategoriesService categoriesService;
        private readonly ISubCategoriesService subCategoriesService;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly ISectorsService sectorsService;
        private readonly IPackagesService packagesService;

        public ListingsController(
            UserManager<ApplicationUser> userManager,
            IListingsService listingsService,
            ICategoriesService categoriesService,
            ISubCategoriesService subCategoriesService,
            SignInManager<ApplicationUser> signInManager,
            ISectorsService sectorsService,
            IPackagesService packagesService)
        {
            this.userManager = userManager;
            this.listingsService = listingsService;
            this.categoriesService = categoriesService;
            this.subCategoriesService = subCategoriesService;
            this.signInManager = signInManager;
            this.sectorsService = sectorsService;
            this.packagesService = packagesService;
        }

        public async Task<IActionResult> EditTitle(int id)
        {
            var listing = await this.listingsService.GetByIdAsync<EditTitleViewModel>(id);

            var viewModel = new EditTitleInputModel
            {
                Id = listing.Id,
                Title = listing.Title,
            };

            return this.PartialView(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditTitle(EditTitleInputModel input)
        {
            await this.listingsService.EditTitleAsync(input.Id, input.Title);

            return this.RedirectToAction("PersonalListing", "Listings", new { Id = input.Id });
        }

        public async Task<IActionResult> EditDetails(int id)
        {
            var listing = await this.listingsService.GetByIdAsync<EditDescriptionViewModel>(id);

            var viewModel = new EditDescriptionInputModel
            {
                Id = listing.Id,
                ProjectDetails = listing.ProjectDetails,
            };

            return this.PartialView(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditDetails(EditDescriptionInputModel input)
        {
            await this.listingsService.EditDetailsAsync(input.Id, input.ProjectDetails);

            return this.RedirectToAction("PersonalListing", "Listings", new { Id = input.Id });
        }

        public IActionResult Create()
        {
            var sectors = this.sectorsService.GetAll<SectorsDropDownViewModel>();

            var viewModel = new ListingCreateInputModel
            {
                Sectors = sectors,
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ListingCreateInputModel input)
        {
            var user = await this.userManager.GetUserAsync(this.User);

            if (!this.ModelState.IsValid)
            {
                input.Sectors = this.sectorsService.GetAll<SectorsDropDownViewModel>();

                return this.View(input);
            }

            var listingId = await this.listingsService.CreateAsync(
                input.Title,
                input.ProjectDetails,
                user.Id,
                input.CategoryId,
                input.SubCategoryId);

            return this.RedirectToAction("Create", "PricePackages", new { listingId = listingId });
        }

        public async Task<IActionResult> Index()
        {
            var listing = await this.listingsService.GetByIdAsync<ListingDetailsViewModel>(6);
            var userId = this.userManager.GetUserId(this.User);
            listing.User = this.userManager.Users.Include(x => x.Country).First(x => x.Id == userId);

            return this.View(listing);
        }

        public IActionResult GetCategories(int sectorId)
        {
            var viewModel = new ListingCreateInputModel
            {
                Categories = this.categoriesService.GetAll<CategoriesDropDownViewModel>(sectorId),
            };

            return this.PartialView(viewModel);
        }

        public IActionResult GetSubCategories(int categoryId)
        {
            var viewModel = new ListingCreateInputModel
            {
                SubCategories = this.subCategoriesService.GetAll<SubCategoriesDropDownViewModel>(categoryId),
            };

            return this.PartialView(viewModel);
        }

        public async Task<IActionResult> PersonalListing(int id)
        {
            var listing = await this.listingsService.GetByIdAsync<ListingDetailsViewModel>(id);

            var packages = this.packagesService.GetAll<PackagesViewModel>(id);

            listing.BasicPackage = packages.FirstOrDefault(x => x.Name == "Basic");
            listing.StandardPackage = packages.FirstOrDefault(x => x.Name == "Standard");
            listing.PremiumPackage = packages.FirstOrDefault(x => x.Name == "Premium");

            var userId = this.userManager.GetUserId(this.User);

            listing.User = this.userManager.Users.Include(x => x.Country).First(x => x.Id == userId);

            return this.View(listing);
        }
    }
}
