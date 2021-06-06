namespace DevCamp.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using DevCamp.Data.Common.Repositories;
    using DevCamp.Data.Models;
    using DevCamp.Services.Data.Interfaces;
    using DevCamp.Services.Mapping;

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

        public int GetListingsCount(int subCategoryId)
        {
            var subCategory = this.subCategoryRepository
                .All()
                .FirstOrDefault(x => x.Id == subCategoryId);

            return subCategory.Listings.Count();
        }
    }
}
