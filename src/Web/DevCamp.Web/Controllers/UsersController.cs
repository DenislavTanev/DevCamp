namespace DevCamp.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;

    using DevCamp.Data.Models;
    using DevCamp.Services.Data.Interfaces;
    using DevCamp.Web.ViewModels.DropDownModels;
    using DevCamp.Web.ViewModels.Images;
    using DevCamp.Web.ViewModels.Listings;
    using DevCamp.Web.ViewModels.Users;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class UsersController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IUsersService usersService;
        private readonly ICountriesService countriesService;
        private readonly IImagesService imagesService;

        public UsersController(
            UserManager<ApplicationUser> userManager,
            IUsersService usersService,
            ICountriesService countriesService,
            IImagesService imagesService)
        {
            this.userManager = userManager;
            this.usersService = usersService;
            this.countriesService = countriesService;
            this.imagesService = imagesService;
        }

        public async Task<IActionResult> Index(string userId)
        {
            var user = await this.usersService.GetById<UserViewModel>(userId);

            var image = await this.usersService.GetProfilePic<ImageViewModel>(userId);

            user.ProfilePicture = "data:image/jpeg;base64," + Convert.ToBase64String(image.Img);

            foreach (var listing in user.Listings)
            {
                listing.Username = user.Name;
                listing.UserProfilePic = user.ProfilePicture;

                var images = this.imagesService.All<ImageViewModel>(listing.Id);

                listing.ListingImages = new List<string>();

                foreach (var imageBytes in images)
                {
                    listing.ListingImages.Add("data:image/jpeg;base64," + Convert.ToBase64String(imageBytes.Img));
                }
            }

            return this.View(user);
        }

        public async Task<IActionResult> Profile()
        {
            var userId = this.userManager.GetUserId(this.User);
            var user = await this.usersService.GetById<UserViewModel>(userId);

            var image = await this.usersService.GetProfilePic<ImageViewModel>(userId);

            user.ProfilePicture = "data:image/jpeg;base64," + Convert.ToBase64String(image.Img);

            foreach (var listing in user.Listings)
            {
                listing.Username = user.Name;
                listing.UserProfilePic = user.ProfilePicture;

                var images = this.imagesService.All<ImageViewModel>(listing.Id);

                listing.ListingImages = new List<string>();

                foreach (var imageBytes in images)
                {
                    listing.ListingImages.Add("data:image/jpeg;base64," + Convert.ToBase64String(imageBytes.Img));
                }
            }

            return this.View(user);
        }

        public async Task<IActionResult> EditDescription()
        {
            var userId = this.userManager.GetUserId(this.User);
            var user = await this.usersService.GetById<EditDescriptionViewModel>(userId);

            var viewModel = new EditDescriptionInputModel
            {
                Id = userId,
                Information = user.Information,
            };

            return this.PartialView(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditDescription(EditDescriptionInputModel input)
        {
            await this.usersService.EditDescriptionAsync(input.Id, input.Information);

            return this.RedirectToAction("Profile", "Users", new { userId = input.Id });
        }

        public IActionResult EditLocation()
        {
            var userId = this.userManager.GetUserId(this.User);
            var countries = this.countriesService.GetAll<CountriesDropDownViewModel>();

            var viewModel = new EditLocationInputModel
            {
                UserId = userId,
                Countries = countries,
            };

            return this.PartialView(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditLocation(EditLocationInputModel input)
        {
            await this.usersService.EditLocationAsync(input.UserId, input.CountryId);

            return this.RedirectToAction("Profile", "Users", new { userId = input.UserId });
        }

        public async Task<IActionResult> EditProfession()
        {
            var userId = this.userManager.GetUserId(this.User);
            var user = await this.usersService.GetById<EditProfessionViewModel>(userId);

            var viewModel = new EditProfessionInputModel
            {
                Id = userId,
                Profession = user.Profession,
            };

            return this.PartialView(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditProfession(EditProfessionInputModel input)
        {
            await this.usersService.EditProfessionAsync(input.Id, input.Profession);

            return this.RedirectToAction("Profile", "Users", new { userId = input.Id });
        }

        public async Task<IActionResult> EditName()
        {
            var userId = this.userManager.GetUserId(this.User);
            var user = await this.usersService.GetById<EditNameViewModel>(userId);

            var viewModel = new EditNameInputModel
            {
                Id = userId,
                Name = user.Name,
            };

            return this.PartialView(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditName(EditNameInputModel input)
        {
            await this.usersService.EditNameAsync(input.Id, input.Name);

            return this.RedirectToAction("Profile", "Users", new { userId = input.Id });
        }

        public IActionResult AddProfilePic()
        {
            var userId = this.userManager.GetUserId(this.User);

            var user = new ImageCreateInputModel
            {
                UserId = userId,
            };

            return this.PartialView(user);
        }

        [HttpPost]
        public async Task<IActionResult> AddProfilePic(ImageCreateInputModel input)
        {
            byte[] b;
            using BinaryReader br = new BinaryReader(input.Image.OpenReadStream());
            b = br.ReadBytes((int)input.Image.OpenReadStream().Length);

            await this.imagesService.CreateAsync(b, input.UserId);

            return this.RedirectToAction("Profile", "Users", new { userId = input.UserId });
        }

        public async Task<IActionResult> GetUser()
        {
            var userId = this.userManager.GetUserId(this.User);
            var user = await this.usersService.GetById<UserForListingViewModel>(userId);

            return this.PartialView(user);
        }
    }
}
