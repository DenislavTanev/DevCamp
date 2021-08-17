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

    public class SubCategoriesService : ISubCategoriesService
    {
        private readonly IRepository<SubCategory> subCategoryRepository;

        public SubCategoriesService(IRepository<SubCategory> subCategoryRepository)
        {
            this.subCategoryRepository = subCategoryRepository;
        }

        public IEnumerable<T> GetAll<T>(int categoryId)
        {
            var subCategories = this.subCategoryRepository
                .All()
                .Where(x => x.CategoryId == categoryId)
                .To<T>()
                .ToList();

            return subCategories;
        }

        public async Task<T> GetById<T>(int id)
        {
            var subCategory = await this.subCategoryRepository
                .All()
                .Where(x => x.Id == id)
                .To<T>()
                .FirstOrDefaultAsync();

            return subCategory;
        }

        public int GetListingsCount(int subCategoryId)
        {
            var subCategory = this.subCategoryRepository
                .All()
                .Include(x => x.Listings)
                .FirstOrDefault(x => x.Id == subCategoryId);

            return subCategory.Listings.Count();
        }
    }
}
