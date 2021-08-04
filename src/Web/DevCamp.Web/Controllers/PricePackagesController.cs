namespace DevCamp.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DevCamp.Services.Data.Interfaces;
    using DevCamp.Web.ViewModels.Listings;
    using DevCamp.Web.ViewModels.PricePackages;
    using Microsoft.AspNetCore.Mvc;

    public class PricePackagesController : Controller
    {
        private readonly IPackagesService packagesService;
        private readonly IPackageItemsService packageItemsService;
        private readonly IItemsService itemService;
        private readonly IListingsService listingsService;

        public PricePackagesController(
            IPackagesService packagesService,
            IPackageItemsService packageItemsService,
            IItemsService itemService,
            IListingsService listingsService)
        {
            this.packagesService = packagesService;
            this.packageItemsService = packageItemsService;
            this.itemService = itemService;
            this.listingsService = listingsService;
        }

        //public async Task<IActionResult> Index(int packageId)
        //{
        //    var package = await this.packagesService.GetByIdAsync<PackageViewModel>(packageId);

        //    package.ItemContent = this.packageItemsService.GetAllByPackage<PackageItemViewModel>(packageId);

        //    var items = new List<ItemViewModel>();

        //    foreach (var item in package.ItemContent)
        //    {
        //        var currItem = await this.itemService.GetByIdAsync<ItemViewModel>(item.ItemId);

        //        items.Add(currItem);
        //    }

        //    package.Items = items;

        //    return this.View(package);
        //}

        //public async Task<IActionResult> ComparePackages(int listingId)
        //{
        //    var packages = this.packagesService.GetAll<PackageViewModel>(listingId);

        //    foreach (var package in packages)
        //    {
        //        package.ItemContent = this.packageItemsService.GetAllByPackage<PackageItemViewModel>(package.Id);
        //    }

        //    foreach (var package in packages)
        //    {
        //        var items = new List<ItemViewModel>();

        //        foreach (var item in package.ItemContent)
        //        {
        //            var currItem = await this.itemService.GetByIdAsync<ItemViewModel>(item.ItemId);

        //            items.Add(currItem);
        //        }

        //        package.Items = items;
        //    }

        //    return this.View(packages);
        //}

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

            return this.RedirectToAction("Edit");
        }

        public IActionResult Edit()
        {
            return this.View();
        }
    }
}
