namespace DevCamp.Services.Data.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IPackagesService
    {
        Task CreateAsync(string name, double price, string description, int listingId);

        Task<T> GetByIdAsync<T>(int id);

        IEnumerable<T> GetAll<T>(int listingId);

        Task EditAsync(int id, string name, double price, string description, int listingId);

        Task DeleteAsync(int id);
    }
}
