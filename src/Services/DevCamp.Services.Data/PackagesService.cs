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

        public async Task CreateAsync(List<PackagesViewModel> packages)
        {
            foreach (var item in packages)
            {
                var package = await this.packagesRepository.All().FirstOrDefaultAsync(x => x.Id == item.Id);

                package.Price = item.Price;
                package.Description = item.Description;
                package.Revisions = item.Revisions;
                package.DeliveryTime = item.DeliveryTime;
            }

            await this.packagesRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var package = await this.packagesRepository
                .All()
                .FirstOrDefaultAsync(x => x.Id == id);

            this.packagesRepository.Delete(package);
            await this.packagesRepository.SaveChangesAsync();
        }

        public async Task EditAsync(int id, string name, double price, string description, int listingId, string revisions, string deliveryTime)
        {
            var package = await this.packagesRepository
                .All()
                .FirstOrDefaultAsync(x => x.Id == id);

            package.Name = name;
            package.Price = price;
            package.Description = description;
            package.ListingId = listingId;
            package.Revisions = revisions;
            package.DeliveryTime = deliveryTime;

            if (name == "Basic")
            {
                var listing = this.listingsRepository
                    .All()
                    .FirstOrDefault(x => x.Id == listingId);

                listing.StartingPrice = price;

                await this.listingsRepository.SaveChangesAsync();
            }

            await this.packagesRepository.SaveChangesAsync();
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
