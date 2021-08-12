namespace DevCamp.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using DevCamp.Services.Data.Interfaces;
    using DevCamp.Web.ViewModels.Listings;
    using Microsoft.AspNetCore.Mvc;

    public class PricePackagesController : Controller
    {
        private readonly IPackagesService packagesService;

        public PricePackagesController(
            IPackagesService packagesService)
        {
            this.packagesService = packagesService;
        }

        public IActionResult Create(int listingId)
        {
            var packages = this.packagesService.GetAll<PackagesViewModel>(listingId);

            var listing = new ListingPackagesViewModel
            {
                ListingId = listingId,
                BasicPackage = packages.First(x => x.Name == "Basic"),
                StandardPackage = packages.First(x => x.Name == "Standard"),
                PremiumPackage = packages.First(x => x.Name == "Premium"),
            };

            return this.View(listing);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ListingPackagesViewModel input)
        {
            await this.packagesService.CreateAsync(input.BasicPackage, input.StandardPackage, input.PremiumPackage);

            return this.RedirectToAction("PersonalListing", "Listings", new { listingId = input.ListingId });
        }

        public IActionResult Edit(int listingId)
        {
            var packages = this.packagesService.GetAll<PackagesViewModel>(listingId);

            var viewModel = new ListingPackagesViewModel
            {
                ListingId = listingId,
                BasicPackage = packages.First(x => x.Name == "Basic"),
                StandardPackage = packages.First(x => x.Name == "Standard"),
                PremiumPackage = packages.First(x => x.Name == "Premium"),
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ListingPackagesViewModel input)
        {
            await this.packagesService.EditAsync(input.BasicPackage, input.StandardPackage, input.PremiumPackage);

            return this.RedirectToAction("PersonalListing", "Listings", new { Id = input.ListingId });
        }

        public async Task<IActionResult> ShowPackage(int id)
        {
            var package = await this.packagesService.GetByIdAsync<PackagesViewModel>(id);

            return this.PartialView(package);
        }
    }
}
