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

    public class PackageItemsService : IPackageItemsService
    {
        private readonly IRepository<PackageItem> itemsRepository;

        public PackageItemsService(IRepository<PackageItem> itemsRepository)
        {
            this.itemsRepository = itemsRepository;
        }

        public async Task CreateAsync(int packageId, int itemId, string content, bool isIncluded)
        {
            var item = new PackageItem
            {
                PackageId = packageId,
                ItemId = itemId,
                Content = content,
                IsIncluded = isIncluded,
            };

            await this.itemsRepository.AddAsync(item);
            await this.itemsRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var item = await this.itemsRepository
                 .All()
                 .FirstOrDefaultAsync(x => x.Id == id);

            this.itemsRepository.Delete(item);
            await this.itemsRepository.SaveChangesAsync();
        }

        public async Task EditAsync(int id, int packageId, int itemId, string content, bool isIncluded)
        {
            var item = await this.itemsRepository
                .All()
                .FirstOrDefaultAsync(x => x.Id == id);

            item.PackageId = packageId;
            item.ItemId = itemId;
            item.Content = content;
            item.IsIncluded = isIncluded;

            await this.itemsRepository.SaveChangesAsync();
        }

        public IEnumerable<T> GetAllByPackage<T>(int packageId)
        {
            var items = this.itemsRepository
                .All()
                .Where(x => x.PackageId == packageId)
                .To<T>()
                .ToList();

            return items;
        }

        public async Task<T> GetByIdAsync<T>(int id)
        {
            var item = await this.itemsRepository
                .All()
                .Where(x => x.Id == id)
                .To<T>()
                .FirstOrDefaultAsync();

            return item;
        }
    }
}
