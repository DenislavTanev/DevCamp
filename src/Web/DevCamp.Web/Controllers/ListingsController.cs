namespace DevCamp.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using DevCamp.Data.Models;
    using DevCamp.Services.Data.Interfaces;
    using DevCamp.Web.ViewModels.DropDownModels;
    using DevCamp.Web.ViewModels.Images;
    using DevCamp.Web.ViewModels.Listings;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class ListingsController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IListingsService listingsService;
        private readonly ICategoriesService categoriesService;
        private readonly ISubCategoriesService subCategoriesService;
        private readonly ISectorsService sectorsService;
        private readonly IPackagesService packagesService;
        private readonly IImagesService imagesService;
        private readonly IUsersService usersService;

        public ListingsController(
            UserManager<ApplicationUser> userManager,
            IListingsService listingsService,
            ICategoriesService categoriesService,
            ISubCategoriesService subCategoriesService,
            ISectorsService sectorsService,
            IPackagesService packagesService,
            IImagesService imagesService,
            IUsersService usersService)
        {
            this.userManager = userManager;
            this.listingsService = listingsService;
            this.categoriesService = categoriesService;
            this.subCategoriesService = subCategoriesService;
            this.sectorsService = sectorsService;
            this.packagesService = packagesService;
            this.imagesService = imagesService;
            this.usersService = usersService;
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
            var listing = await this.listingsService.GetByIdAsync<EditDetailsViewModel>(id);

            var viewModel = new EditDetailsInputModel
            {
                Id = listing.Id,
                ProjectDetails = listing.ProjectDetails,
            };

            return this.PartialView(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditDetails(EditDetailsInputModel input)
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

        public async Task<IActionResult> Index(int id)
        {
            var listing = await this.listingsService.GetByIdAsync<ListingDetailsViewModel>(id);

            var packages = this.packagesService.GetAll<PackagesViewModel>(id);

            listing.BasicPackage = packages.FirstOrDefault(x => x.Name == "Basic");
            listing.StandardPackage = packages.FirstOrDefault(x => x.Name == "Standard");
            listing.PremiumPackage = packages.FirstOrDefault(x => x.Name == "Premium");

            var userId = this.userManager.GetUserId(this.User);

            listing.User = await this.usersService.GetById<UserForListingViewModel>(userId);

            var image = await this.usersService.GetProfilePic<ImageViewModel>(userId);

            listing.User.ProfilePicture = "data:image/jpeg;base64," + Convert.ToBase64String(image.Img);

            var images = this.imagesService.All<ImageViewModel>(id);

            listing.ListingImages = new List<string>();

            foreach (var imageBytes in images)
            {
                listing.ListingImages.Add("data:image/jpeg;base64," + Convert.ToBase64String(imageBytes.Img));
            }

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

            listing.User = await this.usersService.GetById<UserForListingViewModel>(userId);

            var image = await this.usersService.GetProfilePic<ImageViewModel>(userId);

            var images = this.imagesService.All<ImageViewModel>(id);

            listing.ListingImages = new List<string>();

            foreach (var imageBytes in images)
            {
                listing.ListingImages.Add("data:image/jpeg;base64," + Convert.ToBase64String(imageBytes.Img));
            }

            listing.User.ProfilePicture = "data:image/jpeg;base64," + Convert.ToBase64String(image.Img);

            return this.View(listing);
        }

        public IActionResult AddImages(int id)
        {
            var viewModel = new ImagesListCreateInputModel
            {
                ListingId = id,
            };

            return this.PartialView(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddImages(ImagesListCreateInputModel input)
        {
            List<byte[]> images = new List<byte[]>();

            foreach (var image in input.Images)
            {
                byte[] b;
                using BinaryReader br = new BinaryReader(image.OpenReadStream());
                b = br.ReadBytes((int)image.OpenReadStream().Length);

                images.Add(b);
            }

            await this.imagesService.CreateListAsync(images, input.ListingId);

            return this.RedirectToAction("PersonalListing", "Listings", new { Id = input.ListingId });
        }
    }
}
