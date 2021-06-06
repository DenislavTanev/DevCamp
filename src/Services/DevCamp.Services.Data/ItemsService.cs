namespace DevCamp.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DevCamp.Services.Data.Interfaces;

    public class ItemsService : IItemsService
    {
        public Task CreateAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task EditAsync(int id, string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll<T>()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAllByPackage<T>(int packageId)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetByIdAsync<T>(int id)
        {
            throw new NotImplementedException();
        }
    }
}
