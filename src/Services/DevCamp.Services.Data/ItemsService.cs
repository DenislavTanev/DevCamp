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

    public class ItemsService : IItemsService
    {
        private readonly IDeletableEntityRepository<Item> itemsRepository;

        public ItemsService(IDeletableEntityRepository<Item> itemsRepository)
        {
            this.itemsRepository = itemsRepository;
        }

        public async Task CreateAsync(string name)
        {
            var item = new Item
            {
                Name = name,
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

        public async Task EditAsync(int id, string name)
        {
            var item = await this.itemsRepository
                .All()
                .FirstOrDefaultAsync(x => x.Id == id);

            item.Name = name;

            await this.itemsRepository.SaveChangesAsync();
        }

        public IEnumerable<T> GetAll<T>()
        {
            var items = this.itemsRepository
                .All()
                .OrderBy(x => x.Name)
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
