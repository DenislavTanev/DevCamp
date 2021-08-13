namespace DevCamp.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DevCamp.Data.Common.Repositories;
    using DevCamp.Data.Models;
    using DevCamp.Services.Data.Interfaces;
    using DevCamp.Services.Mapping;
    using DevCamp.Web.ViewModels.Listings;
    using Microsoft.EntityFrameworkCore;

    public class PackagesService : IPackagesService
    {
        private readonly IDeletableEntityRepository<Package> packagesRepository;
        private readonly IDeletableEntityRepository<Listing> listingsRepository;

        public PackagesService(
            IDeletableEntityRepository<Package> packagesRepository,
            IDeletableEntityRepository<Listing> listingsRepository)
        {
            this.packagesRepository = packagesRepository;
            this.listingsRepository = listingsRepository;
        }

        public async Task CreateAsync(PackagesViewModel basicPackage, PackagesViewModel standartPackage, PackagesViewModel premiumPackage)
        {
            var basic = await this.packagesRepository.All().FirstOrDefaultAsync(x => x.Id == basicPackage.Id);

            basic.Price = basicPackage.Price;
            basic.Description = basicPackage.Description;
            basic.Revisions = basicPackage.Revisions;
            basic.DeliveryTime = basicPackage.DeliveryTime;

            var standart = await this.packagesRepository.All().FirstOrDefaultAsync(x => x.Id == standartPackage.Id);

            standart.Price = standartPackage.Price;
            standart.Description = standartPackage.Description;
            standart.Revisions = standartPackage.Revisions;
            standart.DeliveryTime = standartPackage.DeliveryTime;

            var premium = await this.packagesRepository.All().FirstOrDefaultAsync(x => x.Id == premiumPackage.Id);

            premium.Price = premiumPackage.Price;
            premium.Description = premiumPackage.Description;
            premium.Revisions = premiumPackage.Revisions;
            premium.DeliveryTime = premiumPackage.DeliveryTime;

            var listing = await this.listingsRepository.All().FirstOrDefaultAsync(x => x.Id == basic.ListingId);

            listing.StartingPrice = basic.Price;

            await this.packagesRepository.SaveChangesAsync();
            await this.listingsRepository.SaveChangesAsync();
        }

        public async Task EditAsync(PackagesViewModel basicPackage, PackagesViewModel standartPackage, PackagesViewModel premiumPackage)
        {
            var basic = await this.packagesRepository.All().FirstOrDefaultAsync(x => x.Id == basicPackage.Id);

            basic.Price = basicPackage.Price;
            basic.Description = basicPackage.Description;
            basic.Revisions = basicPackage.Revisions;
            basic.DeliveryTime = basicPackage.DeliveryTime;

            var standart = await this.packagesRepository.All().FirstOrDefaultAsync(x => x.Id == standartPackage.Id);

            standart.Price = standartPackage.Price;
            standart.Description = standartPackage.Description;
            standart.Revisions = standartPackage.Revisions;
            standart.DeliveryTime = standartPackage.DeliveryTime;

            var premium = await this.packagesRepository.All().FirstOrDefaultAsync(x => x.Id == premiumPackage.Id);

            premium.Price = premiumPackage.Price;
            premium.Description = premiumPackage.Description;
            premium.Revisions = premiumPackage.Revisions;
            premium.DeliveryTime = premiumPackage.DeliveryTime;

            var listing = await this.listingsRepository.All().FirstOrDefaultAsync(x => x.Id == basic.ListingId);

            listing.StartingPrice = basic.Price;

            await this.packagesRepository.SaveChangesAsync();
            await this.listingsRepository.SaveChangesAsync();
        }

        public IEnumerable<T> GetAll<T>(int listingId)
        {
            var packages = this.packagesRepository
                .All()
                .Where(x => x.ListingId == listingId)
                .To<T>()
                .ToList();

            return packages;
        }

        public async Task<T> GetByIdAsync<T>(int id)
        {
            var package = await this.packagesRepository
                .All()
                .Where(x => x.Id == id)
                .To<T>()
                .FirstOrDefaultAsync();

            return package;
        }
    }
}
