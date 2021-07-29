namespace DevCamp.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DevCamp.Data.Common.Repositories;
    using DevCamp.Data.Models;
    using DevCamp.Services.Data.Interfaces;
    using DevCamp.Services.Mapping;
    using Microsoft.EntityFrameworkCore;

    public class ListingsService : IListingsService
    {
        private readonly IDeletableEntityRepository<Listing> listingsRepository;
        private readonly IDeletableEntityRepository<UserLanguage> languagesRepository;
        private readonly IDeletableEntityRepository<Package> packagesRepository;

        public ListingsService(
            IDeletableEntityRepository<Listing> listingsRepository,
            IDeletableEntityRepository<UserLanguage> languagesRepository,
            IDeletableEntityRepository<Package> packagesRepository)
        {
            this.listingsRepository = listingsRepository;
            this.languagesRepository = languagesRepository;
            this.packagesRepository = packagesRepository;
        }

        public async Task<int> CreateAsync(string title, string projectDetails, string userId, int categoryId, int subCategoryId)
        {
            var listing = new Listing
            {
                Title = title,
                ProjectDetails = projectDetails,
                UserId = userId,
                CategoryId = categoryId,
                SubCategoryId = subCategoryId,
                IsComplete = false,
            };

            await this.listingsRepository.AddAsync(listing);

            var basicPackage = new Package
            {
                Name = "Basic",
            };

            var standardPackage = new Package
            {
                Name = "Standard",
            };

            var premiumPackage = new Package
            {
                Name = "Premium",
            };

            listing.Packages.Add(basicPackage);
            listing.Packages.Add(standardPackage);
            listing.Packages.Add(premiumPackage);

            await this.listingsRepository.SaveChangesAsync();

            return listing.Id;
        }

        public async Task DeleteAsync(int id)
        {
            var listing = await this.listingsRepository
                .All()
                .FirstOrDefaultAsync(x => x.Id == id);

            this.listingsRepository.Delete(listing);
            await this.listingsRepository.SaveChangesAsync();
        }

        public async Task EditTitleAsync(int id, string title)
        {
            var listing = await this.listingsRepository
                .All()
                .FirstOrDefaultAsync(x => x.Id == id);

            listing.Title = title;

            await this.listingsRepository.SaveChangesAsync();
        }

        public async Task EditDetailsAsync(int id, string details)
        {
            var listing = await this.listingsRepository
                .All()
                .FirstOrDefaultAsync(x => x.Id == id);

            listing.ProjectDetails = details;

            await this.listingsRepository.SaveChangesAsync();
        }

        public IEnumerable<T> GetAllByCategory<T>(int categoryId)
        {
            var listings = this.listingsRepository
                .All()
                .Where(x => x.CategoryId == categoryId)
                .To<T>()
                .ToList();

            return listings;
        }

        public IEnumerable<T> GetAllByPrice<T>(int price)
        {
            var listings = this.listingsRepository
                .All()
                .Where(x => x.StartingPrice <= price)
                .To<T>()
                .ToList();

            return listings;
        }

        public IEnumerable<T> GetAllBySubCategory<T>(int subCategoryId)
        {
            var listings = this.listingsRepository
                .All()
                .Where(x => x.SubCategoryId == subCategoryId)
                .To<T>()
                .ToList();

            return listings;
        }

        public IEnumerable<T> GetAllByUser<T>(string userId)
        {
            var listings = this.listingsRepository
                .All()
                .Where(x => x.UserId == userId)
                .To<T>()
                .ToList();

            return listings;
        }

        public IEnumerable<T> GetAllByUserLocation<T>(int locationId)
        {
            var listings = this.listingsRepository
                .All()
                .Where(x => x.User.CountryId == locationId)
                .To<T>()
                .ToList();

            return listings;
        }

        public IEnumerable<T> GetAllByUserSpokenLanguage<T>(int languageId)
        {
            var listings = this.listingsRepository
                .All()
                .Where(x => x.User.SpokenLanguages.Any(x => x.LanguageId == languageId))
                .To<T>()
                .ToList();

            return listings;
        }

        public async Task<T> GetByIdAsync<T>(int id)
        {
            var listing = await this.listingsRepository
                .All()
                .Include(x => x.Packages)
                .Where(x => x.Id == id)
                .To<T>()
                .FirstOrDefaultAsync();

            return listing;
        }

        public async Task SetToComplete(int id)
        {
            var listing = await this.listingsRepository
                .All()
                .FirstOrDefaultAsync(x => x.Id == id);

            listing.IsComplete = true;

            await this.listingsRepository.SaveChangesAsync();
        }
    }
}
