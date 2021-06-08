namespace DevCamp.Services.Data.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IPackageItemsService
    {
        IEnumerable<T> GetAllByPackage<T>(int packageId);

        Task CreateAsync(int packageId, int itemId, string content, bool isIncluded);

        Task EditAsync(int id, int packageId, int itemId, string content, bool isIncluded);

        Task<T> GetByIdAsync<T>(int id);

        Task DeleteAsync(int id);
    }
}
