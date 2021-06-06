namespace DevCamp.Services.Data.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DevCamp.Data.Models;

    public interface IPackagesService
    {
        Task CreateAsync(string name, double price, string packageInfo, string description, int listingId, IEnumerable<PackageItem> items);

        Task<T> GetByIdAsync<T>(int id);

        IEnumerable<T> GetAll<T>(int listingId);

        Task EditAsync(int id, string name, double price, string packageInfo, string description, int listingId, IEnumerable<PackageItem> items);
    }
}
