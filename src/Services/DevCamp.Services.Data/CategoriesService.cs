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

        public async Task<T> GetById<T>(int id)
        {
            var category = await this.categoryRepository
                .All()
                .Where(x => x.Id == id)
                .To<T>()
                .FirstOrDefaultAsync();

            return category;
        }

        public int GetListingsCount(int categoryId)
        {
            var category = this.categoryRepository
                .All()
                .Include(x => x.Listings)
                .FirstOrDefault(x => x.Id == categoryId);

            return category.Listings.Count();
        }
    }
}
