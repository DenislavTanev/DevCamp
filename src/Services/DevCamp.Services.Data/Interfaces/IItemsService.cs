namespace DevCamp.Services.Data.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IItemsService
    {
        IEnumerable<T> GetAll<T>();

        Task CreateAsync(string name);

        Task EditAsync(int id, string name);

        Task<T> GetByIdAsync<T>(int id);

        IEnumerable<T> GetAllByPackage<T>(int packageId);
    }
}
