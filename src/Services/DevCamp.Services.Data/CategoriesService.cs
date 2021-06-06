namespace DevCamp.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using DevCamp.Data.Common.Repositories;
    using DevCamp.Data.Models;
    using DevCamp.Services.Data.Interfaces;
    using DevCamp.Services.Mapping;

    public class CategoriesService : ICategoriesService
    {
        private readonly IRepository<Category> categoryRepository;

        public CategoriesService(IRepository<Category> categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public IEnumerable<T> GetAll<T>(int sectorId)
        {
            var categories = this.categoryRepository
                .All()
                .Where(x => x.SectorId == sectorId)
                .To<T>()
                .ToList();

            return categories;
        }

        public int GetListingsCount(int categoryId)
        {
            var category = this.categoryRepository
                .All()
                .FirstOrDefault(x => x.Id == categoryId);

            return category.Listings.Count();
        }
    }
}
