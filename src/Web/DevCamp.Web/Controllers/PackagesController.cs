namespace DevCamp.Web.Controllers
{
    using DevCamp.Services.Data.Interfaces;
    using DevCamp.Web.ViewModels.Packages;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

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

        public IActionResult ComparePackages()
        {
            return this.View();
        }

        public IActionResult Create()
        {
            return this.View();
        }

        public IActionResult Edit()
        {
            return this.View();
        }
    }
}
