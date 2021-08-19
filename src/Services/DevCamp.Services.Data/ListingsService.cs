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

        public ListingsService(
            IDeletableEntityRepository<Listing> listingsRepository)
        {
            this.listingsRepository = listingsRepository;
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

        public IEnumerable<T> GetAllBySubCategory<T>(int subCategoryId)
        {
            var listings = this.listingsRepository
                .All()
                .Where(x => x.SubCategoryId == subCategoryId)
                .To<T>()
                .ToList();

            return listings;
        }

        public async Task<T> GetByIdAsync<T>(int id)
        {
            var listing = await this.listingsRepository
                .All()
                .Include(x => x.Category)
                .Include(x => x.SubCategory)
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
