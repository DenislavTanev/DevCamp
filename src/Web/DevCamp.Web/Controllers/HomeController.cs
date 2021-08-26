namespace DevCamp.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;

    using DevCamp.Services.Data.Interfaces;
    using DevCamp.Web.ViewModels;
    using DevCamp.Web.ViewModels.DropDownModels;
    using DevCamp.Web.ViewModels.Home;
    using DevCamp.Web.ViewModels.Images;
    using DevCamp.Web.ViewModels.Listings;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : Controller
    {
        private readonly ICategoriesService categoriesService;
        private readonly ISectorsService sectorsService;
        private readonly ISubCategoriesService subCategoriesService;
        private readonly IListingsService listingsService;
        private readonly IUsersService usersService;
        private readonly IImagesService imagesService;

        public HomeController(
            ICategoriesService categoriesService,
            ISectorsService sectorsService,
            ISubCategoriesService subCategoriesService,
            IListingsService listingsService,
            IUsersService usersService,
            IImagesService imagesService)
        {
            this.categoriesService = categoriesService;
            this.sectorsService = sectorsService;
            this.subCategoriesService = subCategoriesService;
            this.listingsService = listingsService;
            this.usersService = usersService;
            this.imagesService = imagesService;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult Test()
        {
            return this.View();
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }

        public IActionResult ShowSector(int sectorId)
        {
            var categories = this.categoriesService.GetAll<CategoriesDropDownViewModel>(sectorId);

            var viewModel = new CategoriesInListViewModel { Categories = new List<CategoriesViewModel>() };

            foreach (var category in categories)
            {
                var subCategories = this.subCategoriesService.GetAll<SubCategoriesDropDownViewModel>(category.Id);

                viewModel.Categories.Add(new CategoriesViewModel
                {
                    CategoryId = category.Id,
                    CategoryName = category.Name,
                    SubCategories = subCategories,
                });
            }

            return this.View(viewModel);
        }

        public async Task<IActionResult> ShowCategoriesListings(int id)
        {
            var listings = this.listingsService.GetAllByCategory<ViewModels.Home.ListingViewModel>(id);

            var category = await this.categoriesService.GetById<CategoriesDropDownViewModel>(id);
            var sector = await this.sectorsService.GetById<SectorsDropDownViewModel>(category.SectorId);
            var categories = this.categoriesService.GetAll<CategoriesDropDownViewModel>(sector.Id);
            var subCategories = this.subCategoriesService.GetAll<SubCategoriesDropDownViewModel>(id);

            foreach (var listing in listings)
            {
                var images = this.imagesService.All<ImageViewModel>(listing.Id);

                listing.ListingImages = new List<string>();

                foreach (var imageBytes in images)
                {
                    listing.ListingImages.Add("data:image/jpeg;base64," + Convert.ToBase64String(imageBytes.Img));
                }

                listing.User = await this.usersService.GetById<UserForListingViewModel>(listing.UserId);

                var image = await this.usersService.GetProfilePic<ImageViewModel>(listing.UserId);

                if (image.Img != null)
                {
                    listing.User.ProfilePicture = "data:image/jpeg;base64," + Convert.ToBase64String(image.Img);
                }
                else
                {
                    listing.User.ProfilePicture = null;
                }
            }

            var viewModel = new CategoryListingsViewModel
            {
                Category = category,
                Sector = sector,
                SubCategories = subCategories.ToList(),
                ListingsCount = this.categoriesService.GetListingsCount(id),
                Categories = categories.ToList(),
                Listings = listings.ToList(),
            };

            return this.View(viewModel);
        }

        public async Task<IActionResult> ShowSubCategoryListings(int id)
        {
            var listings = this.listingsService.GetAllBySubCategory<ViewModels.Home.ListingViewModel>(id);

            var subCategory = await this.subCategoriesService.GetById<SubCategoriesDropDownViewModel>(id);
            var category = await this.categoriesService.GetById<CategoriesDropDownViewModel>(subCategory.CategoryId);
            var sector = await this.sectorsService.GetById<SectorsDropDownViewModel>(category.SectorId);
            var categories = this.categoriesService.GetAll<CategoriesDropDownViewModel>(sector.Id);

            foreach (var listing in listings)
            {
                var images = this.imagesService.All<ImageViewModel>(listing.Id);

                listing.ListingImages = new List<string>();

                foreach (var imageBytes in images)
                {
                    listing.ListingImages.Add("data:image/jpeg;base64," + Convert.ToBase64String(imageBytes.Img));
                }

                listing.User = await this.usersService.GetById<UserForListingViewModel>(listing.UserId);

                var image = await this.usersService.GetProfilePic<ImageViewModel>(listing.UserId);

                if (image.Img != null)
                {
                    listing.User.ProfilePicture = "data:image/jpeg;base64," + Convert.ToBase64String(image.Img);
                }
                else
                {
                    listing.User.ProfilePicture = null;
                }
            }

            var viewModel = new CategoryListingsViewModel
            {
                Category = category,
                Sector = sector,
                SubCategory = subCategory,
                ListingsCount = this.subCategoriesService.GetListingsCount(id),
                Categories = categories.ToList(),
                Listings = listings.ToList(),
            };

            return this.View(viewModel);
        }
    }
}
