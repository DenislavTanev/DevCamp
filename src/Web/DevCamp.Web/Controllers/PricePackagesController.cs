namespace DevCamp.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DevCamp.Services.Data.Interfaces;
    using DevCamp.Web.ViewModels.Listings;
    using Microsoft.AspNetCore.Mvc;

    public class PricePackagesController : Controller
    {
        private readonly IPackagesService packagesService;
        private readonly IListingsService listingsService;

        public PricePackagesController(
            IPackagesService packagesService,
            IListingsService listingsService)
        {
            this.packagesService = packagesService;
            this.listingsService = listingsService;
        }

        public async Task<IActionResult> Index(int packageId)
        {
            var package = await this.packagesService.GetByIdAsync<PackagesViewModel>(packageId);

            return this.View(package);
        }

        public IActionResult ComparePackages(int listingId)
        {
            var packages = this.packagesService.GetAll<PackagesViewModel>(listingId);

            return this.View(packages);
        }

        public IActionResult Create(int listingId)
        {
            var packages = this.packagesService.GetAll<PackagesViewModel>(listingId);

            var listing = new ListingPackagesViewModel
            {
                ListingId = listingId,
                BasicPackage = packages.First(x => x.Name == "Basic"),
                StandartPackage = packages.First(x => x.Name == "Standard"),
                PremiumPackage = packages.First(x => x.Name == "Premium"),
            };

            return this.View(listing);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ListingPackagesViewModel input)
        {
            await this.packagesService.CreateAsync(input.BasicPackage, input.StandartPackage, input.PremiumPackage);

            return this.RedirectToAction("Index", "Listings", new { listingId = input.ListingId });
        }
    }
}
