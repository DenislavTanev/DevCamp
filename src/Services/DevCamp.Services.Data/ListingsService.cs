namespace DevCamp.Services.Data
{
    using System;
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
        private readonly IDeletableEntityRepository<Language> languagesRepository;

        public ListingsService(
            IDeletableEntityRepository<Listing> listingsRepository,
            IDeletableEntityRepository<Language> languagesRepository)
        {
            this.listingsRepository = listingsRepository;
            this.languagesRepository = languagesRepository;
        }

        public async Task CreateAsync(string title, string projectDetails, string userId, int categoryId, int subCategoryId)
        {
            var listing = new Listing
            {
                Title = title,
                ProjectDetails = projectDetails,
                UserId = userId,
                CategoryId = categoryId,
                SubCategoryId = subCategoryId,
            };

            await this.listingsRepository.AddAsync(listing);
            await this.listingsRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var listing = await this.listingsRepository
                .All()
                .FirstOrDefaultAsync(x => x.Id == id);

            this.listingsRepository.Delete(listing);
            await this.listingsRepository.SaveChangesAsync();
        }

        public async Task EditAsync(int id, string title, string projectDetails, string userId, int categoryId, int subCategoryId)
        {
            var listing = await this.listingsRepository
                .All()
                .FirstOrDefaultAsync(x => x.Id == id);

            listing.Title = title;
            listing.ProjectDetails = projectDetails;
            listing.UserId = userId;
            listing.CategoryId = categoryId;
            listing.SubCategoryId = subCategoryId;

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
            var language = this.languagesRepository
                .All()
                .FirstOrDefault(x => x.Id == languageId);

            var listings = this.listingsRepository
                .All()
                .Where(x => x.User.SpokenLanguages.Contains(language))
                .To<T>()
                .ToList();

            return listings;
        }

        public async Task<T> GetByIdAsync<T>(int id)
        {
            var listing = await this.listingsRepository
                .All()
                .Where(x => x.Id == id)
                .To<T>()
                .FirstOrDefaultAsync();

            return listing;
        }
    }
}
