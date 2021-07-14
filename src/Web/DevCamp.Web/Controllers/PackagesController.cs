namespace DevCamp.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DevCamp.Services.Data.Interfaces;
    using DevCamp.Web.ViewModels.Packages;
    using Microsoft.AspNetCore.Mvc;

    public class PackagesController : Controller
    {
        private readonly IPackagesService packagesService;
        private readonly IPackageItemsService packageItemsService;
        private readonly IItemsService itemService;

        public PackagesController(
            IPackagesService packagesService,
            IPackageItemsService packageItemsService,
            IItemsService itemService)
        {
            this.packagesService = packagesService;
            this.packageItemsService = packageItemsService;
            this.itemService = itemService;
        }

        public async Task<IActionResult> Index(int packageId)
        {
            var package = await this.packagesService.GetByIdAsync<PackageViewModel>(packageId);

            package.ItemContent = this.packageItemsService.GetAllByPackage<PackageItemViewModel>(packageId);

            var items = new List<ItemViewModel>();

            foreach (var item in package.ItemContent)
            {
                var currItem = await this.itemService.GetByIdAsync<ItemViewModel>(item.ItemId);

                items.Add(currItem);
            }

            package.Items = items;

            return this.View(package);
        }

        public async Task<IActionResult> ComparePackages(int listingId)
        {
            var packages = this.packagesService.GetAll<PackageViewModel>(listingId);

            foreach (var package in packages)
            {
                package.ItemContent = this.packageItemsService.GetAllByPackage<PackageItemViewModel>(package.Id);
            }

            foreach (var package in packages)
            {
                var items = new List<ItemViewModel>();

                foreach (var item in package.ItemContent)
                {
                    var currItem = await this.itemService.GetByIdAsync<ItemViewModel>(item.ItemId);

                    items.Add(currItem);
                }

                package.Items = items;
            }

            return this.View(packages);
        }

        public IActionResult Create()
        {
            var packageNames = new List<string> { "Basic", "Standard", "Premium" };

            return this.View(packageNames);
        }

        [HttpPost]
        public async Task<IActionResult> Create(IEnumerable<PackageCreateInputModel> inputModels)
        {
            foreach (var model in inputModels)
            {
                await this.packagesService.CreateAsync(
                    model.Name,
                    (double)model.Price,
                    model.Description,
                    (int)model.ListingId,
                    model.Revisions,
                    model.DeliveryTime);
            }

            return this.RedirectToAction("Edit");
        }

        public IActionResult Edit()
        {
            return this.View();
        }
    }
}
